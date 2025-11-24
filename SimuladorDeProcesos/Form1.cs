using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimuladorDeProcesos.Memoria;
using SimuladorDeProcesos.Procesos;
using SimuladorDeProcesos.Despachador;
using SimuladorDeProcesos.Scheduler;
using SimuladorDeProcesos.IO;
using System.Runtime.Versioning;

namespace SimuladorDeProcesos
{
    [SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        private IScheduler scheduler;
        private IOManager ioManager = new IOManager();
        private Process currentProcess = null;
        private List<Process> listaProcesos = new List<Process>();
        private List<Process> historialProcesos = new List<Process>();
        private List<Interrupt> listaInterrupciones = new List<Interrupt>();
        private int nextPID = 1;
        private int tiempoTranscurrido = 0;
        private int quantumActual = 0; // Contador para Round Robin

        public Form1()
        {
            InitializeComponent();
            InicializarInterfaz();
        }

        private void InicializarInterfaz()
        {
            // Configurar ComboBox de planificadores
            cmbSchedulers.SelectedIndex = 0;
            scheduler = new FCFS();

            // Configurar DataGridView de Procesos
            dgvProcesos.Columns.Clear();
            dgvProcesos.Columns.Add("colProceso", "#Proceso");
            dgvProcesos.Columns.Add("colTamano", "Tamaño (MB)");
            dgvProcesos.Columns.Add("colBurstTime", "Burst-Time");
            dgvProcesos.Columns.Add("colQuantum", "Quantum");
            dgvProcesos.Columns.Add("colResiduo", "Residuo");
            dgvProcesos.Columns.Add("colEstado", "Estado");

            // Configurar DataGridView de Interrupciones
            dgvInterrupciones.Columns.Clear();
            dgvInterrupciones.Columns.Add("colInterrupcion", "#Interrupción");
            dgvInterrupciones.Columns.Add("colDuracion", "Duración");
            dgvInterrupciones.Columns.Add("colRestante", "Restante");
            dgvInterrupciones.Columns.Add("colEstadoInt", "Estado");

            // Configurar DataGridView de Historial
            dgvHistorial.Columns.Clear();
            dgvHistorial.Columns.Add("colProcesoHist", "#Proceso");
            dgvHistorial.Columns.Add("colBurstHist", "Burst-Time");
            dgvHistorial.Columns.Add("colTiempoFinal", "Tiempo Final");

            // Ocultar Quantum por defecto
            lblQuantum.Visible = false;
            numQuantum.Visible = false;
        }

        private void cmbSchedulers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedulers.SelectedItem == null) return;

            string selected = cmbSchedulers.SelectedItem.ToString();

            // Mostrar/ocultar campo Quantum
            if (selected == "Round Robin")
            {
                lblQuantum.Visible = true;
                numQuantum.Visible = true;
                if (dgvProcesos.Columns.Contains("colQuantum"))
                    dgvProcesos.Columns["colQuantum"].Visible = true;
            }
            else
            {
                lblQuantum.Visible = false;
                numQuantum.Visible = false;
                if (dgvProcesos.Columns.Contains("colQuantum"))
                    dgvProcesos.Columns["colQuantum"].Visible = false;
            }

            // Crear scheduler correspondiente
            switch (selected)
            {
                case "First Come First Serve":
                    scheduler = new FCFS();
                    break;
                case "Short Job First":
                    scheduler = new SJF();
                    break;
                case "Shortest Remaining Time First":
                    scheduler = new SRTF();
                    break;
                case "Round Robin":
                    scheduler = new RoundRobin((int)numQuantum.Value);
                    break;
                case "Prioridad":
                    scheduler = new PriorityScheduler();
                    break;
            }

            // Re-agregar procesos al nuevo scheduler
            foreach (var p in listaProcesos)
            {
                if (p.Estado == "Ready" || p.Estado == "Listo")
                {
                    scheduler.AddProcess(p);
                }
            }
        }

        private void btnAgregarProceso_Click(object sender, EventArgs e)
        {
            // Validar inputs
            if (!int.TryParse(txtTamanoMB.Text, out int tamanoMB) || tamanoMB <= 0)
            {
                MessageBox.Show("Por favor ingrese un tamaño válido en MB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtBurstTime.Text, out int burstTime) || burstTime <= 0)
            {
                MessageBox.Show("Por favor ingrese un Burst-Time válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear nuevo proceso
            Process nuevoProceso = new Process(
                pid: nextPID++,
                estado: "Ready",
                burstTotal: burstTime,
                tamanoCodigo: 100, // Valores por defecto
                tamanoDatos: 50,
                tamanoHeap: 30,
                prioridad: 1,
                tamanoMB: tamanoMB
            );

            // Agregar a la lista
            listaProcesos.Add(nuevoProceso);
            scheduler.AddProcess(nuevoProceso);

            // Actualizar vista
            ActualizarVistaProcesos();

            // Limpiar inputs
            txtTamanoMB.Clear();
            txtBurstTime.Clear();
            txtTamanoMB.Focus();
        }

        private void ActualizarVistaProcesos()
        {
            dgvProcesos.Rows.Clear();

            foreach (var p in listaProcesos)
            {
                int quantum = 0;
                if (scheduler is RoundRobin rr)
                {
                    quantum = rr.Quantum;
                }

                dgvProcesos.Rows.Add(
                    $"P{p.PID}",
                    p.TamanoMB,
                    p.BurstTotal,
                    quantum > 0 ? quantum.ToString() : "-",
                    p.BurstRestante,
                    p.Estado
                );

                // Colorear según estado
                int rowIndex = dgvProcesos.Rows.Count - 1;
                if (p.Estado == "Running" || p.Estado == "Ejecutando")
                {
                    dgvProcesos.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (p.Estado == "Terminado" || p.Estado == "Exit")
                {
                    dgvProcesos.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void btnIniciarSimulacion_Click(object sender, EventArgs e)
        {
            if (listaProcesos.Count == 0)
            {
                MessageBox.Show("No hay procesos para simular. Agregue al menos un proceso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Actualizar scheduler si es Round Robin con nuevo quantum
            if (scheduler is RoundRobin && cmbSchedulers.SelectedItem.ToString() == "Round Robin")
            {
                scheduler = new RoundRobin((int)numQuantum.Value);
                foreach (var p in listaProcesos)
                {
                    if (p.Estado == "Ready" || p.Estado == "Listo")
                    {
                        scheduler.AddProcess(p);
                    }
                }
                ActualizarVistaProcesos();
            }

            // Iniciar simulación
            btnIniciarSimulacion.Enabled = false;
            btnDetenerSimulacion.Enabled = true;
            cmbSchedulers.Enabled = false;
            btnAgregarProceso.Enabled = false;
            numQuantum.Enabled = false;

            timerSimulacion.Start();
        }

        private void btnDetenerSimulacion_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            btnIniciarSimulacion.Enabled = true;
            btnDetenerSimulacion.Enabled = false;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();

            // Limpiar todo
            listaProcesos.Clear();
            historialProcesos.Clear();
            listaInterrupciones.Clear();
            currentProcess = null;
            nextPID = 1;
            tiempoTranscurrido = 0;
            quantumActual = 0;

            // Re-inicializar scheduler
            cmbSchedulers_SelectedIndexChanged(null, null);

            // Actualizar vistas
            dgvProcesos.Rows.Clear();
            dgvInterrupciones.Rows.Clear();
            dgvHistorial.Rows.Clear();
            lblProcesoActualNombre.Text = "Sin proceso";
            progressBarProceso.Value = 0;
            lblPorcentaje.Text = "0%";
            lblTiempoTranscurrido.Text = "Tiempo transcurrido: 0 unidades";
            lblCantidadProcesos.Text = "Procesos terminados: 0";
            lblTiempoTotal.Text = $"Tiempo total: 0";

            // Habilitar controles
            btnIniciarSimulacion.Enabled = true;
            btnDetenerSimulacion.Enabled = false;
            cmbSchedulers.Enabled = true;
            btnAgregarProceso.Enabled = true;
            numQuantum.Enabled = true;
        }

        private void timerSimulacion_Tick(object sender, EventArgs e)
        {
            // Si no hay proceso actual, obtener el siguiente
            if (currentProcess == null || currentProcess.BurstRestante <= 0)
            {
                // Si el proceso actual terminó, moverlo al historial
                if (currentProcess != null && currentProcess.BurstRestante <= 0)
                {
                    currentProcess.Estado = "Terminado";
                    currentProcess.TiempoFinal = tiempoTranscurrido;
                    MoverProcesoAHistorial(currentProcess);
                    currentProcess = null;
                    quantumActual = 0;
                }

                // Obtener siguiente proceso
                currentProcess = scheduler.GetNextProcess(null);

                if (currentProcess == null)
                {
                    // No hay más procesos, detener simulación
                    timerSimulacion.Stop();
                    MessageBox.Show("Simulación completada. Todos los procesos han sido atendidos.", "Simulación Terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIniciarSimulacion.Enabled = true;
                    btnDetenerSimulacion.Enabled = false;
                    lblProcesoActualNombre.Text = "Simulación completada";
                    return;
                }

                currentProcess.Estado = "Running";
                quantumActual = 0;
            }

            // Para Round Robin, verificar si se agotó el quantum
            if (scheduler is RoundRobin rr)
            {
                if (quantumActual >= rr.Quantum && currentProcess.BurstRestante > 0)
                {
                    // Quantum agotado, devolver a la cola
                    currentProcess.Estado = "Ready";
                    scheduler.AddProcess(currentProcess);
                    currentProcess = null;
                    quantumActual = 0;
                    ActualizarVistaProcesos();
                    return;
                }
            }

            // Procesar 1 unidad de tiempo
            if (currentProcess != null && currentProcess.BurstRestante > 0)
            {
                currentProcess.BurstRestante--;
                quantumActual++;
                tiempoTranscurrido++;

                // Actualizar UI
                ActualizarProcesoActual();
                ActualizarVistaProcesos();
                lblTiempoTranscurrido.Text = $"Tiempo transcurrido: {tiempoTranscurrido} unidades";

                // Simular interrupciones aleatorias (10% de probabilidad)
                Random rand = new Random();
                if (rand.Next(100) < 10)
                {
                    GenerarInterrupcionAleatoria();
                }
            }
        }

        private void ActualizarProcesoActual()
        {
            if (currentProcess != null)
            {
                lblProcesoActualNombre.Text = $"Proceso P{currentProcess.PID}";
                int porcentaje = currentProcess.PorcentajeProcesado;
                progressBarProceso.Value = porcentaje;
                lblPorcentaje.Text = $"{porcentaje}%";
            }
            else
            {
                lblProcesoActualNombre.Text = "Sin proceso";
                progressBarProceso.Value = 0;
                lblPorcentaje.Text = "0%";
            }
        }

        private void MoverProcesoAHistorial(Process proceso)
        {
            historialProcesos.Add(proceso);
            
            // Actualizar tabla de historial
            dgvHistorial.Rows.Clear();
            foreach (var p in historialProcesos)
            {
                dgvHistorial.Rows.Add($"P{p.PID}", p.BurstTotal, p.TiempoFinal);
            }

            // Actualizar labels
            lblCantidadProcesos.Text = $"Procesos terminados: {historialProcesos.Count}";
            lblTiempoTotal.Text = $"Tiempo total: {tiempoTranscurrido}";
        }

        private void GenerarInterrupcionAleatoria()
        {
            Interrupt interrupt = ioManager.GenerarInterrupcionAleatoria(currentProcess?.PID ?? 0);
            listaInterrupciones.Add(interrupt);

            // Actualizar tabla de interrupciones
            dgvInterrupciones.Rows.Clear();
            foreach (var i in listaInterrupciones)
            {
                dgvInterrupciones.Rows.Add(
                    $"INT{listaInterrupciones.IndexOf(i) + 1}",
                    i.Duracion,
                    i.Duracion, // Por ahora restante = duración
                    "Pendiente"
                );
            }
        }
    }
}

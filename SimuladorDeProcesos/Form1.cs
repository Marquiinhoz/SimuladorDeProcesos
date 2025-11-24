using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Versioning;
using SimuladorDeProcesos.BLL;
using SimuladorDeProcesos.Domain.Procesos;
using SimuladorDeProcesos.Domain.IO;
using SimuladorDeProcesos.Domain.Scheduler;
using SimuladorDeProcesos.Domain.Memoria;

namespace SimuladorDeProcesos
{
    [SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        // Arquitectura en capas
        private SimulationService simulationService;

        // Variables para simulación manual paso a paso
        private IScheduler scheduler;
        private IOManager ioManager = new IOManager();
        private Process currentProcess = null;
        private List<Process> listaProcesos = new List<Process>();
        private List<Process> historialProcesos = new List<Process>();
        private List<Interrupt> listaInterrupciones = new List<Interrupt>();
        private int nextPID = 1;
        private int tiempoTranscurrido = 0;
        private int quantumActual = 0;

        public Form1()
        {
            InitializeComponent();
            InicializarInterfaz();
            simulationService = new SimulationService();
        }

        private void InicializarInterfaz()
        {
            // Configurar ComboBox de planificadores
            if (cmbSchedulers != null)
            {
                cmbSchedulers.SelectedIndex = 0;
            }
            scheduler = new FCFS();

            // Configurar DataGridView de Procesos
            if (dgvProcesos != null && dgvProcesos.Columns.Count == 0)
            {
                dgvProcesos.Columns.Clear();
                dgvProcesos.Columns.Add("colProceso", "#Proceso");
                dgvProcesos.Columns.Add("colTamano", "Tamaño (MB)");
                dgvProcesos.Columns.Add("colBurstTime", "Burst-Time");
                dgvProcesos.Columns.Add("colQuantum", "Quantum");
                dgvProcesos.Columns.Add("colResiduo", "Residuo");
                dgvProcesos.Columns.Add("colEstado", "Estado");
            }

            // Configurar DataGridView de Interrupciones
            if (dgvInterrupciones != null && dgvInterrupciones.Columns.Count == 0)
            {
                dgvInterrupciones.Columns.Clear();
                dgvInterrupciones.Columns.Add("colInterrupcion", "#Interrupción");
                dgvInterrupciones.Columns.Add("colDuracion", "Duración");
                dgvInterrupciones.Columns.Add("colRestante", "Restante");
                dgvInterrupciones.Columns.Add("colEstadoInt", "Estado");
            }

            // Configurar DataGridView de Historial
            if (dgvHistorial != null && dgvHistorial.Columns.Count == 0)
            {
                dgvHistorial.Columns.Clear();
                dgvHistorial.Columns.Add("colProcesoHist", "#Proceso");
                dgvHistorial.Columns.Add("colBurstHist", "Burst-Time");
                dgvHistorial.Columns.Add("colTiempoFinal", "Tiempo Final");
            }

            // Ocultar Quantum por defecto
            if (lblQuantum != null) lblQuantum.Visible = false;
            if (numQuantum != null) numQuantum.Visible = false;
        }

        private void cmbSchedulers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedulers == null || cmbSchedulers.SelectedItem == null) return;

            string selected = cmbSchedulers.SelectedItem.ToString();

            // Actualizar SimulationService
            if (simulationService != null)
            {
                simulationService.SetScheduler(selected);
            }

            // Mostrar/ocultar campo Quantum
            if (selected == "Round Robin")
            {
                if (lblQuantum != null) lblQuantum.Visible = true;
                if (numQuantum != null) numQuantum.Visible = true;
                if (dgvProcesos != null && dgvProcesos.Columns.Contains("colQuantum"))
                    dgvProcesos.Columns["colQuantum"].Visible = true;
            }
            else
            {
                if (lblQuantum != null) lblQuantum.Visible = false;
                if (numQuantum != null) numQuantum.Visible = false;
                if (dgvProcesos != null && dgvProcesos.Columns.Contains("colQuantum"))
                    dgvProcesos.Columns["colQuantum"].Visible = false;
            }

            // Crear scheduler correspondiente para simulación manual
            switch (selected)
            {
                case "FCFS":
                case "First Come First Serve":
                    scheduler = new FCFS();
                    break;
                case "SJF":
                case "Short Job First":
                    scheduler = new SJF();
                    break;
                case "SRTF":
                case "Shortest Remaining Time First":
                    scheduler = new SRTF();
                    break;
                case "Round Robin":
                    int quantum = numQuantum != null ? (int)numQuantum.Value : 3;
                    scheduler = new RoundRobin(quantum);
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
            if (txtTamanoMB != null && txtBurstTime != null)
            {
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
                    tamanoCodigo: 100,
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
        }

        private void ActualizarVistaProcesos()
        {
            if (dgvProcesos == null) return;

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
                int quantum = numQuantum != null ? (int)numQuantum.Value : 3;
                scheduler = new RoundRobin(quantum);
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
            if (btnIniciarSimulacion != null) btnIniciarSimulacion.Enabled = false;
            if (btnDetenerSimulacion != null) btnDetenerSimulacion.Enabled = true;
            if (cmbSchedulers != null) cmbSchedulers.Enabled = false;
            if (btnAgregarProceso != null) btnAgregarProceso.Enabled = false;
            if (numQuantum != null) numQuantum.Enabled = false;

            if (timerSimulacion != null) timerSimulacion.Start();
        }

        private void btnDetenerSimulacion_Click(object sender, EventArgs e)
        {
            if (timerSimulacion != null) timerSimulacion.Stop();
            if (btnIniciarSimulacion != null) btnIniciarSimulacion.Enabled = true;
            if (btnDetenerSimulacion != null) btnDetenerSimulacion.Enabled = false;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (timerSimulacion != null) timerSimulacion.Stop();

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
            if (dgvProcesos != null) dgvProcesos.Rows.Clear();
            if (dgvInterrupciones != null) dgvInterrupciones.Rows.Clear();
            if (dgvHistorial != null) dgvHistorial.Rows.Clear();
            if (lblProcesoActualNombre != null) lblProcesoActualNombre.Text = "Sin proceso";
            if (progressBarProceso != null) progressBarProceso.Value = 0;
            if (lblPorcentaje != null) lblPorcentaje.Text = "0%";
            if (lblTiempoTranscurrido != null) lblTiempoTranscurrido.Text = "Tiempo transcurrido: 0 unidades";
            if (lblCantidadProcesos != null) lblCantidadProcesos.Text = "Procesos terminados: 0";
            if (lblTiempoTotal != null) lblTiempoTotal.Text = $"Tiempo total: 0";

            // Habilitar controles
            if (btnIniciarSimulacion != null) btnIniciarSimulacion.Enabled = true;
            if (btnDetenerSimulacion != null) btnDetenerSimulacion.Enabled = false;
            if (cmbSchedulers != null) cmbSchedulers.Enabled = true;
            if (btnAgregarProceso != null) btnAgregarProceso.Enabled = true;
            if (numQuantum != null) numQuantum.Enabled = true;
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
                    if (timerSimulacion != null) timerSimulacion.Stop();
                    MessageBox.Show("Simulación completada. Todos los procesos han sido atendidos.", "Simulación Terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnIniciarSimulacion != null) btnIniciarSimulacion.Enabled = true;
                    if (btnDetenerSimulacion != null) btnDetenerSimulacion.Enabled = false;
                    if (lblProcesoActualNombre != null) lblProcesoActualNombre.Text = "Simulación completada";
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
                if (lblTiempoTranscurrido != null)
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
                if (lblProcesoActualNombre != null)
                    lblProcesoActualNombre.Text = $"Proceso P{currentProcess.PID}";
                int porcentaje = currentProcess.PorcentajeProcesado;
                if (progressBarProceso != null) progressBarProceso.Value = porcentaje;
                if (lblPorcentaje != null) lblPorcentaje.Text = $"{porcentaje}%";
            }
            else
            {
                if (lblProcesoActualNombre != null) lblProcesoActualNombre.Text = "Sin proceso";
                if (progressBarProceso != null) progressBarProceso.Value = 0;
                if (lblPorcentaje != null) lblPorcentaje.Text = "0%";
            }
        }

        private void MoverProcesoAHistorial(Process proceso)
        {
            historialProcesos.Add(proceso);

            // Actualizar tabla de historial
            if (dgvHistorial != null)
            {
                dgvHistorial.Rows.Clear();
                foreach (var p in historialProcesos)
                {
                    dgvHistorial.Rows.Add($"P{p.PID}", p.BurstTotal, p.TiempoFinal);
                }
            }

            // Actualizar labels
            if (lblCantidadProcesos != null)
                lblCantidadProcesos.Text = $"Procesos terminados: {historialProcesos.Count}";
            if (lblTiempoTotal != null)
                lblTiempoTotal.Text = $"Tiempo total: {tiempoTranscurrido}";
        }

        private void GenerarInterrupcionAleatoria()
        {
            Interrupt interrupt = ioManager.GenerarInterrupcionAleatoria(currentProcess?.PID ?? 0);
            listaInterrupciones.Add(interrupt);

            // Actualizar tabla de interrupciones
            if (dgvInterrupciones != null)
            {
                dgvInterrupciones.Rows.Clear();
                foreach (var i in listaInterrupciones)
                {
                    dgvInterrupciones.Rows.Add(
                        $"INT{listaInterrupciones.IndexOf(i) + 1}",
                        i.Duracion,
                        i.Duracion,
                        "Pendiente"
                    );
                }
            }
        }
    }
}

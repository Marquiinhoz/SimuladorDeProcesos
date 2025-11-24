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


namespace SimuladorDeProcesos
{
    public partial class Form1 : Form
    {
        private FCFS scheduler = new FCFS();
        private IOManager ioManager = new IOManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ProcessManager manager = new ProcessManager();
            manager.GenerarProcesos();

            dgvProcesos.Rows.Clear();
            dgvProcesos.ColumnCount = 7;
            dgvProcesos.Columns[0].Name = "PID";
            dgvProcesos.Columns[1].Name = "Estado";
            dgvProcesos.Columns[2].Name = "BurstRestante";
            dgvProcesos.Columns[3].Name = "PC";
            dgvProcesos.Columns[4].Name = "TamanoCodigo";
            dgvProcesos.Columns[5].Name = "TamanoDatos";
            dgvProcesos.Columns[6].Name = "Prioridad";

            lstReadyQueue.Items.Clear();

            foreach (var p in manager.ListaProcesos)
            {
                dgvProcesos.Rows.Add(p.PID, p.Estado, p.BurstRestante, p.ProgramCounter, p.TamanoCodigo, p.TamanoDatos, p.Prioridad);
                
                // Agregar a Ready Queue para probar Scheduler
                p.Estado = "Ready";
                scheduler.AddProcess(p);
                lstReadyQueue.Items.Add($"P{p.PID} (Burst: {p.BurstRestante})");
            }

        }

        private void btnProbarMemoria_Click(object sender, EventArgs e)
        {
            var mem = new MemoryManager();

            // Simular asignaciones para dos procesos (tamaños en KB)
            List<int> p1 = mem.FirstFit(120); // P1 requiere 120 KB
            List<int> p2 = mem.FirstFit(200); // P2 requiere 200 KB

            // Mostrar bloques asignados en el TextBox
            txtMapaBits.Clear();
            txtMapaBits.AppendText("P1 bloques: " + (p1 == null ? "NO ASIGNADO" : string.Join(",", p1)) + Environment.NewLine);
            txtMapaBits.AppendText("P2 bloques: " + (p2 == null ? "NO ASIGNADO" : string.Join(",", p2)) + Environment.NewLine);
            txtMapaBits.AppendText(Environment.NewLine);
            txtMapaBits.AppendText("Mapa de Bits (0=libre,1=ocupado):" + Environment.NewLine);
            txtMapaBits.AppendText(string.Join(" ", mem.Bitmap));
        }

        private void btnDispatcher_Click(object sender, EventArgs e)
        {
            // Tomar el siguiente del scheduler
            Process next = scheduler.GetNextProcess();
            
            if (next != null)
            {
                Process current = null; // Simular que no había nadie o crear uno dummy
                
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.ContextSwitch(current, next);

                txtLogDispatcher.Text = dispatcher.UltimoLog;
                txtCPU.Text = $"P{next.PID} Running";
                
                // Actualizar lista visual de Ready Queue
                lstReadyQueue.Items.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("No hay procesos en Ready Queue");
            }
        }

        private void btnSimularIO_Click(object sender, EventArgs e)
        {
            // Simular interrupción para un proceso ficticio P3
            Interrupt interrupt = ioManager.GenerarInterrupcionAleatoria(3);
            
            lstIO.Items.Add(interrupt.ToString());
            
            // Mostrar estado de colas
            // En una implementación real, actualizaríamos visualmente las colas por separado
        }
    }
}

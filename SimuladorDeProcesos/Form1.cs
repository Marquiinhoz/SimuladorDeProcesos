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

namespace SimuladorDeProcesos
{
    [SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        private SimulationService simulationService;
        private ComboBox cmbSchedulers;

        public Form1()
        {
            InitializeComponent();
            InitializeSchedulerSelector();
            simulationService = new SimulationService();
        }

        private void StyleControl(Control c)
        {
            c.BackColor = Color.FromArgb(35, 35, 35);
            c.ForeColor = Color.White;
            if (c is TextBox) ((TextBox)c).BorderStyle = BorderStyle.FixedSingle;
            if (c is ListBox) ((ListBox)c).BorderStyle = BorderStyle.FixedSingle;
        }

        private void InitializeSchedulerSelector()
        {
            cmbSchedulers = new ComboBox();
            cmbSchedulers.Items.AddRange(new object[] { "FCFS", "SJF", "SRTF", "Round Robin", "Prioridad" });
            cmbSchedulers.SelectedIndex = 0; // Default FCFS
            cmbSchedulers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSchedulers.Location = new Point(800, 25);
            cmbSchedulers.Size = new Size(180, 30);
            cmbSchedulers.Font = new Font("Segoe UI", 10);
            cmbSchedulers.SelectedIndexChanged += CmbSchedulers_SelectedIndexChanged;

            // Add to panelHeader
            this.panelHeader.Controls.Add(cmbSchedulers);

            // Add a label for it
            Label lblSched = new Label();
            lblSched.Text = "Planificador:";
            lblSched.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSched.Location = new Point(700, 28);
            lblSched.AutoSize = true;
            this.panelHeader.Controls.Add(lblSched);
        }

        private void CmbSchedulers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedulers.SelectedItem == null) return;
            string selected = cmbSchedulers.SelectedItem.ToString();

            if (simulationService != null)
            {
                simulationService.SetScheduler(selected);
            }

            // Clear the visual queue
            lstReadyQueue.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simulationService.GenerateProcesses();

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
            txtCPU.Text = "";

            foreach (var p in simulationService.ProcessManager.ListaProcesos)
            {
                dgvProcesos.Rows.Add(p.PID, p.Estado, p.BurstRestante, p.ProgramCounter, p.TamanoCodigo, p.TamanoDatos, p.Prioridad);
                lstReadyQueue.Items.Add($"P{p.PID} (Burst: {p.BurstRestante})");
            }
        }


        private void btnProbarMemoria_Click(object sender, EventArgs e)
        {
            // Simular asignaciones con segmentación para dos procesos
            // P1: 50 KB código, 40 KB datos, 30 KB heap = 120 KB total
            var p1Alloc = simulationService.MemoryManager.AllocateMemory(1, 50, 40, 30);

            // P2: 80 KB código, 70 KB datos, 50 KB heap = 200 KB total
            var p2Alloc = simulationService.MemoryManager.AllocateMemory(2, 80, 70, 50);

            // Mostrar mapa de memoria completo
            txtMapaBits.Clear();
            txtMapaBits.AppendText(simulationService.MemoryManager.GetMemoryMapText());
            txtMapaBits.AppendText(Environment.NewLine);

            // Mostrar detalles de asignaciones
            if (p1Alloc != null)
            {
                txtMapaBits.AppendText($"✓ P1 asignado: {p1Alloc.TotalAllocated} KB en {p1Alloc.Segments.Count} segmentos" + Environment.NewLine);
            }
            else
            {
                txtMapaBits.AppendText("✗ P1 NO ASIGNADO - Sin memoria suficiente" + Environment.NewLine);
            }

            if (p2Alloc != null)
            {
                txtMapaBits.AppendText($"✓ P2 asignado: {p2Alloc.TotalAllocated} KB en {p2Alloc.Segments.Count} segmentos" + Environment.NewLine);
            }
            else
            {
                txtMapaBits.AppendText("✗ P2 NO ASIGNADO - Sin memoria suficiente" + Environment.NewLine);
            }
        }


        private void btnDispatcher_Click(object sender, EventArgs e)
        {
            simulationService.RunDispatcher();

            Process current = simulationService.CurrentProcess;

            if (current != null)
            {
                txtLogDispatcher.Text = simulationService.Dispatcher.UltimoLog;
                txtCPU.Text = $"P{current.PID} Running";

                // Actualizar lista visual de Ready Queue
                for (int i = 0; i < lstReadyQueue.Items.Count; i++)
                {
                    if (lstReadyQueue.Items[i].ToString().Contains($"P{current.PID}"))
                    {
                        lstReadyQueue.Items.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay procesos en Ready Queue o no se seleccionó ninguno.");
            }
        }

        private void btnSimularIO_Click(object sender, EventArgs e)
        {
            // Simular interrupción para un proceso ficticio P3
            Interrupt interrupt = simulationService.IOManager.GenerarInterrupcionAleatoria(3);

            lstIO.Items.Add(interrupt.ToString());
        }
    }
}

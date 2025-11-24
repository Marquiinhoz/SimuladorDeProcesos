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
        private IScheduler scheduler;
        private IOManager ioManager = new IOManager();
        private Process currentProcess = null;
        private ComboBox cmbSchedulers;

        public Form1()
        {
            InitializeComponent();
            ApplyModernTheme();
            InitializeSchedulerSelector();
            // Default scheduler
            scheduler = new FCFS();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Helpers.UIHelper.BackgroundColor;
            
            // Header
            panelHeader.BackColor = Helpers.UIHelper.SurfaceColor;
            
            // Buttons
            Helpers.UIHelper.StyleButton(button1, Helpers.UIHelper.AccentColor); // Generar
            Helpers.UIHelper.StyleButton(btnProbarMemoria, Color.FromArgb(40, 167, 69)); // Green
            Helpers.UIHelper.StyleButton(btnDispatcher, Color.FromArgb(255, 193, 7)); // Orange/Yellow
            btnDispatcher.ForeColor = Color.Black; // Better contrast for yellow
            Helpers.UIHelper.StyleButton(btnSimularIO, Color.FromArgb(111, 66, 193)); // Purple

            // DataGridView
            Helpers.UIHelper.StyleDataGridView(dgvProcesos);

            // GroupBoxes
            // Note: Custom painting in UIHelper might conflict if not handled carefully, 
            // but let's try applying simple styling first.
            foreach(Control c in this.Controls)
            {
               if(c is GroupBox) Helpers.UIHelper.StyleGroupBox((GroupBox)c);
            }
            // Also nested ones
            foreach(Control c in tableLayoutPanelMain.Controls)
            {
                if(c is GroupBox) Helpers.UIHelper.StyleGroupBox((GroupBox)c);
            }
            foreach(Control c in panelSidebar.Controls)
            {
                if(c is GroupBox) Helpers.UIHelper.StyleGroupBox((GroupBox)c);
            }

            // TextBoxes & Lists
            StyleControl(txtCPU);
            StyleControl(txtLogDispatcher);
            StyleControl(txtMapaBits);
            StyleControl(lstReadyQueue);
            StyleControl(lstIO);

            // Labels
            lblCPU.ForeColor = Helpers.UIHelper.TextColor;
            lblReadyQueue.ForeColor = Helpers.UIHelper.TextColor;
        }

        private void StyleControl(Control c)
        {
            c.BackColor = Color.FromArgb(35, 35, 35);
            c.ForeColor = Helpers.UIHelper.TextColor;
            if(c is TextBox) ((TextBox)c).BorderStyle = BorderStyle.FixedSingle;
            if(c is ListBox) ((ListBox)c).BorderStyle = BorderStyle.FixedSingle;
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
            cmbSchedulers.BackColor = Helpers.UIHelper.SurfaceColor;
            cmbSchedulers.ForeColor = Helpers.UIHelper.TextColor;
            cmbSchedulers.FlatStyle = FlatStyle.Flat;
            cmbSchedulers.SelectedIndexChanged += CmbSchedulers_SelectedIndexChanged;
            
            // Add to panelHeader
            this.panelHeader.Controls.Add(cmbSchedulers);
            
            // Add a label for it
            Label lblSched = new Label();
            lblSched.Text = "Planificador:";
            lblSched.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSched.ForeColor = Helpers.UIHelper.TextColor;
            lblSched.Location = new Point(700, 28);
            lblSched.AutoSize = true;
            this.panelHeader.Controls.Add(lblSched);
        }

        private void CmbSchedulers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedulers.SelectedItem == null) return;
            string selected = cmbSchedulers.SelectedItem.ToString();
            switch (selected)
            {
                case "FCFS":
                    scheduler = new FCFS();
                    break;
                case "SJF":
                    scheduler = new SJF();
                    break;
                case "SRTF":
                    scheduler = new SRTF();
                    break;
                case "Round Robin":
                    scheduler = new RoundRobin(3); // Default Quantum 3
                    break;
                case "Prioridad":
                    scheduler = new PriorityScheduler();
                    break;
            }
            
            // Clear the visual queue as the internal scheduler queue is now empty
            lstReadyQueue.Items.Clear();
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
            currentProcess = null;
            txtCPU.Text = "";

            // Re-initialize scheduler to ensure clean state based on current selection
            // We can just trigger the logic by re-setting the scheduler directly or calling the handler
            // But calling the handler clears the list, which we just did.
            // Let's just ensure the scheduler is fresh.
            CmbSchedulers_SelectedIndexChanged(null, null);

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
            Process next = scheduler.GetNextProcess(currentProcess);
            
            if (next != null)
            {
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.ContextSwitch(currentProcess, next);

                currentProcess = next; // Update current process

                txtLogDispatcher.Text = dispatcher.UltimoLog;
                txtCPU.Text = $"P{next.PID} Running";
                
                // Actualizar lista visual de Ready Queue
                // Note: This removal logic is visual only and assumes order. 
                // With different schedulers, the order in ListBox might not match the internal queue/list.
                // It's better to refresh the list from the scheduler, but IScheduler doesn't expose the list.
                // For now, we just remove the item that matches the PID if possible, or just rebuild the list.
                // Since we don't have easy access to the internal list, we'll try to remove the one that became running.
                
                for(int i=0; i<lstReadyQueue.Items.Count; i++)
                {
                    if(lstReadyQueue.Items[i].ToString().Contains($"P{next.PID}"))
                    {
                        lstReadyQueue.Items.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                if (currentProcess != null)
                {
                    // If no next process but we have a current one, it might be continuing (e.g. SRTF)
                    // But GetNextProcess usually returns the one to run. If it returns null, it means NO process to run.
                    // If SRTF returns currentProcess, then next != null.
                    // So if next is null, really no process is ready.
                    MessageBox.Show("No hay procesos en Ready Queue");
                }
                else
                {
                    MessageBox.Show("No hay procesos en Ready Queue");
                }
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

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
            ApplyCatppuccinMochaTheme();
        }

        private void ApplyCatppuccinMochaTheme()
        {
            // Paleta Catppuccin Mocha (valores hex)
            var rosewater = ColorTranslator.FromHtml("#F5E0DC");
            var flamingo  = ColorTranslator.FromHtml("#F2CDCD");
            var pink      = ColorTranslator.FromHtml("#F5C2E7");
            var mauve     = ColorTranslator.FromHtml("#CBA6F7");
            var peach     = ColorTranslator.FromHtml("#FAB387");
            var yellow    = ColorTranslator.FromHtml("#F9E2AF");
            var green     = ColorTranslator.FromHtml("#A6E3A1");
            var teal      = ColorTranslator.FromHtml("#94E2D5");
            var sky       = ColorTranslator.FromHtml("#89DCEB");
            var blue      = ColorTranslator.FromHtml("#89B4FA");
            var text      = ColorTranslator.FromHtml("#CAD3F5");
            var surface0  = ColorTranslator.FromHtml("#363A4F");
            var surface1  = ColorTranslator.FromHtml("#2A2E3E");
            var base0     = ColorTranslator.FromHtml("#1E1E2E");

            // Color fijo para subtítulos: blanco
            var subtitleColor = ColorTranslator.FromHtml("#FFFFFF");

            // Fondo y texto global: usar base0 como fondo principal
            this.BackColor = base0;
            this.ForeColor = text;

            // Recorrer y aplicar estilos según control
            foreach (var ctrl in GetAllControls(this))
            {
                switch (ctrl)
                {
                    case Button b:
                        b.FlatStyle = FlatStyle.Flat;
                        b.BackColor = surface1;
                        b.ForeColor = text;
                        b.FlatAppearance.BorderColor = mauve;
                        b.FlatAppearance.BorderSize = 1;
                        break;

                    case Label l:
                        // Detectar si es subtítulo: Tag="subtitle" o nombre que contiene title/subtitle o fuente en negrita
                        var name = (l.Name ?? "").ToLowerInvariant();
                        bool isSubtitle = (l.Tag != null && l.Tag.ToString().ToLowerInvariant() == "subtitle")
                                          || name.Contains("title")
                                          || name.Contains("subtitle")
                                          || l.Font.Bold;

                        if (isSubtitle)
                        {
                            // Subtítulos forzados a blanco y en negrita
                            l.ForeColor = subtitleColor;
                            l.Font = new Font(l.Font.FontFamily, Math.Max(9f, l.Font.Size), FontStyle.Bold);
                            l.BackColor = Color.Transparent;
                        }
                        else
                        {
                            l.ForeColor = text;
                            l.BackColor = Color.Transparent;
                        }
                        break;

                    case GroupBox gb:
                        // Títulos de área (GroupBox) en blanco
                        gb.ForeColor = subtitleColor;
                        gb.BackColor = base0;
                        break;

                    case TabPage tp:
                        tp.BackColor = base0;
                        tp.ForeColor = subtitleColor;
                        break;

                    case Panel p:
                        // paneles usan base0 para integrarse mejor con el fondo
                        p.BackColor = base0;
                        break;

                    case ListView lv:
                        lv.BackColor = surface1;
                        lv.ForeColor = text;
                        lv.BorderStyle = BorderStyle.None;
                        break;

                    case DataGridView dg:
                        dg.BackgroundColor = surface1;
                        dg.DefaultCellStyle.BackColor = surface1;
                        dg.DefaultCellStyle.ForeColor = text;
                        dg.ColumnHeadersDefaultCellStyle.BackColor = surface0;
                        dg.ColumnHeadersDefaultCellStyle.ForeColor = text;
                        dg.EnableHeadersVisualStyles = false;
                        break;

                    case TextBox tb:
                        tb.BackColor = surface1;
                        tb.ForeColor = text;
                        tb.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case MenuStrip ms:
                        ms.BackColor = surface0;
                        ms.ForeColor = text;
                        break;

                    case ToolStrip ts:
                        ts.BackColor = surface0;
                        ts.ForeColor = text;
                        break;
                }
            }

            // Botón primario (si existe) con color de acento
            var primaryBtn = this.Controls.OfType<Button>().FirstOrDefault();
            if (primaryBtn != null)
            {
                primaryBtn.BackColor = mauve;
                primaryBtn.ForeColor = base0;
            }
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
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

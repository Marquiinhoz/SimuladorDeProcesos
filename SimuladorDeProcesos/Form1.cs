using SimuladorDeProcesos.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorDeProcesos
{
    public partial class Form1 : Form
    {
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

            foreach (var p in manager.ListaProcesos)
            {
                dgvProcesos.Rows.Add(p.PID, p.Estado, p.BurstRestante, p.ProgramCounter, p.TamanoCodigo, p.TamanoDatos, p.Prioridad);
            }

        }
    }
}

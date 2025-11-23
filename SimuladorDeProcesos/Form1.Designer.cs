namespace SimuladorDeProcesos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.AccessibleName = "";
            this.dgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesos.Location = new System.Drawing.Point(700, 114);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.RowHeadersWidth = 51;
            this.dgvProcesos.RowTemplate.Height = 24;
            this.dgvProcesos.Size = new System.Drawing.Size(597, 286);
            this.dgvProcesos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AccessibleName = "btnGenerarProcesos";
            this.button1.Location = new System.Drawing.Point(1068, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generar Procesos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 532);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvProcesos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.Button button1;
    }
}


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
            this.components = new System.ComponentModel.Container();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProbarMemoria = new System.Windows.Forms.Button();
            this.txtMapaBits = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.AccessibleName = "";
            this.dgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesos.Location = new System.Drawing.Point(59, 78);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.RowHeadersWidth = 51;
            this.dgvProcesos.RowTemplate.Height = 24;
            this.dgvProcesos.Size = new System.Drawing.Size(1245, 442);
            this.dgvProcesos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AccessibleName = "btnGenerarProcesos";
            this.button1.Location = new System.Drawing.Point(70, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generar Procesos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProbarMemoria
            // 
            this.btnProbarMemoria.Location = new System.Drawing.Point(217, 12);
            this.btnProbarMemoria.Name = "btnProbarMemoria";
            this.btnProbarMemoria.Size = new System.Drawing.Size(109, 45);
            this.btnProbarMemoria.TabIndex = 2;
            this.btnProbarMemoria.Text = "Probar Memoria";
            this.btnProbarMemoria.UseVisualStyleBackColor = true;
            this.btnProbarMemoria.Click += new System.EventHandler(this.btnProbarMemoria_Click);
            // 
            // txtMapaBits
            // 
            this.txtMapaBits.Location = new System.Drawing.Point(364, 23);
            this.txtMapaBits.Multiline = true;
            this.txtMapaBits.Name = "txtMapaBits";
            this.txtMapaBits.ReadOnly = true;
            this.txtMapaBits.Size = new System.Drawing.Size(208, 34);
            this.txtMapaBits.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 532);
            this.Controls.Add(this.txtMapaBits);
            this.Controls.Add(this.btnProbarMemoria);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvProcesos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProbarMemoria;
        private System.Windows.Forms.TextBox txtMapaBits;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}


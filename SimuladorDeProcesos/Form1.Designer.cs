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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.components = new System.ComponentModel.Container();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProbarMemoria = new System.Windows.Forms.Button();
            this.txtMapaBits = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDispatcher = new System.Windows.Forms.Button();
            this.txtLogDispatcher = new System.Windows.Forms.TextBox();
            this.lstReadyQueue = new System.Windows.Forms.ListBox();
            this.txtCPU = new System.Windows.Forms.TextBox();
            this.lstIO = new System.Windows.Forms.ListBox();
            this.btnSimularIO = new System.Windows.Forms.Button();
            
            // Contenedores de diseño
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpProcesos = new System.Windows.Forms.GroupBox();
            this.panelSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.grpCPU = new System.Windows.Forms.GroupBox();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblReadyQueue = new System.Windows.Forms.Label();
            this.grpMemoria = new System.Windows.Forms.GroupBox();
            this.grpIO = new System.Windows.Forms.GroupBox();
            this.grpLog = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.grpProcesos.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.grpCPU.SuspendLayout();
            this.grpMemoria.SuspendLayout();
            this.grpIO.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.btnSimularIO);
            this.panelHeader.Controls.Add(this.btnDispatcher);
            this.panelHeader.Controls.Add(this.btnProbarMemoria);
            this.panelHeader.Controls.Add(this.button1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1280, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // button1 (Generar Procesos)
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generar Procesos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProbarMemoria
            // 
            this.btnProbarMemoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnProbarMemoria.FlatAppearance.BorderSize = 0;
            this.btnProbarMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarMemoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProbarMemoria.ForeColor = System.Drawing.Color.White;
            this.btnProbarMemoria.Location = new System.Drawing.Point(200, 20);
            this.btnProbarMemoria.Name = "btnProbarMemoria";
            this.btnProbarMemoria.Size = new System.Drawing.Size(160, 40);
            this.btnProbarMemoria.TabIndex = 2;
            this.btnProbarMemoria.Text = "Probar Memoria";
            this.btnProbarMemoria.UseVisualStyleBackColor = false;
            this.btnProbarMemoria.Click += new System.EventHandler(this.btnProbarMemoria_Click);
            // 
            // btnDispatcher
            // 
            this.btnDispatcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.btnDispatcher.FlatAppearance.BorderSize = 0;
            this.btnDispatcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispatcher.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDispatcher.ForeColor = System.Drawing.Color.White;
            this.btnDispatcher.Location = new System.Drawing.Point(380, 20);
            this.btnDispatcher.Name = "btnDispatcher";
            this.btnDispatcher.Size = new System.Drawing.Size(160, 40);
            this.btnDispatcher.TabIndex = 3;
            this.btnDispatcher.Text = "Dispatcher (Step)";
            this.btnDispatcher.UseVisualStyleBackColor = false;
            this.btnDispatcher.Click += new System.EventHandler(this.btnDispatcher_Click);
            // 
            // btnSimularIO
            // 
            this.btnSimularIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.btnSimularIO.FlatAppearance.BorderSize = 0;
            this.btnSimularIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimularIO.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimularIO.ForeColor = System.Drawing.Color.White;
            this.btnSimularIO.Location = new System.Drawing.Point(560, 20);
            this.btnSimularIO.Name = "btnSimularIO";
            this.btnSimularIO.Size = new System.Drawing.Size(160, 40);
            this.btnSimularIO.TabIndex = 4;
            this.btnSimularIO.Text = "Simular I/O";
            this.btnSimularIO.UseVisualStyleBackColor = false;
            this.btnSimularIO.Click += new System.EventHandler(this.btnSimularIO_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelMain.Controls.Add(this.grpProcesos, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelSidebar, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1280, 640);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // grpProcesos
            // 
            this.grpProcesos.Controls.Add(this.dgvProcesos);
            this.grpProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcesos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpProcesos.Location = new System.Drawing.Point(13, 13);
            this.grpProcesos.Name = "grpProcesos";
            this.grpProcesos.Padding = new System.Windows.Forms.Padding(10);
            this.grpProcesos.Size = new System.Drawing.Size(813, 614);
            this.grpProcesos.TabIndex = 0;
            this.grpProcesos.TabStop = false;
            this.grpProcesos.Text = "Lista de Procesos (PCB)";
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.AllowUserToAddRows = false;
            this.dgvProcesos.AllowUserToDeleteRows = false;
            this.dgvProcesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProcesos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcesos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProcesos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcesos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProcesos.ColumnHeadersHeight = 35;
            this.dgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcesos.EnableHeadersVisualStyles = false;
            this.dgvProcesos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProcesos.GridColor = System.Drawing.Color.LightGray;
            this.dgvProcesos.Location = new System.Drawing.Point(10, 30);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.ReadOnly = true;
            this.dgvProcesos.RowHeadersVisible = false;
            this.dgvProcesos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProcesos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProcesos.RowTemplate.Height = 30;
            this.dgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesos.Size = new System.Drawing.Size(793, 574);
            this.dgvProcesos.TabIndex = 0;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.grpCPU);
            this.panelSidebar.Controls.Add(this.grpMemoria);
            this.panelSidebar.Controls.Add(this.grpIO);
            this.panelSidebar.Controls.Add(this.grpLog);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelSidebar.Location = new System.Drawing.Point(832, 13);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(435, 614);
            this.panelSidebar.TabIndex = 1;
            this.panelSidebar.WrapContents = false;
            // 
            // grpCPU
            // 
            this.grpCPU.Controls.Add(this.txtCPU);
            this.grpCPU.Controls.Add(this.lblCPU);
            this.grpCPU.Controls.Add(this.lstReadyQueue);
            this.grpCPU.Controls.Add(this.lblReadyQueue);
            this.grpCPU.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpCPU.Location = new System.Drawing.Point(3, 3);
            this.grpCPU.Name = "grpCPU";
            this.grpCPU.Size = new System.Drawing.Size(420, 180);
            this.grpCPU.TabIndex = 0;
            this.grpCPU.TabStop = false;
            this.grpCPU.Text = "CPU & Scheduler";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCPU.Location = new System.Drawing.Point(240, 35);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(90, 20);
            this.lblCPU.TabIndex = 2;
            this.lblCPU.Text = "Proceso en CPU:";
            // 
            // txtCPU
            // 
            this.txtCPU.BackColor = System.Drawing.Color.White;
            this.txtCPU.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtCPU.ForeColor = System.Drawing.Color.Green;
            this.txtCPU.Location = new System.Drawing.Point(240, 60);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.ReadOnly = true;
            this.txtCPU.Size = new System.Drawing.Size(160, 27);
            this.txtCPU.TabIndex = 3;
            this.txtCPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReadyQueue
            // 
            this.lblReadyQueue.AutoSize = true;
            this.lblReadyQueue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReadyQueue.Location = new System.Drawing.Point(15, 35);
            this.lblReadyQueue.Name = "lblReadyQueue";
            this.lblReadyQueue.Size = new System.Drawing.Size(102, 20);
            this.lblReadyQueue.TabIndex = 0;
            this.lblReadyQueue.Text = "Cola de Listos:";
            // 
            // lstReadyQueue
            // 
            this.lstReadyQueue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstReadyQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstReadyQueue.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstReadyQueue.FormattingEnabled = true;
            this.lstReadyQueue.ItemHeight = 18;
            this.lstReadyQueue.Location = new System.Drawing.Point(15, 60);
            this.lstReadyQueue.Name = "lstReadyQueue";
            this.lstReadyQueue.Size = new System.Drawing.Size(200, 110);
            this.lstReadyQueue.TabIndex = 1;
            // 
            // grpMemoria
            // 
            this.grpMemoria.Controls.Add(this.txtMapaBits);
            this.grpMemoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpMemoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpMemoria.Location = new System.Drawing.Point(3, 189);
            this.grpMemoria.Name = "grpMemoria";
            this.grpMemoria.Size = new System.Drawing.Size(420, 120);
            this.grpMemoria.TabIndex = 1;
            this.grpMemoria.TabStop = false;
            this.grpMemoria.Text = "Memoria (First Fit)";
            // 
            // txtMapaBits
            // 
            this.txtMapaBits.BackColor = System.Drawing.Color.Black;
            this.txtMapaBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMapaBits.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtMapaBits.ForeColor = System.Drawing.Color.Lime;
            this.txtMapaBits.Location = new System.Drawing.Point(3, 26);
            this.txtMapaBits.Multiline = true;
            this.txtMapaBits.Name = "txtMapaBits";
            this.txtMapaBits.ReadOnly = true;
            this.txtMapaBits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMapaBits.Size = new System.Drawing.Size(414, 91);
            this.txtMapaBits.TabIndex = 0;
            // 
            // grpIO
            // 
            this.grpIO.Controls.Add(this.lstIO);
            this.grpIO.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpIO.Location = new System.Drawing.Point(3, 315);
            this.grpIO.Name = "grpIO";
            this.grpIO.Size = new System.Drawing.Size(420, 130);
            this.grpIO.TabIndex = 2;
            this.grpIO.TabStop = false;
            this.grpIO.Text = "Colas de Entrada / Salida";
            // 
            // lstIO
            // 
            this.lstIO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIO.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstIO.FormattingEnabled = true;
            this.lstIO.ItemHeight = 18;
            this.lstIO.Location = new System.Drawing.Point(3, 26);
            this.lstIO.Name = "lstIO";
            this.lstIO.Size = new System.Drawing.Size(414, 101);
            this.lstIO.TabIndex = 0;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLogDispatcher);
            this.grpLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpLog.Location = new System.Drawing.Point(3, 451);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(420, 150);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log del Sistema";
            // 
            // txtLogDispatcher
            // 
            this.txtLogDispatcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLogDispatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogDispatcher.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLogDispatcher.ForeColor = System.Drawing.Color.Cyan;
            this.txtLogDispatcher.Location = new System.Drawing.Point(3, 26);
            this.txtLogDispatcher.Multiline = true;
            this.txtLogDispatcher.Name = "txtLogDispatcher";
            this.txtLogDispatcher.ReadOnly = true;
            this.txtLogDispatcher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogDispatcher.Size = new System.Drawing.Size(414, 121);
            this.txtLogDispatcher.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de Sistema Operativo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.grpProcesos.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.grpCPU.ResumeLayout(false);
            this.grpCPU.PerformLayout();
            this.grpMemoria.ResumeLayout(false);
            this.grpMemoria.PerformLayout();
            this.grpIO.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProbarMemoria;
        private System.Windows.Forms.TextBox txtMapaBits;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnDispatcher;
        private System.Windows.Forms.TextBox txtLogDispatcher;
        private System.Windows.Forms.ListBox lstReadyQueue;
        private System.Windows.Forms.TextBox txtCPU;
        private System.Windows.Forms.ListBox lstIO;
        private System.Windows.Forms.Button btnSimularIO;
        
        // Contenedores nuevos
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox grpProcesos;
        private System.Windows.Forms.FlowLayoutPanel panelSidebar;
        private System.Windows.Forms.GroupBox grpCPU;
        private System.Windows.Forms.GroupBox grpMemoria;
        private System.Windows.Forms.GroupBox grpIO;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblReadyQueue;
    }
}

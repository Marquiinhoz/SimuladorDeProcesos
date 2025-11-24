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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            
            // Header Panel
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPlanificador = new System.Windows.Forms.Label();
            this.cmbSchedulers = new System.Windows.Forms.ComboBox();
            this.btnIniciarSimulacion = new System.Windows.Forms.Button();
            this.btnDetenerSimulacion = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            
            // Panel Principal
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            
            // Panel Izquierdo
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.grpNuevoProceso = new System.Windows.Forms.GroupBox();
            this.lblTamano = new System.Windows.Forms.Label();
            this.txtTamanoMB = new System.Windows.Forms.TextBox();
            this.lblBurstTime = new System.Windows.Forms.Label();
            this.txtBurstTime = new System.Windows.Forms.TextBox();
            this.lblQuantum = new System.Windows.Forms.Label();
            this.numQuantum = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarProceso = new System.Windows.Forms.Button();
            this.grpListaProcesos = new System.Windows.Forms.GroupBox();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            
            // Panel Central
            this.panelCentral = new System.Windows.Forms.Panel();
            this.grpProcesoActual = new System.Windows.Forms.GroupBox();
            this.lblProcesoActualNombre = new System.Windows.Forms.Label();
            this.progressBarProceso = new System.Windows.Forms.ProgressBar();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblTiempoTranscurrido = new System.Windows.Forms.Label();
            
            // Panel Derecho
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.grpInterrupciones = new System.Windows.Forms.GroupBox();
            this.dgvInterrupciones = new System.Windows.Forms.DataGridView();
            this.grpHistorial = new System.Windows.Forms.GroupBox();
            this.lblCantidadProcesos = new System.Windows.Forms.Label();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            
            // Timer para simulación
            this.timerSimulacion = new System.Windows.Forms.Timer(this.components);
            
            this.panelHeader.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.grpNuevoProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantum)).BeginInit();
            this.grpListaProcesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.panelCentral.SuspendLayout();
            this.grpProcesoActual.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            this.grpInterrupciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterrupciones)).BeginInit();
            this.grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.btnReiniciar);
            this.panelHeader.Controls.Add(this.btnDetenerSimulacion);
            this.panelHeader.Controls.Add(this.btnIniciarSimulacion);
            this.panelHeader.Controls.Add(this.cmbSchedulers);
            this.panelHeader.Controls.Add(this.lblPlanificador);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 80);
            this.panelHeader.TabIndex = 0;
            
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Simulador de Procesos";
            
            // 
            // lblPlanificador
            // 
            this.lblPlanificador.AutoSize = true;
            this.lblPlanificador.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPlanificador.ForeColor = System.Drawing.Color.White;
            this.lblPlanificador.Location = new System.Drawing.Point(400, 30);
            this.lblPlanificador.Name = "lblPlanificador";
            this.lblPlanificador.Size = new System.Drawing.Size(111, 23);
            this.lblPlanificador.TabIndex = 1;
            this.lblPlanificador.Text = "Planificador:";
            
            // 
            // cmbSchedulers
            // 
            this.cmbSchedulers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchedulers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSchedulers.FormattingEnabled = true;
            this.cmbSchedulers.Items.AddRange(new object[] {
            "First Come First Serve",
            "Short Job First",
            "Shortest Remaining Time First",
            "Round Robin",
            "Prioridad"});
            this.cmbSchedulers.Location = new System.Drawing.Point(520, 27);
            this.cmbSchedulers.Name = "cmbSchedulers";
            this.cmbSchedulers.Size = new System.Drawing.Size(250, 31);
            this.cmbSchedulers.TabIndex = 2;
            this.cmbSchedulers.SelectedIndexChanged += new System.EventHandler(this.cmbSchedulers_SelectedIndexChanged);
            
            // 
            // btnIniciarSimulacion
            // 
            this.btnIniciarSimulacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnIniciarSimulacion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSimulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSimulacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIniciarSimulacion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSimulacion.Location = new System.Drawing.Point(820, 20);
            this.btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            this.btnIniciarSimulacion.Size = new System.Drawing.Size(170, 40);
            this.btnIniciarSimulacion.TabIndex = 3;
            this.btnIniciarSimulacion.Text = "▶ Iniciar Simulación";
            this.btnIniciarSimulacion.UseVisualStyleBackColor = false;
            this.btnIniciarSimulacion.Click += new System.EventHandler(this.btnIniciarSimulacion_Click);
            
            // 
            // btnDetenerSimulacion
            // 
            this.btnDetenerSimulacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDetenerSimulacion.Enabled = false;
            this.btnDetenerSimulacion.FlatAppearance.BorderSize = 0;
            this.btnDetenerSimulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetenerSimulacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetenerSimulacion.ForeColor = System.Drawing.Color.White;
            this.btnDetenerSimulacion.Location = new System.Drawing.Point(1000, 20);
            this.btnDetenerSimulacion.Name = "btnDetenerSimulacion";
            this.btnDetenerSimulacion.Size = new System.Drawing.Size(170, 40);
            this.btnDetenerSimulacion.TabIndex = 4;
            this.btnDetenerSimulacion.Text = "⏸ Detener";
            this.btnDetenerSimulacion.UseVisualStyleBackColor = false;
            this.btnDetenerSimulacion.Click += new System.EventHandler(this.btnDetenerSimulacion_Click);
            
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Location = new System.Drawing.Point(1180, 20);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(170, 40);
            this.btnReiniciar.TabIndex = 5;
            this.btnReiniciar.Text = "🔄 Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.Controls.Add(this.panelIzquierdo, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panelCentral, 1, 0);
            this.tableLayoutMain.Controls.Add(this.panelDerecho, 2, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1400, 720);
            this.tableLayoutMain.TabIndex = 1;
            
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.Controls.Add(this.grpListaProcesos);
            this.panelIzquierdo.Controls.Add(this.grpNuevoProceso);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIzquierdo.Location = new System.Drawing.Point(13, 13);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(477, 694);
            this.panelIzquierdo.TabIndex = 0;
            
            // 
            // grpNuevoProceso
            // 
            this.grpNuevoProceso.Controls.Add(this.btnAgregarProceso);
            this.grpNuevoProceso.Controls.Add(this.numQuantum);
            this.grpNuevoProceso.Controls.Add(this.lblQuantum);
            this.grpNuevoProceso.Controls.Add(this.txtBurstTime);
            this.grpNuevoProceso.Controls.Add(this.lblBurstTime);
            this.grpNuevoProceso.Controls.Add(this.txtTamanoMB);
            this.grpNuevoProceso.Controls.Add(this.lblTamano);
            this.grpNuevoProceso.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNuevoProceso.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpNuevoProceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpNuevoProceso.Location = new System.Drawing.Point(0, 0);
            this.grpNuevoProceso.Name = "grpNuevoProceso";
            this.grpNuevoProceso.Padding = new System.Windows.Forms.Padding(15);
            this.grpNuevoProceso.Size = new System.Drawing.Size(477, 240);
            this.grpNuevoProceso.TabIndex = 0;
            this.grpNuevoProceso.TabStop = false;
            this.grpNuevoProceso.Text = "📝 Nuevo Proceso";
            
            // 
            // lblTamano
            // 
            this.lblTamano.AutoSize = true;
            this.lblTamano.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTamano.Location = new System.Drawing.Point(18, 40);
            this.lblTamano.Name = "lblTamano";
            this.lblTamano.Size = new System.Drawing.Size(103, 21);
            this.lblTamano.TabIndex = 0;
            this.lblTamano.Text = "Tamaño (MB):";
            
            // 
            // txtTamanoMB
            // 
            this.txtTamanoMB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTamanoMB.Location = new System.Drawing.Point(22, 64);
            this.txtTamanoMB.Name = "txtTamanoMB";
            this.txtTamanoMB.Size = new System.Drawing.Size(200, 30);
            this.txtTamanoMB.TabIndex = 1;
            
            // 
            // lblBurstTime
            // 
            this.lblBurstTime.AutoSize = true;
            this.lblBurstTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBurstTime.Location = new System.Drawing.Point(18, 105);
            this.lblBurstTime.Name = "lblBurstTime";
            this.lblBurstTime.Size = new System.Drawing.Size(89, 21);
            this.lblBurstTime.TabIndex = 2;
            this.lblBurstTime.Text = "Burst-Time:";
            
            // 
            // txtBurstTime
            // 
            this.txtBurstTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBurstTime.Location = new System.Drawing.Point(22, 129);
            this.txtBurstTime.Name = "txtBurstTime";
            this.txtBurstTime.Size = new System.Drawing.Size(200, 30);
            this.txtBurstTime.TabIndex = 3;
            
            // 
            // lblQuantum
            // 
            this.lblQuantum.AutoSize = true;
            this.lblQuantum.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblQuantum.Location = new System.Drawing.Point(250, 40);
            this.lblQuantum.Name = "lblQuantum";
            this.lblQuantum.Size = new System.Drawing.Size(79, 21);
            this.lblQuantum.TabIndex = 4;
            this.lblQuantum.Text = "Quantum:";
            this.lblQuantum.Visible = false;
            
            // 
            // numQuantum
            // 
            this.numQuantum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numQuantum.Location = new System.Drawing.Point(254, 64);
            this.numQuantum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numQuantum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantum.Name = "numQuantum";
            this.numQuantum.Size = new System.Drawing.Size(200, 30);
            this.numQuantum.TabIndex = 5;
            this.numQuantum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numQuantum.Visible = false;
            
            // 
            // btnAgregarProceso
            // 
            this.btnAgregarProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarProceso.FlatAppearance.BorderSize = 0;
            this.btnAgregarProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProceso.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProceso.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProceso.Location = new System.Drawing.Point(22, 180);
            this.btnAgregarProceso.Name = "btnAgregarProceso";
            this.btnAgregarProceso.Size = new System.Drawing.Size(432, 45);
            this.btnAgregarProceso.TabIndex = 6;
            this.btnAgregarProceso.Text = "+ Añadir Proceso";
            this.btnAgregarProceso.UseVisualStyleBackColor = false;
            this.btnAgregarProceso.Click += new System.EventHandler(this.btnAgregarProceso_Click);
            
            // 
            // grpListaProcesos
            // 
            this.grpListaProcesos.Controls.Add(this.dgvProcesos);
            this.grpListaProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpListaProcesos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpListaProcesos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpListaProcesos.Location = new System.Drawing.Point(0, 240);
            this.grpListaProcesos.Name = "grpListaProcesos";
            this.grpListaProcesos.Padding = new System.Windows.Forms.Padding(10);
            this.grpListaProcesos.Size = new System.Drawing.Size(477, 454);
            this.grpListaProcesos.TabIndex = 1;
            this.grpListaProcesos.TabStop = false;
            this.grpListaProcesos.Text = "📋 Lista de Procesos";
            
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.AllowUserToAddRows = false;
            this.dgvProcesos.AllowUserToDeleteRows = false;
            this.dgvProcesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProcesos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcesos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcesos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProcesos.ColumnHeadersHeight = 35;
            this.dgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcesos.EnableHeadersVisualStyles = false;
            this.dgvProcesos.GridColor = System.Drawing.Color.LightGray;
            this.dgvProcesos.Location = new System.Drawing.Point(10, 30);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.ReadOnly = true;
            this.dgvProcesos.RowHeadersVisible = false;
            this.dgvProcesos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProcesos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProcesos.RowTemplate.Height = 28;
            this.dgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesos.Size = new System.Drawing.Size(457, 414);
            this.dgvProcesos.TabIndex = 0;
            
            // 
            // panelCentral
            // 
            this.panelCentral.Controls.Add(this.grpProcesoActual);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(496, 13);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(477, 694);
            this.panelCentral.TabIndex = 1;
            
            // 
            // grpProcesoActual
            // 
            this.grpProcesoActual.Controls.Add(this.lblTiempoTranscurrido);
            this.grpProcesoActual.Controls.Add(this.lblPorcentaje);
            this.grpProcesoActual.Controls.Add(this.progressBarProceso);
            this.grpProcesoActual.Controls.Add(this.lblProcesoActualNombre);
            this.grpProcesoActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcesoActual.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcesoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpProcesoActual.Location = new System.Drawing.Point(0, 0);
            this.grpProcesoActual.Name = "grpProcesoActual";
            this.grpProcesoActual.Padding = new System.Windows.Forms.Padding(15);
            this.grpProcesoActual.Size = new System.Drawing.Size(477, 694);
            this.grpProcesoActual.TabIndex = 0;
            this.grpProcesoActual.TabStop = false;
            this.grpProcesoActual.Text = "⚙️ Proceso Actual";
            
            // 
            // lblProcesoActualNombre
            // 
            this.lblProcesoActualNombre.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblProcesoActualNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblProcesoActualNombre.Location = new System.Drawing.Point(18, 50);
            this.lblProcesoActualNombre.Name = "lblProcesoActualNombre";
            this.lblProcesoActualNombre.Size = new System.Drawing.Size(441, 60);
            this.lblProcesoActualNombre.TabIndex = 0;
            this.lblProcesoActualNombre.Text = "Sin proceso";
            this.lblProcesoActualNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // progressBarProceso
            // 
            this.progressBarProceso.Location = new System.Drawing.Point(18, 150);
            this.progressBarProceso.Name = "progressBarProceso";
            this.progressBarProceso.Size = new System.Drawing.Size(441, 40);
            this.progressBarProceso.TabIndex = 1;
            
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPorcentaje.Location = new System.Drawing.Point(18, 210);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(441, 80);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // lblTiempoTranscurrido
            // 
            this.lblTiempoTranscurrido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTiempoTranscurrido.ForeColor = System.Drawing.Color.Gray;
            this.lblTiempoTranscurrido.Location = new System.Drawing.Point(18, 310);
            this.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            this.lblTiempoTranscurrido.Size = new System.Drawing.Size(441, 30);
            this.lblTiempoTranscurrido.TabIndex = 3;
            this.lblTiempoTranscurrido.Text = "Tiempo transcurrido: 0 unidades";
            this.lblTiempoTranscurrido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // panelDerecho
            // 
            this.panelDerecho.Controls.Add(this.grpHistorial);
            this.panelDerecho.Controls.Add(this.grpInterrupciones);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(979, 13);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(408, 694);
            this.panelDerecho.TabIndex = 2;
            
            // 
            // grpInterrupciones
            // 
            this.grpInterrupciones.Controls.Add(this.dgvInterrupciones);
            this.grpInterrupciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInterrupciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpInterrupciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpInterrupciones.Location = new System.Drawing.Point(0, 0);
            this.grpInterrupciones.Name = "grpInterrupciones";
            this.grpInterrupciones.Padding = new System.Windows.Forms.Padding(10);
            this.grpInterrupciones.Size = new System.Drawing.Size(408, 300);
            this.grpInterrupciones.TabIndex = 0;
            this.grpInterrupciones.TabStop = false;
            this.grpInterrupciones.Text = "⚠️ Interrupciones";
            
            // 
            // dgvInterrupciones
            // 
            this.dgvInterrupciones.AllowUserToAddRows = false;
            this.dgvInterrupciones.AllowUserToDeleteRows = false;
            this.dgvInterrupciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterrupciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvInterrupciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInterrupciones.ColumnHeadersHeight = 30;
            this.dgvInterrupciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInterrupciones.Location = new System.Drawing.Point(10, 30);
            this.dgvInterrupciones.Name = "dgvInterrupciones";
            this.dgvInterrupciones.ReadOnly = true;
            this.dgvInterrupciones.RowHeadersVisible = false;
            this.dgvInterrupciones.RowHeadersWidth = 51;
            this.dgvInterrupciones.RowTemplate.Height = 26;
            this.dgvInterrupciones.Size = new System.Drawing.Size(388, 260);
            this.dgvInterrupciones.TabIndex = 0;
            
            // 
            // grpHistorial
            // 
            this.grpHistorial.Controls.Add(this.dgvHistorial);
            this.grpHistorial.Controls.Add(this.lblTiempoTotal);
            this.grpHistorial.Controls.Add(this.lblCantidadProcesos);
            this.grpHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpHistorial.Location = new System.Drawing.Point(0, 300);
            this.grpHistorial.Name = "grpHistorial";
            this.grpHistorial.Padding = new System.Windows.Forms.Padding(10);
            this.grpHistorial.Size = new System.Drawing.Size(408, 394);
            this.grpHistorial.TabIndex = 1;
            this.grpHistorial.TabStop = false;
            this.grpHistorial.Text = "✅ Historial de Procesos";
            
            // 
            // lblCantidadProcesos
            // 
            this.lblCantidadProcesos.AutoSize = true;
            this.lblCantidadProcesos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCantidadProcesos.Location = new System.Drawing.Point(13, 35);
            this.lblCantidadProcesos.Name = "lblCantidadProcesos";
            this.lblCantidadProcesos.Size = new System.Drawing.Size(204, 23);
            this.lblCantidadProcesos.TabIndex = 0;
            this.lblCantidadProcesos.Text = "Procesos terminados: 0";
            
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTiempoTotal.Location = new System.Drawing.Point(13, 60);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(148, 23);
            this.lblTiempoTotal.TabIndex = 1;
            this.lblTiempoTotal.Text = "Tiempo total: 0";
            
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeight = 30;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHistorial.Location = new System.Drawing.Point(10, 100);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.RowTemplate.Height = 26;
            this.dgvHistorial.Size = new System.Drawing.Size(388, 284);
            this.dgvHistorial.TabIndex = 2;
            
            // 
            // timerSimulacion
            // 
            this.timerSimulacion.Interval = 500;
            this.timerSimulacion.Tick += new System.EventHandler(this.timerSimulacion_Tick);
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de Sistema Operativo - Planificador de Procesos";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            this.grpNuevoProceso.ResumeLayout(false);
            this.grpNuevoProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantum)).EndInit();
            this.grpListaProcesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.panelCentral.ResumeLayout(false);
            this.grpProcesoActual.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            this.grpInterrupciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterrupciones)).EndInit();
            this.grpHistorial.ResumeLayout(false);
            this.grpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPlanificador;
        private System.Windows.Forms.ComboBox cmbSchedulers;
        private System.Windows.Forms.Button btnIniciarSimulacion;
        private System.Windows.Forms.Button btnDetenerSimulacion;
        private System.Windows.Forms.Button btnReiniciar;
        
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.GroupBox grpNuevoProceso;
        private System.Windows.Forms.Label lblTamano;
        private System.Windows.Forms.TextBox txtTamanoMB;
        private System.Windows.Forms.Label lblBurstTime;
        private System.Windows.Forms.TextBox txtBurstTime;
        private System.Windows.Forms.Label lblQuantum;
        private System.Windows.Forms.NumericUpDown numQuantum;
        private System.Windows.Forms.Button btnAgregarProceso;
        private System.Windows.Forms.GroupBox grpListaProcesos;
        private System.Windows.Forms.DataGridView dgvProcesos;
        
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.GroupBox grpProcesoActual;
        private System.Windows.Forms.Label lblProcesoActualNombre;
        private System.Windows.Forms.ProgressBar progressBarProceso;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblTiempoTranscurrido;
        
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.GroupBox grpInterrupciones;
        private System.Windows.Forms.DataGridView dgvInterrupciones;
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.Label lblCantidadProcesos;
        private System.Windows.Forms.Label lblTiempoTotal;
        private System.Windows.Forms.DataGridView dgvHistorial;
        
        private System.Windows.Forms.Timer timerSimulacion;
    }
}

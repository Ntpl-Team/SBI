﻿namespace ImageHeaven
{
    partial class frmExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdSave = new System.Windows.Forms.Button();
            this.dgvbatch = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.dgvImagePath = new System.Windows.Forms.DataGridView();
            this.dgvexport = new System.Windows.Forms.DataGridView();
            this.dgvKhatian = new System.Windows.Forms.DataGridView();
            this.dgvPlot = new System.Windows.Forms.DataGridView();
            this.lvwExportList = new System.Windows.Forms.ListView();
            this.SLNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Deed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.dgvdeedDetails = new System.Windows.Forms.DataGridView();
            this.tblExp = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBatchSelected = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFinalStatus = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.cmdValidatefiles = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblvolStatus = new System.Windows.Forms.Label();
            this.lblTotSta = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lbldeedCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImagePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvexport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhatian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeedDetails)).BeginInit();
            this.tblExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(632, 53);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(83, 108);
            this.dataGridView1.TabIndex = 76;
            this.dataGridView1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdSave);
            this.tabPage1.Controls.Add(this.dgvbatch);
            this.tabPage1.Controls.Add(this.txtMsg);
            this.tabPage1.Controls.Add(this.dgvImagePath);
            this.tabPage1.Controls.Add(this.dgvexport);
            this.tabPage1.Controls.Add(this.dgvKhatian);
            this.tabPage1.Controls.Add(this.dgvPlot);
            this.tabPage1.Controls.Add(this.lvwExportList);
            this.tabPage1.Controls.Add(this.cmdExport);
            this.tabPage1.Controls.Add(this.cmdValidate);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(593, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Name";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Location = new System.Drawing.Point(769, 302);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 28);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "Save List";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            // 
            // dgvbatch
            // 
            this.dgvbatch.AllowUserToAddRows = false;
            this.dgvbatch.AllowUserToDeleteRows = false;
            this.dgvbatch.AllowUserToResizeColumns = false;
            this.dgvbatch.AllowUserToResizeRows = false;
            this.dgvbatch.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvbatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbatch.ColumnHeadersVisible = false;
            this.dgvbatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvbatch.Location = new System.Drawing.Point(12, 20);
            this.dgvbatch.Margin = new System.Windows.Forms.Padding(4);
            this.dgvbatch.Name = "dgvbatch";
            this.dgvbatch.RowHeadersVisible = false;
            this.dgvbatch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvbatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbatch.Size = new System.Drawing.Size(259, 314);
            this.dgvbatch.TabIndex = 5;
            this.dgvbatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbatch_CellClick);
            this.dgvbatch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbatch_CellContentClick);
            this.dgvbatch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbatch_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.LightGray;
            this.txtMsg.Location = new System.Drawing.Point(595, 20);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(301, 309);
            this.txtMsg.TabIndex = 1;
            this.txtMsg.Visible = false;
            // 
            // dgvImagePath
            // 
            this.dgvImagePath.AllowUserToAddRows = false;
            this.dgvImagePath.AllowUserToDeleteRows = false;
            this.dgvImagePath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImagePath.Location = new System.Drawing.Point(-15, 27);
            this.dgvImagePath.Margin = new System.Windows.Forms.Padding(4);
            this.dgvImagePath.Name = "dgvImagePath";
            this.dgvImagePath.ReadOnly = true;
            this.dgvImagePath.Size = new System.Drawing.Size(17, 27);
            this.dgvImagePath.TabIndex = 11;
            this.dgvImagePath.Visible = false;
            // 
            // dgvexport
            // 
            this.dgvexport.AllowUserToAddRows = false;
            this.dgvexport.AllowUserToDeleteRows = false;
            this.dgvexport.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvexport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvexport.Location = new System.Drawing.Point(279, 18);
            this.dgvexport.Margin = new System.Windows.Forms.Padding(4);
            this.dgvexport.Name = "dgvexport";
            this.dgvexport.RowHeadersVisible = false;
            this.dgvexport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvexport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvexport.Size = new System.Drawing.Size(308, 315);
            this.dgvexport.TabIndex = 8;
            // 
            // dgvKhatian
            // 
            this.dgvKhatian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhatian.Location = new System.Drawing.Point(211, 219);
            this.dgvKhatian.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKhatian.Name = "dgvKhatian";
            this.dgvKhatian.Size = new System.Drawing.Size(96, 69);
            this.dgvKhatian.TabIndex = 10;
            this.dgvKhatian.Visible = false;
            // 
            // dgvPlot
            // 
            this.dgvPlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlot.Location = new System.Drawing.Point(43, 219);
            this.dgvPlot.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPlot.Name = "dgvPlot";
            this.dgvPlot.Size = new System.Drawing.Size(96, 69);
            this.dgvPlot.TabIndex = 9;
            this.dgvPlot.Visible = false;
            // 
            // lvwExportList
            // 
            this.lvwExportList.CheckBoxes = true;
            this.lvwExportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SLNo,
            this.Deed});
            this.lvwExportList.FullRowSelect = true;
            this.lvwExportList.GridLines = true;
            this.lvwExportList.HideSelection = false;
            this.lvwExportList.Location = new System.Drawing.Point(11, 18);
            this.lvwExportList.Margin = new System.Windows.Forms.Padding(4);
            this.lvwExportList.Name = "lvwExportList";
            this.lvwExportList.Size = new System.Drawing.Size(381, 314);
            this.lvwExportList.TabIndex = 7;
            this.lvwExportList.UseCompatibleStateImageBehavior = false;
            this.lvwExportList.View = System.Windows.Forms.View.Details;
            this.lvwExportList.Visible = false;
            // 
            // SLNo
            // 
            this.SLNo.Text = "SL No";
            // 
            // Deed
            // 
            this.Deed.Text = "Deed No";
            this.Deed.Width = 223;
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(77, 260);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(100, 28);
            this.cmdExport.TabIndex = 2;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Visible = false;
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(236, 260);
            this.cmdValidate.Margin = new System.Windows.Forms.Padding(4);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(131, 28);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.Text = "Validate Image";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Visible = false;
            // 
            // dgvdeedDetails
            // 
            this.dgvdeedDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdeedDetails.Location = new System.Drawing.Point(629, 28);
            this.dgvdeedDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvdeedDetails.Name = "dgvdeedDetails";
            this.dgvdeedDetails.Size = new System.Drawing.Size(11, 10);
            this.dgvdeedDetails.TabIndex = 56;
            this.dgvdeedDetails.Visible = false;
            // 
            // tblExp
            // 
            this.tblExp.Controls.Add(this.tabPage1);
            this.tblExp.Controls.Add(this.tabPage2);
            this.tblExp.Location = new System.Drawing.Point(1, 116);
            this.tblExp.Margin = new System.Windows.Forms.Padding(4);
            this.tblExp.Name = "tblExp";
            this.tblExp.SelectedIndex = 0;
            this.tblExp.Size = new System.Drawing.Size(601, 390);
            this.tblExp.TabIndex = 79;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(593, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(679, 7);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(83, 81);
            this.dataGridView3.TabIndex = 78;
            this.dataGridView3.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(651, 78);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(83, 55);
            this.dataGridView2.TabIndex = 77;
            this.dataGridView2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdBrowse);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.dgvdeedDetails);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(597, 98);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Image Source";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowse.Location = new System.Drawing.Point(543, 34);
            this.cmdBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(41, 28);
            this.cmdBrowse.TabIndex = 58;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(131, 36);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(397, 25);
            this.txtPath.TabIndex = 57;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(111, 578);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(485, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 80;
            // 
            // lblBatchSelected
            // 
            this.lblBatchSelected.AutoSize = true;
            this.lblBatchSelected.Location = new System.Drawing.Point(191, 521);
            this.lblBatchSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatchSelected.Name = "lblBatchSelected";
            this.lblBatchSelected.Size = new System.Drawing.Size(17, 16);
            this.lblBatchSelected.TabIndex = 91;
            this.lblBatchSelected.Text = "...";
            this.lblBatchSelected.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 521);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 90;
            this.label6.Text = "Selected: ";
            this.label6.Visible = false;
            // 
            // lblFinalStatus
            // 
            this.lblFinalStatus.AutoSize = true;
            this.lblFinalStatus.Location = new System.Drawing.Point(120, 614);
            this.lblFinalStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinalStatus.Name = "lblFinalStatus";
            this.lblFinalStatus.Size = new System.Drawing.Size(17, 16);
            this.lblFinalStatus.TabIndex = 89;
            this.lblFinalStatus.Text = "...";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(121, 556);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(17, 16);
            this.lbl.TabIndex = 88;
            this.lbl.Text = "...";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.cmdValidatefiles);
            this.grpControl.Controls.Add(this.btnExport);
            this.grpControl.Controls.Add(this.cmdCancel);
            this.grpControl.Location = new System.Drawing.Point(285, 508);
            this.grpControl.Margin = new System.Windows.Forms.Padding(4);
            this.grpControl.Name = "grpControl";
            this.grpControl.Padding = new System.Windows.Forms.Padding(4);
            this.grpControl.Size = new System.Drawing.Size(309, 48);
            this.grpControl.TabIndex = 87;
            this.grpControl.TabStop = false;
            // 
            // cmdValidatefiles
            // 
            this.cmdValidatefiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidatefiles.Location = new System.Drawing.Point(8, 12);
            this.cmdValidatefiles.Margin = new System.Windows.Forms.Padding(4);
            this.cmdValidatefiles.Name = "cmdValidatefiles";
            this.cmdValidatefiles.Size = new System.Drawing.Size(81, 28);
            this.cmdValidatefiles.TabIndex = 9;
            this.cmdValidatefiles.Text = "&Validate";
            this.cmdValidatefiles.UseVisualStyleBackColor = true;
            this.cmdValidatefiles.Click += new System.EventHandler(this.cmdValidatefiles_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(105, 12);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 28);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(203, 12);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 28);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "&Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblvolStatus
            // 
            this.lblvolStatus.AutoSize = true;
            this.lblvolStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvolStatus.Location = new System.Drawing.Point(24, 586);
            this.lblvolStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblvolStatus.Name = "lblvolStatus";
            this.lblvolStatus.Size = new System.Drawing.Size(60, 13);
            this.lblvolStatus.TabIndex = 86;
            this.lblvolStatus.Text = "Doc Status";
            // 
            // lblTotSta
            // 
            this.lblTotSta.AutoSize = true;
            this.lblTotSta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotSta.Location = new System.Drawing.Point(5, 635);
            this.lblTotSta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotSta.Name = "lblTotSta";
            this.lblTotSta.Size = new System.Drawing.Size(70, 13);
            this.lblTotSta.TabIndex = 85;
            this.lblTotSta.Text = "Export Status";
            // 
            // progressBar2
            // 
            this.progressBar2.ForeColor = System.Drawing.Color.Lime;
            this.progressBar2.Location = new System.Drawing.Point(111, 635);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(485, 28);
            this.progressBar2.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(257, 537);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 83;
            this.label5.Visible = false;
            // 
            // lbldeedCount
            // 
            this.lbldeedCount.AutoSize = true;
            this.lbldeedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeedCount.Location = new System.Drawing.Point(59, 518);
            this.lbldeedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldeedCount.Name = "lbldeedCount";
            this.lbldeedCount.Size = new System.Drawing.Size(23, 15);
            this.lbldeedCount.TabIndex = 82;
            this.lbldeedCount.Text = "....";
            this.lbldeedCount.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 519);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Total:";
            this.label3.Visible = false;
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 670);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tblExp);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblBatchSelected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFinalStatus);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.lblvolStatus);
            this.Controls.Add(this.lblTotSta);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbldeedCount);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImagePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvexport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhatian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeedDetails)).EndInit();
            this.tblExp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView dgvbatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.DataGridView dgvImagePath;
        private System.Windows.Forms.DataGridView dgvexport;
        private System.Windows.Forms.DataGridView dgvKhatian;
        private System.Windows.Forms.DataGridView dgvPlot;
        private System.Windows.Forms.ListView lvwExportList;
        private System.Windows.Forms.ColumnHeader SLNo;
        private System.Windows.Forms.ColumnHeader Deed;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.DataGridView dgvdeedDetails;
        private System.Windows.Forms.TabControl tblExp;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblBatchSelected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFinalStatus;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button cmdValidatefiles;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblvolStatus;
        private System.Windows.Forms.Label lblTotSta;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbldeedCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
    }
}
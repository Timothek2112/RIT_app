namespace RITAutomation
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.sourceCbx = new System.Windows.Forms.ComboBox();
            this.sourceLbl = new System.Windows.Forms.Label();
            this.markerGb = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.idTb = new System.Windows.Forms.TextBox();
            this.idLbl = new System.Windows.Forms.Label();
            this.fieldGb = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceTypeCb = new System.Windows.Forms.ComboBox();
            this.sourceTb = new System.Windows.Forms.TextBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.markerGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(-1, -1);
            this.Map.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 2;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(1069, 556);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            this.Map.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl1_OnMarkerEnter);
            this.Map.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gMapControl1_OnMarkerLeave);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDown);
            this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseMove);
            this.Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseUp);
            // 
            // sourceCbx
            // 
            this.sourceCbx.FormattingEnabled = true;
            this.sourceCbx.Items.AddRange(new object[] {
            "Приемник",
            "Вручную"});
            this.sourceCbx.Location = new System.Drawing.Point(76, 93);
            this.sourceCbx.Name = "sourceCbx";
            this.sourceCbx.Size = new System.Drawing.Size(168, 24);
            this.sourceCbx.TabIndex = 2;
            this.sourceCbx.SelectedIndexChanged += new System.EventHandler(this.sourceCbx_SelectedIndexChanged);
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Location = new System.Drawing.Point(17, 96);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(53, 16);
            this.sourceLbl.TabIndex = 3;
            this.sourceLbl.Text = "Режим:";
            this.sourceLbl.Click += new System.EventHandler(this.sourceLbl_Click);
            // 
            // markerGb
            // 
            this.markerGb.Controls.Add(this.acceptBtn);
            this.markerGb.Controls.Add(this.label3);
            this.markerGb.Controls.Add(this.sourceTb);
            this.markerGb.Controls.Add(this.idTb);
            this.markerGb.Controls.Add(this.sourceTypeCb);
            this.markerGb.Controls.Add(this.idLbl);
            this.markerGb.Controls.Add(this.sourceLbl);
            this.markerGb.Controls.Add(this.label2);
            this.markerGb.Controls.Add(this.nameTb);
            this.markerGb.Controls.Add(this.sourceCbx);
            this.markerGb.Controls.Add(this.label1);
            this.markerGb.Location = new System.Drawing.Point(1079, 12);
            this.markerGb.Name = "markerGb";
            this.markerGb.Size = new System.Drawing.Size(270, 503);
            this.markerGb.TabIndex = 4;
            this.markerGb.TabStop = false;
            this.markerGb.Text = "Настройки маркера";
            this.markerGb.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя:";
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(69, 61);
            this.nameTb.Name = "nameTb";
            this.nameTb.ReadOnly = true;
            this.nameTb.Size = new System.Drawing.Size(175, 22);
            this.nameTb.TabIndex = 1;
            // 
            // idTb
            // 
            this.idTb.Location = new System.Drawing.Point(69, 32);
            this.idTb.Name = "idTb";
            this.idTb.ReadOnly = true;
            this.idTb.Size = new System.Drawing.Size(175, 22);
            this.idTb.TabIndex = 3;
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(17, 35);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(23, 16);
            this.idLbl.TabIndex = 2;
            this.idLbl.Text = "ID:";
            // 
            // fieldGb
            // 
            this.fieldGb.Location = new System.Drawing.Point(650, 52);
            this.fieldGb.Name = "fieldGb";
            this.fieldGb.Size = new System.Drawing.Size(270, 503);
            this.fieldGb.TabIndex = 5;
            this.fieldGb.TabStop = false;
            this.fieldGb.Text = "Настройки области";
            this.fieldGb.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Вид источника:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Источник:";
            // 
            // sourceTypeCb
            // 
            this.sourceTypeCb.FormattingEnabled = true;
            this.sourceTypeCb.Items.AddRange(new object[] {
            "Приемник",
            "Вручную"});
            this.sourceTypeCb.Location = new System.Drawing.Point(130, 127);
            this.sourceTypeCb.Name = "sourceTypeCb";
            this.sourceTypeCb.Size = new System.Drawing.Size(114, 24);
            this.sourceTypeCb.TabIndex = 8;
            this.sourceTypeCb.SelectedIndexChanged += new System.EventHandler(this.sourceTypeCb_SelectedIndexChanged);
            // 
            // sourceTb
            // 
            this.sourceTb.Location = new System.Drawing.Point(96, 163);
            this.sourceTb.Name = "sourceTb";
            this.sourceTb.Size = new System.Drawing.Size(148, 22);
            this.sourceTb.TabIndex = 9;
            this.sourceTb.TextChanged += new System.EventHandler(this.sourceTb_TextChanged);
            this.sourceTb.Leave += new System.EventHandler(this.sourceTb_Leave);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Enabled = false;
            this.acceptBtn.Location = new System.Drawing.Point(20, 211);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(99, 23);
            this.acceptBtn.TabIndex = 0;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 554);
            this.Controls.Add(this.markerGb);
            this.Controls.Add(this.fieldGb);
            this.Controls.Add(this.Map);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "Карта";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.markerGb.ResumeLayout(false);
            this.markerGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.ComboBox sourceCbx;
        private System.Windows.Forms.Label sourceLbl;
        private System.Windows.Forms.GroupBox markerGb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTb;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.GroupBox fieldGb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sourceTb;
        private System.Windows.Forms.ComboBox sourceTypeCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acceptBtn;
    }
}


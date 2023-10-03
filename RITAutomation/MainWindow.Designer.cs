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
            this.acceptBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceTb = new System.Windows.Forms.TextBox();
            this.idTb = new System.Windows.Forms.TextBox();
            this.sourceTypeCb = new System.Windows.Forms.ComboBox();
            this.idLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldGb = new System.Windows.Forms.GroupBox();
            this.sendMessageGb = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.changeColorGb = new System.Windows.Forms.GroupBox();
            this.colorChangePickerCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commandLbl = new System.Windows.Forms.Label();
            this.commandPolygonCb = new System.Windows.Forms.ComboBox();
            this.markerGb.SuspendLayout();
            this.fieldGb.SuspendLayout();
            this.sendMessageGb.SuspendLayout();
            this.changeColorGb.SuspendLayout();
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
            this.Map.Margin = new System.Windows.Forms.Padding(4);
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
            this.Map.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.Map_OnPolygonClick);
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
            this.sourceCbx.Location = new System.Drawing.Point(74, 93);
            this.sourceCbx.Name = "sourceCbx";
            this.sourceCbx.Size = new System.Drawing.Size(168, 24);
            this.sourceCbx.TabIndex = 2;
            this.sourceCbx.SelectedIndexChanged += new System.EventHandler(this.sourceCbx_SelectedIndexChanged);
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Location = new System.Drawing.Point(15, 96);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(53, 16);
            this.sourceLbl.TabIndex = 3;
            this.sourceLbl.Text = "Режим:";
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
            this.markerGb.Size = new System.Drawing.Size(270, 468);
            this.markerGb.TabIndex = 4;
            this.markerGb.TabStop = false;
            this.markerGb.Text = "Настройки маркера";
            this.markerGb.Visible = false;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Enabled = false;
            this.acceptBtn.Location = new System.Drawing.Point(18, 203);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(99, 23);
            this.acceptBtn.TabIndex = 0;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Источник:";
            // 
            // sourceTb
            // 
            this.sourceTb.Location = new System.Drawing.Point(94, 163);
            this.sourceTb.Name = "sourceTb";
            this.sourceTb.Size = new System.Drawing.Size(148, 22);
            this.sourceTb.TabIndex = 9;
            this.sourceTb.TextChanged += new System.EventHandler(this.sourceTb_TextChanged);
            // 
            // idTb
            // 
            this.idTb.Location = new System.Drawing.Point(69, 32);
            this.idTb.Name = "idTb";
            this.idTb.ReadOnly = true;
            this.idTb.Size = new System.Drawing.Size(175, 22);
            this.idTb.TabIndex = 3;
            // 
            // sourceTypeCb
            // 
            this.sourceTypeCb.FormattingEnabled = true;
            this.sourceTypeCb.Items.AddRange(new object[] {
            "Приемник",
            "Вручную"});
            this.sourceTypeCb.Location = new System.Drawing.Point(128, 127);
            this.sourceTypeCb.Name = "sourceTypeCb";
            this.sourceTypeCb.Size = new System.Drawing.Size(114, 24);
            this.sourceTypeCb.TabIndex = 8;
            this.sourceTypeCb.SelectedIndexChanged += new System.EventHandler(this.sourceTypeCb_SelectedIndexChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Вид источника:";
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(69, 61);
            this.nameTb.Name = "nameTb";
            this.nameTb.ReadOnly = true;
            this.nameTb.Size = new System.Drawing.Size(175, 22);
            this.nameTb.TabIndex = 1;
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
            // fieldGb
            // 
            this.fieldGb.Controls.Add(this.sendMessageGb);
            this.fieldGb.Controls.Add(this.changeColorGb);
            this.fieldGb.Controls.Add(this.commandLbl);
            this.fieldGb.Controls.Add(this.commandPolygonCb);
            this.fieldGb.Location = new System.Drawing.Point(1079, 12);
            this.fieldGb.Name = "fieldGb";
            this.fieldGb.Size = new System.Drawing.Size(270, 468);
            this.fieldGb.TabIndex = 5;
            this.fieldGb.TabStop = false;
            this.fieldGb.Text = "Настройки области";
            this.fieldGb.Visible = false;
            // 
            // sendMessageGb
            // 
            this.sendMessageGb.Controls.Add(this.textBox1);
            this.sendMessageGb.Controls.Add(this.label5);
            this.sendMessageGb.Location = new System.Drawing.Point(9, 83);
            this.sendMessageGb.Name = "sendMessageGb";
            this.sendMessageGb.Size = new System.Drawing.Size(235, 137);
            this.sendMessageGb.TabIndex = 3;
            this.sendMessageGb.TabStop = false;
            this.sendMessageGb.Text = "Вывод сообщения";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 76);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Сообщение:";
            // 
            // changeColorGb
            // 
            this.changeColorGb.Controls.Add(this.colorChangePickerCb);
            this.changeColorGb.Controls.Add(this.label4);
            this.changeColorGb.Location = new System.Drawing.Point(9, 83);
            this.changeColorGb.Name = "changeColorGb";
            this.changeColorGb.Size = new System.Drawing.Size(235, 68);
            this.changeColorGb.TabIndex = 2;
            this.changeColorGb.TabStop = false;
            this.changeColorGb.Text = "Изменение цвета";
            // 
            // colorChangePickerCb
            // 
            this.colorChangePickerCb.FormattingEnabled = true;
            this.colorChangePickerCb.Location = new System.Drawing.Point(68, 25);
            this.colorChangePickerCb.Name = "colorChangePickerCb";
            this.colorChangePickerCb.Size = new System.Drawing.Size(148, 24);
            this.colorChangePickerCb.TabIndex = 1;
            this.colorChangePickerCb.SelectedIndexChanged += new System.EventHandler(this.colorChangePickerCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Цвет:";
            // 
            // commandLbl
            // 
            this.commandLbl.AutoSize = true;
            this.commandLbl.Location = new System.Drawing.Point(6, 30);
            this.commandLbl.Name = "commandLbl";
            this.commandLbl.Size = new System.Drawing.Size(73, 16);
            this.commandLbl.TabIndex = 1;
            this.commandLbl.Text = "Действие:";
            // 
            // commandPolygonCb
            // 
            this.commandPolygonCb.FormattingEnabled = true;
            this.commandPolygonCb.Location = new System.Drawing.Point(85, 27);
            this.commandPolygonCb.Name = "commandPolygonCb";
            this.commandPolygonCb.Size = new System.Drawing.Size(159, 24);
            this.commandPolygonCb.TabIndex = 0;
            this.commandPolygonCb.SelectedIndexChanged += new System.EventHandler(this.commandPolygonCb_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 554);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.markerGb);
            this.Controls.Add(this.fieldGb);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Карта";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.markerGb.ResumeLayout(false);
            this.markerGb.PerformLayout();
            this.fieldGb.ResumeLayout(false);
            this.fieldGb.PerformLayout();
            this.sendMessageGb.ResumeLayout(false);
            this.sendMessageGb.PerformLayout();
            this.changeColorGb.ResumeLayout(false);
            this.changeColorGb.PerformLayout();
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
        private System.Windows.Forms.Label commandLbl;
        private System.Windows.Forms.ComboBox commandPolygonCb;
        private System.Windows.Forms.GroupBox changeColorGb;
        private System.Windows.Forms.GroupBox sendMessageGb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox colorChangePickerCb;
        private System.Windows.Forms.Label label4;
    }
}


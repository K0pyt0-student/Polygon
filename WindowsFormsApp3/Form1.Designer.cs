﻿namespace WindowsFormsApp3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPerfJarvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PointsCounter = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.startShaking_button = new System.Windows.Forms.Button();
            this.stopShaking_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.Redo_button = new System.Windows.Forms.Button();
            this.Undo_button = new System.Windows.Forms.Button();
            this.ActionsCounter = new System.Windows.Forms.Label();
            this.DeletedPointsCounter = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.формаToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.methodToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newFile_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAs_Click);
            // 
            // формаToolStripMenuItem
            // 
            this.формаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.формаToolStripMenuItem.Name = "формаToolStripMenuItem";
            this.формаToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.формаToolStripMenuItem.Text = "Shape";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.circleToolStripMenuItem_CheckedChanged);
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.CheckedChanged += new System.EventHandler(this.squareToolStripMenuItem_CheckedChanged);
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.triangleToolStripMenuItem_CheckedChanged);
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radiusToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.settingsToolStripMenuItem.Text = "Figure settings";
            // 
            // radiusToolStripMenuItem
            // 
            this.radiusToolStripMenuItem.Name = "radiusToolStripMenuItem";
            this.radiusToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.radiusToolStripMenuItem.Text = "Radius";
            this.radiusToolStripMenuItem.Click += new System.EventHandler(this.radiusToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // methodToolStripMenuItem
            // 
            this.methodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byDefinitionToolStripMenuItem,
            this.jarvisToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.checkPerfJarvToolStripMenuItem});
            this.methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            this.methodToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.methodToolStripMenuItem.Text = "Method";
            // 
            // byDefinitionToolStripMenuItem
            // 
            this.byDefinitionToolStripMenuItem.Name = "byDefinitionToolStripMenuItem";
            this.byDefinitionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.byDefinitionToolStripMenuItem.Text = "By Definition";
            this.byDefinitionToolStripMenuItem.Click += new System.EventHandler(this.byDefinitionToolStripMenuItem_Click);
            // 
            // jarvisToolStripMenuItem
            // 
            this.jarvisToolStripMenuItem.Name = "jarvisToolStripMenuItem";
            this.jarvisToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.jarvisToolStripMenuItem.Text = "Jarvis";
            this.jarvisToolStripMenuItem.Click += new System.EventHandler(this.jarvisToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.compareToolStripMenuItem.Text = "Check perfomance both";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // checkPerfJarvToolStripMenuItem
            // 
            this.checkPerfJarvToolStripMenuItem.Name = "checkPerfJarvToolStripMenuItem";
            this.checkPerfJarvToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.checkPerfJarvToolStripMenuItem.Text = "Check perfomance jarv";
            this.checkPerfJarvToolStripMenuItem.Click += new System.EventHandler(this.checkPerfJarvToolStripMenuItem_Click);
            // 
            // PointsCounter
            // 
            this.PointsCounter.AutoSize = true;
            this.PointsCounter.Location = new System.Drawing.Point(1016, 9);
            this.PointsCounter.Name = "PointsCounter";
            this.PointsCounter.Size = new System.Drawing.Size(13, 13);
            this.PointsCounter.TabIndex = 2;
            this.PointsCounter.Text = "0";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // startShaking_button
            // 
            this.startShaking_button.Image = ((System.Drawing.Image)(resources.GetObject("startShaking_button.Image")));
            this.startShaking_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.startShaking_button.Location = new System.Drawing.Point(12, 27);
            this.startShaking_button.Name = "startShaking_button";
            this.startShaking_button.Size = new System.Drawing.Size(52, 52);
            this.startShaking_button.TabIndex = 3;
            this.startShaking_button.UseVisualStyleBackColor = true;
            this.startShaking_button.Click += new System.EventHandler(this.startShaking_button_Click);
            // 
            // stopShaking_button
            // 
            this.stopShaking_button.Image = ((System.Drawing.Image)(resources.GetObject("stopShaking_button.Image")));
            this.stopShaking_button.Location = new System.Drawing.Point(70, 27);
            this.stopShaking_button.Name = "stopShaking_button";
            this.stopShaking_button.Size = new System.Drawing.Size(52, 52);
            this.stopShaking_button.TabIndex = 4;
            this.stopShaking_button.UseVisualStyleBackColor = true;
            this.stopShaking_button.Click += new System.EventHandler(this.stopShaking_button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Redo_button
            // 
            this.Redo_button.Image = ((System.Drawing.Image)(resources.GetObject("Redo_button.Image")));
            this.Redo_button.Location = new System.Drawing.Point(208, 27);
            this.Redo_button.Name = "Redo_button";
            this.Redo_button.Size = new System.Drawing.Size(52, 52);
            this.Redo_button.TabIndex = 6;
            this.Redo_button.UseVisualStyleBackColor = true;
            this.Redo_button.Click += new System.EventHandler(this.Redo_button_Click);
            // 
            // Undo_button
            // 
            this.Undo_button.Image = ((System.Drawing.Image)(resources.GetObject("Undo_button.Image")));
            this.Undo_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Undo_button.Location = new System.Drawing.Point(150, 27);
            this.Undo_button.Name = "Undo_button";
            this.Undo_button.Size = new System.Drawing.Size(52, 52);
            this.Undo_button.TabIndex = 5;
            this.Undo_button.UseVisualStyleBackColor = true;
            this.Undo_button.Click += new System.EventHandler(this.Undo_button_Click);
            // 
            // ActionsCounter
            // 
            this.ActionsCounter.AutoSize = true;
            this.ActionsCounter.Location = new System.Drawing.Point(947, 10);
            this.ActionsCounter.Name = "ActionsCounter";
            this.ActionsCounter.Size = new System.Drawing.Size(13, 13);
            this.ActionsCounter.TabIndex = 7;
            this.ActionsCounter.Text = "0";
            // 
            // DeletedPointsCounter
            // 
            this.DeletedPointsCounter.AutoSize = true;
            this.DeletedPointsCounter.Location = new System.Drawing.Point(882, 10);
            this.DeletedPointsCounter.Name = "DeletedPointsCounter";
            this.DeletedPointsCounter.Size = new System.Drawing.Size(0, 13);
            this.DeletedPointsCounter.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 757);
            this.Controls.Add(this.DeletedPointsCounter);
            this.Controls.Add(this.ActionsCounter);
            this.Controls.Add(this.Redo_button);
            this.Controls.Add(this.Undo_button);
            this.Controls.Add(this.stopShaking_button);
            this.Controls.Add(this.startShaking_button);
            this.Controls.Add(this.PointsCounter);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem формаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.Label PointsCounter;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkPerfJarvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.Button startShaking_button;
        private System.Windows.Forms.Button stopShaking_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button Redo_button;
        private System.Windows.Forms.Button Undo_button;
        private System.Windows.Forms.Label ActionsCounter;
        private System.Windows.Forms.Label DeletedPointsCounter;
    }
}


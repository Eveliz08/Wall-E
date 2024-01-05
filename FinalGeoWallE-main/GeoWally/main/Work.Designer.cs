namespace Geo_Wall_E
{
    partial class Work
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Work));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Compile = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.saveFileArchive = new System.Windows.Forms.SaveFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.Right = new System.Windows.Forms.PictureBox();
            this.Down = new System.Windows.Forms.PictureBox();
            this.Left = new System.Windows.Forms.PictureBox();
            this.Up = new System.Windows.Forms.PictureBox();
            this.lienzo = new System.Windows.Forms.PictureBox();
            this.lineCounter = new System.Windows.Forms.TextBox();
            this.ErrorShow = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(283, 685);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // Compile
            // 
            this.Compile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Compile.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compile.Image = ((System.Drawing.Image)(resources.GetObject("Compile.Image")));
            this.Compile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Compile.Location = new System.Drawing.Point(348, 4);
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(182, 41);
            this.Compile.TabIndex = 2;
            this.Compile.Text = "Compile and Run";
            this.Compile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Compile.UseVisualStyleBackColor = true;
            this.Compile.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(942, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(162, 41);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save Project";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadButton.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
            this.LoadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadButton.Location = new System.Drawing.Point(1110, 4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(162, 41);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "Load Project";
            this.LoadButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // Right
            // 
            this.Right.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Right.Image = global::Geo_Wall_E.Properties.Resources.DERECHA;
            this.Right.Location = new System.Drawing.Point(1358, 314);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(36, 49);
            this.Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Right.TabIndex = 10;
            this.Right.TabStop = false;
            this.Right.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // Down
            // 
            this.Down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Down.Image = global::Geo_Wall_E.Properties.Resources.ABAJO;
            this.Down.Location = new System.Drawing.Point(806, 703);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(47, 41);
            this.Down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Down.TabIndex = 9;
            this.Down.TabStop = false;
            this.Down.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Left
            // 
            this.Left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Left.Image = global::Geo_Wall_E.Properties.Resources.IZQUIERDA;
            this.Left.Location = new System.Drawing.Point(306, 314);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(36, 49);
            this.Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Left.TabIndex = 8;
            this.Left.TabStop = false;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Up
            // 
            this.Up.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Up.Image = global::Geo_Wall_E.Properties.Resources.ARRIBA;
            this.Up.Location = new System.Drawing.Point(806, 4);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(47, 41);
            this.Up.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Up.TabIndex = 7;
            this.Up.TabStop = false;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // lienzo
            // 
            this.lienzo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lienzo.Location = new System.Drawing.Point(348, 51);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(1000, 646);
            this.lienzo.TabIndex = 0;
            this.lienzo.TabStop = false;
            // 
            // lineCounter
            // 
            this.lineCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineCounter.Location = new System.Drawing.Point(278, 12);
            this.lineCounter.Multiline = true;
            this.lineCounter.Name = "lineCounter";
            this.lineCounter.Size = new System.Drawing.Size(18, 685);
            this.lineCounter.TabIndex = 11;
            // 
            // ErrorShow
            // 
            this.ErrorShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorShow.ForeColor = System.Drawing.Color.Red;
            this.ErrorShow.Location = new System.Drawing.Point(1358, 51);
            this.ErrorShow.Multiline = true;
            this.ErrorShow.Name = "ErrorShow";
            this.ErrorShow.ReadOnly = true;
            this.ErrorShow.Size = new System.Drawing.Size(160, 160);
            this.ErrorShow.TabIndex = 12;
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.ErrorShow);
            this.Controls.Add(this.lineCounter);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.lienzo);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Compile);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Work";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GEO-Wall E";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox lienzo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Compile;
        private System.Windows.Forms.PictureBox Wall_E;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileArchive;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.PictureBox Up;
        private System.Windows.Forms.PictureBox Left;
        private System.Windows.Forms.PictureBox Down;
        private System.Windows.Forms.PictureBox Right;
        private System.Windows.Forms.TextBox lineCounter;
        private System.Windows.Forms.TextBox ErrorShow;
    }
}


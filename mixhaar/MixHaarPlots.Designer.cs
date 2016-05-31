namespace mixhaar
{
    partial class MixHaarPlots
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
            this.nupR = new System.Windows.Forms.NumericUpDown();
            this.nupN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupN)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.nupN);
            this.panelBottom.Controls.Add(this.nupR);
            this.panelBottom.Location = new System.Drawing.Point(0, 451);
            this.panelBottom.Size = new System.Drawing.Size(782, 100);
            this.panelBottom.Controls.SetChildIndex(this.seriesListBox, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupR, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupN, 0);
            this.panelBottom.Controls.SetChildIndex(this.label1, 0);
            this.panelBottom.Controls.SetChildIndex(this.label2, 0);
            // 
            // nupR
            // 
            this.nupR.Location = new System.Drawing.Point(406, 35);
            this.nupR.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nupR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupR.Name = "nupR";
            this.nupR.Size = new System.Drawing.Size(120, 20);
            this.nupR.TabIndex = 2;
            this.nupR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupR.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nupN
            // 
            this.nupN.Location = new System.Drawing.Point(532, 35);
            this.nupN.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nupN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupN.Name = "nupN";
            this.nupN.Size = new System.Drawing.Size(120, 20);
            this.nupN.TabIndex = 3;
            this.nupN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupN.ValueChanged += new System.EventHandler(this.nupN_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "r";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "n";
            // 
            // MixHaarPlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 551);
            this.Name = "MixHaarPlots";
            this.Text = "Form1";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupN;
    }
}


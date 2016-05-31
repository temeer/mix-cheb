namespace mixhaar
{
    partial class DiffEq
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nupNodesCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nupCoeffsCount = new System.Windows.Forms.NumericUpDown();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCoeffsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.nupCoeffsCount);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.nupNodesCount);
            this.panelBottom.Location = new System.Drawing.Point(0, 445);
            this.panelBottom.Size = new System.Drawing.Size(773, 100);
            this.panelBottom.Controls.SetChildIndex(this.seriesListBox, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupNodesCount, 0);
            this.panelBottom.Controls.SetChildIndex(this.label1, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupCoeffsCount, 0);
            this.panelBottom.Controls.SetChildIndex(this.label2, 0);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // nupNodesCount
            // 
            this.nupNodesCount.Location = new System.Drawing.Point(417, 40);
            this.nupNodesCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupNodesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupNodesCount.Name = "nupNodesCount";
            this.nupNodesCount.Size = new System.Drawing.Size(120, 20);
            this.nupNodesCount.TabIndex = 0;
            this.nupNodesCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupNodesCount.ValueChanged += new System.EventHandler(this.nupNodesCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во узлов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Число коэфф.";
            // 
            // nupCoeffsCount
            // 
            this.nupCoeffsCount.Location = new System.Drawing.Point(564, 40);
            this.nupCoeffsCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupCoeffsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCoeffsCount.Name = "nupCoeffsCount";
            this.nupCoeffsCount.Size = new System.Drawing.Size(120, 20);
            this.nupCoeffsCount.TabIndex = 1;
            this.nupCoeffsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupCoeffsCount.ValueChanged += new System.EventHandler(this.nupNodesCount_ValueChanged);
            // 
            // DiffEq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(773, 545);
            this.Name = "DiffEq";
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCoeffsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupCoeffsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupNodesCount;
    }
}

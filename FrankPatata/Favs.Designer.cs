namespace FrankPatata
{
    partial class Favs
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
            this.flowLayoutSeries = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutSeries
            // 
            this.flowLayoutSeries.AutoScroll = true;
            this.flowLayoutSeries.Location = new System.Drawing.Point(446, 307);
            this.flowLayoutSeries.Name = "flowLayoutSeries";
            this.flowLayoutSeries.Size = new System.Drawing.Size(1004, 438);
            this.flowLayoutSeries.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1902, 304);
            this.label1.TabIndex = 26;
            this.label1.Text = "Favorite list";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackgroundImage = global::FrankPatata.Properties.Resources.icons8_volver_50;
            this.buttonReturn.Location = new System.Drawing.Point(1328, 129);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(55, 50);
            this.buttonReturn.TabIndex = 27;
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // Favs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrankPatata.Properties.Resources.gradient2;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutSeries);
            this.Name = "Favs";
            this.Text = "Favs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Favs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutSeries;
        private Label label1;
        private Button buttonReturn;
    }
}
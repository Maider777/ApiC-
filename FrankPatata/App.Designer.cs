namespace FrankPatata
{
    partial class App
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutSeries = new System.Windows.Forms.FlowLayoutPanel();
            this.searchButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.buttonLoadMore = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1127, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 43);
            this.textBox1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(923, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 37);
            this.label4.TabIndex = 18;
            this.label4.Text = "Search by name:";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.domainUpDown1.Location = new System.Drawing.Point(730, 252);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(150, 43);
            this.domainUpDown1.TabIndex = 17;
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(516, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 37);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search the genre:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(1, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1902, 57);
            this.label1.TabIndex = 14;
            this.label1.Text = "App";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutSeries
            // 
            this.flowLayoutSeries.AutoScroll = true;
            this.flowLayoutSeries.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutSeries.Location = new System.Drawing.Point(495, 333);
            this.flowLayoutSeries.Name = "flowLayoutSeries";
            this.flowLayoutSeries.Size = new System.Drawing.Size(937, 438);
            this.flowLayoutSeries.TabIndex = 24;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(1312, 247);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(134, 46);
            this.searchButton.TabIndex = 25;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(319, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 43);
            this.button2.TabIndex = 26;
            this.button2.Text = "Reset filters";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.resetFiltersButton_Click_1);
            // 
            // buttonLike
            // 
            this.buttonLike.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLike.Location = new System.Drawing.Point(1483, 239);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(52, 55);
            this.buttonLike.TabIndex = 27;
            this.buttonLike.UseVisualStyleBackColor = true;
            this.buttonLike.Click += new System.EventHandler(this.buttonLike_Click);
            // 
            // buttonLoadMore
            // 
            this.buttonLoadMore.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadMore.Location = new System.Drawing.Point(876, 797);
            this.buttonLoadMore.Name = "buttonLoadMore";
            this.buttonLoadMore.Size = new System.Drawing.Size(188, 48);
            this.buttonLoadMore.TabIndex = 28;
            this.buttonLoadMore.Text = "Load more";
            this.buttonLoadMore.UseVisualStyleBackColor = true;
            this.buttonLoadMore.Click += new System.EventHandler(this.buttonLoadMore_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(1385, 106);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(55, 50);
            this.buttonReturn.TabIndex = 29;
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrankPatata.Properties.Resources.gradient2;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonLoadMore);
            this.Controls.Add(this.buttonLike);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.flowLayoutSeries);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "App";
            this.Text = "App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.App_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBox1;
        private Label label4;
        private DomainUpDown domainUpDown1;
        private Label label3;
        private Label label1;
        private FlowLayoutPanel flowLayoutSeries;
        private Button searchButton;
        private Button button2;
        private Button buttonLike;
        private Button buttonLoadMore;
        private Button buttonReturn;
    }
}
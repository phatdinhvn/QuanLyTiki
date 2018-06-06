namespace Home
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.butMinimized = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMark = new System.Windows.Forms.Panel();
            this.but4 = new System.Windows.Forms.Button();
            this.but3 = new System.Windows.Forms.Button();
            this.but2 = new System.Windows.Forms.Button();
            this.but1 = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 108);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.butSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.butMinimized);
            this.panel2.Controls.Add(this.butExit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 108);
            this.panel2.TabIndex = 0;
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.butSearch.FlatAppearance.BorderSize = 0;
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.Location = new System.Drawing.Point(567, 78);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(87, 31);
            this.butSearch.TabIndex = 3;
            this.butSearch.Text = "Tìm kiếm";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(218, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(349, 31);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // butMinimized
            // 
            this.butMinimized.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.butMinimized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butMinimized.FlatAppearance.BorderSize = 0;
            this.butMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMinimized.Location = new System.Drawing.Point(727, 0);
            this.butMinimized.Name = "butMinimized";
            this.butMinimized.Size = new System.Drawing.Size(35, 34);
            this.butMinimized.TabIndex = 1;
            this.butMinimized.Text = "_";
            this.butMinimized.UseVisualStyleBackColor = false;
            this.butMinimized.Click += new System.EventHandler(this.butMinimized_Click);
            // 
            // butExit
            // 
            this.butExit.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butExit.FlatAppearance.BorderSize = 0;
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.Location = new System.Drawing.Point(765, 0);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(35, 34);
            this.butExit.TabIndex = 1;
            this.butExit.Text = "X";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panelMark);
            this.panel3.Controls.Add(this.but4);
            this.panel3.Controls.Add(this.but3);
            this.panel3.Controls.Add(this.but2);
            this.panel3.Controls.Add(this.but1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 450);
            this.panel3.TabIndex = 1;
            // 
            // panelMark
            // 
            this.panelMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.panelMark.Location = new System.Drawing.Point(145, 74);
            this.panelMark.Name = "panelMark";
            this.panelMark.Size = new System.Drawing.Size(10, 34);
            this.panelMark.TabIndex = 2;
            // 
            // but4
            // 
            this.but4.FlatAppearance.BorderSize = 0;
            this.but4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.but4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.but4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but4.Location = new System.Drawing.Point(0, 210);
            this.but4.Name = "but4";
            this.but4.Size = new System.Drawing.Size(150, 34);
            this.but4.TabIndex = 4;
            this.but4.Text = "Sách, VPP, Quà tặng";
            this.but4.UseVisualStyleBackColor = true;
            this.but4.Click += new System.EventHandler(this.but4_Click);
            // 
            // but3
            // 
            this.but3.FlatAppearance.BorderSize = 0;
            this.but3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.but3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.but3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but3.Location = new System.Drawing.Point(0, 176);
            this.but3.Name = "but3";
            this.but3.Size = new System.Drawing.Size(150, 34);
            this.but3.TabIndex = 4;
            this.but3.Text = "Máy ảnh - Quay phim";
            this.but3.UseVisualStyleBackColor = true;
            this.but3.Click += new System.EventHandler(this.but3_Click);
            // 
            // but2
            // 
            this.but2.FlatAppearance.BorderSize = 0;
            this.but2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.but2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.but2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but2.Location = new System.Drawing.Point(0, 142);
            this.but2.Name = "but2";
            this.but2.Size = new System.Drawing.Size(150, 34);
            this.but2.TabIndex = 3;
            this.but2.Text = "Laptop - Thiết bị IT";
            this.but2.UseVisualStyleBackColor = true;
            this.but2.Click += new System.EventHandler(this.but2_Click);
            // 
            // but1
            // 
            this.but1.FlatAppearance.BorderSize = 0;
            this.but1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(241)))));
            this.but1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.but1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but1.Location = new System.Drawing.Point(0, 108);
            this.but1.Name = "but1";
            this.but1.Size = new System.Drawing.Size(150, 34);
            this.but1.TabIndex = 1;
            this.but1.Text = "Điện Thoại - Máy Tính Bảng";
            this.but1.UseVisualStyleBackColor = true;
            this.but1.Click += new System.EventHandler(this.but1_Click);
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(157, 115);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(631, 323);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "logo tiki.png");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 142);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 272);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butMinimized;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button but1;
        private System.Windows.Forms.Button but4;
        private System.Windows.Forms.Button but3;
        private System.Windows.Forms.Button but2;
        private System.Windows.Forms.Panel panelMark;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList imageListLarge;
    }
}


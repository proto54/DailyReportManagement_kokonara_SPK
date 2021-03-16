namespace DashboardSample
{
    partial class FormDashBoardSample1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMaximized = new System.Windows.Forms.Button();
            this.btnRestorWindow = new System.Windows.Forms.Button();
            this.btnMinimized = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnSlideMenu = new System.Windows.Forms.Button();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.panelStatusBar = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelFormContainer = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.panelFormContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panelTitleBar.Controls.Add(this.btnMaximized);
            this.panelTitleBar.Controls.Add(this.btnRestorWindow);
            this.panelTitleBar.Controls.Add(this.btnMinimized);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1080, 35);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            // 
            // btnMaximized
            // 
            this.btnMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximized.FlatAppearance.BorderSize = 0;
            this.btnMaximized.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMaximized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximized.Image = global::DashboardSample.Properties.Resources.icons8_maximize_window_32px_1;
            this.btnMaximized.Location = new System.Drawing.Point(977, 0);
            this.btnMaximized.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaximized.Name = "btnMaximized";
            this.btnMaximized.Size = new System.Drawing.Size(50, 35);
            this.btnMaximized.TabIndex = 1;
            this.btnMaximized.UseVisualStyleBackColor = true;
            this.btnMaximized.Click += new System.EventHandler(this.btnMaximized_Click);
            // 
            // btnRestorWindow
            // 
            this.btnRestorWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestorWindow.FlatAppearance.BorderSize = 0;
            this.btnRestorWindow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRestorWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestorWindow.Image = global::DashboardSample.Properties.Resources.icons8_restore_window_32px_1;
            this.btnRestorWindow.Location = new System.Drawing.Point(977, 0);
            this.btnRestorWindow.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestorWindow.Name = "btnRestorWindow";
            this.btnRestorWindow.Size = new System.Drawing.Size(50, 35);
            this.btnRestorWindow.TabIndex = 2;
            this.btnRestorWindow.UseVisualStyleBackColor = true;
            this.btnRestorWindow.Click += new System.EventHandler(this.btnRestorWindow_Click);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.FlatAppearance.BorderSize = 0;
            this.btnMinimized.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimized.Image = global::DashboardSample.Properties.Resources.icons8_minimize_window_32px;
            this.btnMinimized.Location = new System.Drawing.Point(924, 0);
            this.btnMinimized.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(50, 35);
            this.btnMinimized.TabIndex = 0;
            this.btnMinimized.UseVisualStyleBackColor = true;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DashboardSample.Properties.Resources.icons8_close_window_32px;
            this.btnClose.Location = new System.Drawing.Point(1030, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panel5.Location = new System.Drawing.Point(0, 273);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 50);
            this.panel5.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panel4.Location = new System.Drawing.Point(0, 217);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 50);
            this.panel4.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panel3.Location = new System.Drawing.Point(0, 161);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 50);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panel2.Location = new System.Drawing.Point(0, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 50);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 50);
            this.panel1.TabIndex = 6;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panelSideMenu.Controls.Add(this.panel2);
            this.panelSideMenu.Controls.Add(this.panel5);
            this.panelSideMenu.Controls.Add(this.btnSlideMenu);
            this.panelSideMenu.Controls.Add(this.btnMenu5);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.btnMenu1);
            this.panelSideMenu.Controls.Add(this.panel4);
            this.panelSideMenu.Controls.Add(this.btnMenu2);
            this.panelSideMenu.Controls.Add(this.btnMenu4);
            this.panelSideMenu.Controls.Add(this.panel3);
            this.panelSideMenu.Controls.Add(this.btnMenu3);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.MaximumSize = new System.Drawing.Size(200, 0);
            this.panelSideMenu.MinimumSize = new System.Drawing.Size(60, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 800);
            this.panelSideMenu.TabIndex = 2;
            // 
            // btnSlideMenu
            // 
            this.btnSlideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSlideMenu.FlatAppearance.BorderSize = 0;
            this.btnSlideMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlideMenu.Image = global::DashboardSample.Properties.Resources.icons8_menu_32px;
            this.btnSlideMenu.Location = new System.Drawing.Point(152, 6);
            this.btnSlideMenu.Name = "btnSlideMenu";
            this.btnSlideMenu.Size = new System.Drawing.Size(35, 35);
            this.btnSlideMenu.TabIndex = 0;
            this.btnSlideMenu.UseVisualStyleBackColor = true;
            this.btnSlideMenu.Click += new System.EventHandler(this.btnSlideMenu_Click);
            // 
            // btnMenu5
            // 
            this.btnMenu5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu5.FlatAppearance.BorderSize = 0;
            this.btnMenu5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.btnMenu5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.btnMenu5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu5.Image = global::DashboardSample.Properties.Resources.icons8_increase_32px;
            this.btnMenu5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu5.Location = new System.Drawing.Point(0, 273);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMenu5.Size = new System.Drawing.Size(200, 50);
            this.btnMenu5.TabIndex = 5;
            this.btnMenu5.Text = "          Menu5";
            this.btnMenu5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu5.UseVisualStyleBackColor = true;
            // 
            // btnMenu1
            // 
            this.btnMenu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu1.FlatAppearance.BorderSize = 0;
            this.btnMenu1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.btnMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.btnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu1.Image = global::DashboardSample.Properties.Resources.icons8_increase_32px;
            this.btnMenu1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu1.Location = new System.Drawing.Point(0, 49);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMenu1.Size = new System.Drawing.Size(200, 50);
            this.btnMenu1.TabIndex = 1;
            this.btnMenu1.Text = "          PRODUCT";
            this.btnMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu1.UseVisualStyleBackColor = true;
            this.btnMenu1.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnMenu2
            // 
            this.btnMenu2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu2.FlatAppearance.BorderSize = 0;
            this.btnMenu2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.btnMenu2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.btnMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu2.Image = global::DashboardSample.Properties.Resources.icons8_increase_32px;
            this.btnMenu2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu2.Location = new System.Drawing.Point(0, 105);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMenu2.Size = new System.Drawing.Size(200, 50);
            this.btnMenu2.TabIndex = 2;
            this.btnMenu2.Text = "          DASHBOARD";
            this.btnMenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu2.UseVisualStyleBackColor = true;
            this.btnMenu2.Click += new System.EventHandler(this.btnMenu2_Click);
            // 
            // btnMenu4
            // 
            this.btnMenu4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu4.FlatAppearance.BorderSize = 0;
            this.btnMenu4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.btnMenu4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.btnMenu4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu4.Image = global::DashboardSample.Properties.Resources.icons8_increase_32px;
            this.btnMenu4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu4.Location = new System.Drawing.Point(0, 217);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMenu4.Size = new System.Drawing.Size(200, 50);
            this.btnMenu4.TabIndex = 4;
            this.btnMenu4.Text = "          Menu4";
            this.btnMenu4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu4.UseVisualStyleBackColor = true;
            // 
            // btnMenu3
            // 
            this.btnMenu3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu3.FlatAppearance.BorderSize = 0;
            this.btnMenu3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(50)))));
            this.btnMenu3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.btnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu3.Image = global::DashboardSample.Properties.Resources.icons8_increase_32px;
            this.btnMenu3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu3.Location = new System.Drawing.Point(0, 161);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMenu3.Size = new System.Drawing.Size(200, 50);
            this.btnMenu3.TabIndex = 3;
            this.btnMenu3.Text = "          Menu3";
            this.btnMenu3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu3.UseVisualStyleBackColor = true;
            // 
            // panelStatusBar
            // 
            this.panelStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(82)))));
            this.panelStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusBar.Location = new System.Drawing.Point(200, 735);
            this.panelStatusBar.Name = "panelStatusBar";
            this.panelStatusBar.Size = new System.Drawing.Size(1080, 65);
            this.panelStatusBar.TabIndex = 3;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(200, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1080, 735);
            this.panelChildForm.TabIndex = 0;
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Controls.Add(this.panelChildForm);
            this.panelFormContainer.Controls.Add(this.panelTitleBar);
            this.panelFormContainer.Controls.Add(this.panelStatusBar);
            this.panelFormContainer.Controls.Add(this.panelSideMenu);
            this.panelFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormContainer.Location = new System.Drawing.Point(0, 0);
            this.panelFormContainer.Name = "panelFormContainer";
            this.panelFormContainer.Size = new System.Drawing.Size(1280, 800);
            this.panelFormContainer.TabIndex = 0;
            // 
            // FormDashBoardSample1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelFormContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "FormDashBoardSample1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDashBoardSample1_FormClosing);
            this.Load += new System.EventHandler(this.FormDashBoardSample1_Load);
            this.Shown += new System.EventHandler(this.FormDashBoardSample1_Shown);
            this.panelTitleBar.ResumeLayout(false);
            this.panelSideMenu.ResumeLayout(false);
            this.panelFormContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximized;
        private System.Windows.Forms.Button btnRestorWindow;
        private System.Windows.Forms.Button btnMinimized;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnMenu5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMenu2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenu1;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnSlideMenu;
        private System.Windows.Forms.Panel panelStatusBar;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelFormContainer;
    }
}


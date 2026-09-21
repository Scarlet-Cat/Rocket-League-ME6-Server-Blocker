namespace Rocket_League_ME6_Server_Blocker
{
    partial class ServerBlockerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileBrowserDialog = new OpenFileDialog();
            blockServerToggleButton = new Button();
            onlyBlockRocketCheckBox = new CheckBox();
            menuDropDown = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            resetPathToolStripMenuItem = new ToolStripMenuItem();
            resetRulesToolStripMenuItem = new ToolStripMenuItem();
            deleteSaveFilesToolStripMenuItem = new ToolStripMenuItem();
            menuDropDown.SuspendLayout();
            SuspendLayout();
            // 
            // fileBrowserDialog
            // 
            fileBrowserDialog.FileName = "fileBrowserDialog";
            // 
            // blockServerToggleButton
            // 
            blockServerToggleButton.Location = new Point(28, 65);
            blockServerToggleButton.Name = "blockServerToggleButton";
            blockServerToggleButton.Size = new Size(126, 41);
            blockServerToggleButton.TabIndex = 0;
            blockServerToggleButton.Text = "Block Server";
            blockServerToggleButton.UseVisualStyleBackColor = true;
            blockServerToggleButton.Click += blockServerToggleButton_Click;
            // 
            // onlyBlockRocketCheckBox
            // 
            onlyBlockRocketCheckBox.AutoSize = true;
            onlyBlockRocketCheckBox.ForeColor = SystemColors.ControlLightLight;
            onlyBlockRocketCheckBox.Location = new Point(174, 76);
            onlyBlockRocketCheckBox.Name = "onlyBlockRocketCheckBox";
            onlyBlockRocketCheckBox.Size = new Size(200, 24);
            onlyBlockRocketCheckBox.TabIndex = 1;
            onlyBlockRocketCheckBox.Text = "only block Rocket League";
            onlyBlockRocketCheckBox.UseVisualStyleBackColor = true;
            onlyBlockRocketCheckBox.CheckedChanged += onlyBlockRocketCheckBox_CheckedChanged;
            // 
            // menuDropDown
            // 
            menuDropDown.ImageScalingSize = new Size(20, 20);
            menuDropDown.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuDropDown.Location = new Point(0, 0);
            menuDropDown.Name = "menuDropDown";
            menuDropDown.Size = new Size(361, 28);
            menuDropDown.TabIndex = 3;
            menuDropDown.Text = "menuDropDown";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetToolStripMenuItem, resetPathToolStripMenuItem, resetRulesToolStripMenuItem, deleteSaveFilesToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(204, 26);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += menuDropdown_reset_Click;
            // 
            // resetPathToolStripMenuItem
            // 
            resetPathToolStripMenuItem.Name = "resetPathToolStripMenuItem";
            resetPathToolStripMenuItem.Size = new Size(204, 26);
            resetPathToolStripMenuItem.Text = "Reset File Path";
            resetPathToolStripMenuItem.Click += menuDropdown_resetFilePath_Click;
            // 
            // resetRulesToolStripMenuItem
            // 
            resetRulesToolStripMenuItem.Name = "resetRulesToolStripMenuItem";
            resetRulesToolStripMenuItem.Size = new Size(204, 26);
            resetRulesToolStripMenuItem.Text = "Delete Rules";
            resetRulesToolStripMenuItem.Click += menuDropdown_deleteRules_Click;
            // 
            // deleteSaveFilesToolStripMenuItem
            // 
            deleteSaveFilesToolStripMenuItem.Name = "deleteSaveFilesToolStripMenuItem";
            deleteSaveFilesToolStripMenuItem.Size = new Size(204, 26);
            deleteSaveFilesToolStripMenuItem.Text = "Delete Save Files";
            deleteSaveFilesToolStripMenuItem.Click += menuDropdown_deleteAll_Click;
            // 
            // ServerBlockerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(392, 155);
            Controls.Add(menuDropDown);
            Controls.Add(onlyBlockRocketCheckBox);
            Controls.Add(blockServerToggleButton);
            MainMenuStrip = menuDropDown;
            Name = "ServerBlockerForm";
            Text = "Rocket League ME6 Server Blocker";
            Load += ServerBlockerForm_Load;
            menuDropDown.ResumeLayout(false);
            menuDropDown.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog fileBrowserDialog;
        private Button blockServerToggleButton;
        private CheckBox onlyBlockRocketCheckBox;
        private MenuStrip menuDropDown;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem resetRulesToolStripMenuItem;
        private ToolStripMenuItem resetPathToolStripMenuItem;
        private ToolStripMenuItem deleteSaveFilesToolStripMenuItem;
    }
}

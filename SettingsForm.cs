using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq; 

namespace Total_marks
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Settings";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Application Settings";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(160, 20);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.DimGray;
            this.Controls.Add(lblTitle);

            // Settings options
            int y = 70;
            int labelX = 50;
            int controlX = 200;

            // Grading scale setting
            Label lblGrading = new Label();
            lblGrading.Text = "Grading Scale:";
            lblGrading.Location = new Point(labelX, y);
            lblGrading.AutoSize = true;
            this.Controls.Add(lblGrading);

            ComboBox cmbGrading = new ComboBox();
            cmbGrading.Location = new Point(controlX, y);
            cmbGrading.Size = new Size(200, 20);
            cmbGrading.Items.AddRange(new string[] { "Standard (A-F)", "Percentage Based", "Custom Scale" });
            cmbGrading.SelectedIndex = 0;
            this.Controls.Add(cmbGrading);
            y += 40;

            // Theme setting
            Label lblTheme = new Label();
            lblTheme.Text = "Theme:";
            lblTheme.Location = new Point(labelX, y);
            lblTheme.AutoSize = true;
            this.Controls.Add(lblTheme);

            ComboBox cmbTheme = new ComboBox();
            cmbTheme.Location = new Point(controlX, y);
            cmbTheme.Size = new Size(200, 20);
            cmbTheme.Items.AddRange(new string[] { "Light", "Dark", "System Default" });
            cmbTheme.SelectedIndex = 0;
            this.Controls.Add(cmbTheme);
            y += 40;

            // Auto-save setting
            Label lblAutoSave = new Label();
            lblAutoSave.Text = "Auto-save:";
            lblAutoSave.Location = new Point(labelX, y);
            lblAutoSave.AutoSize = true;
            this.Controls.Add(lblAutoSave);

            CheckBox chkAutoSave = new CheckBox();
            chkAutoSave.Location = new Point(controlX, y);
            chkAutoSave.Checked = true;
            this.Controls.Add(chkAutoSave);
            y += 40;

            // User management
            Label lblUsers = new Label();
            lblUsers.Text = "Manage Users:";
            lblUsers.Location = new Point(labelX, y);
            lblUsers.AutoSize = true;
            this.Controls.Add(lblUsers);

            Button btnManageUsers = new Button();
            btnManageUsers.Text = "User Management";
            btnManageUsers.Location = new Point(controlX, y);
            btnManageUsers.Size = new Size(150, 25);
            btnManageUsers.Click += (s, e) => ShowMessage("User management feature coming soon!");
            this.Controls.Add(btnManageUsers);
            y += 50;

            // Save button
            Button btnSave = new Button();
            btnSave.Text = "Save Settings";
            btnSave.Location = new Point(150, y);
            btnSave.Size = new Size(100, 30);
            btnSave.BackColor = Color.Green;
            btnSave.ForeColor = Color.White;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Reset button
            Button btnReset = new Button();
            btnReset.Text = "Reset to Default";
            btnReset.Location = new Point(260, y);
            btnReset.Size = new Size(100, 30);
            btnReset.BackColor = Color.Orange;
            btnReset.ForeColor = Color.White;
            btnReset.Click += BtnReset_Click;
            this.Controls.Add(btnReset);
            y += 50;

            // Navigation buttons
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(180, y);
            btnBack.Size = new Size(150, 30);
            btnBack.BackColor = Color.SlateGray;
            btnBack.ForeColor = Color.White;
            btnBack.Click += (s, e) => NavigateToDashboard();
            this.Controls.Add(btnBack);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Get all controls
            ComboBox cmbGrading = this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Items.Contains("Standard (A-F)"));
            ComboBox cmbTheme = this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Items.Contains("Light"));
            CheckBox chkAutoSave = this.Controls.OfType<CheckBox>().FirstOrDefault();

            if (cmbGrading != null && cmbTheme != null && chkAutoSave != null)
            {
                string gradingScale = cmbGrading.SelectedItem?.ToString() ?? "Standard (A-F)";
                string theme = cmbTheme.SelectedItem?.ToString() ?? "Light";
                bool autoSave = chkAutoSave.Checked;

                // Simulate saving settings (in a real app, this would save to config file/database)
                string settingsSummary = $"Settings Saved Successfully!\n\n" +
                                       $"Grading Scale: {gradingScale}\n" +
                                       $"Theme: {theme}\n" +
                                       $"Auto-save: {(autoSave ? "Enabled" : "Disabled")}\n\n" +
                                       $"Settings will be applied on next application restart.";

                MessageBox.Show(settingsSummary, "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Apply some immediate settings (theme would typically require app restart)
                if (theme == "Dark")
                {
                    MessageBox.Show("Dark theme selected. This would change the application theme on restart.", 
                        "Theme Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all settings to default values?", 
                "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                // Reset all controls to default values
                ComboBox cmbGrading = this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Items.Contains("Standard (A-F)"));
                ComboBox cmbTheme = this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Items.Contains("Light"));
                CheckBox chkAutoSave = this.Controls.OfType<CheckBox>().FirstOrDefault();

                if (cmbGrading != null) cmbGrading.SelectedIndex = 0;
                if (cmbTheme != null) cmbTheme.SelectedIndex = 0;
                if (chkAutoSave != null) chkAutoSave.Checked = true;

                MessageBox.Show("All settings have been reset to default values.", 
                    "Settings Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NavigateToDashboard()
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Total_marks
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Student Marks Calculator - Dashboard";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGreen;

            // Welcome label
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Student Grading System";
            lblWelcome.Font = new Font("Arial", 16, FontStyle.Bold);
            lblWelcome.Location = new Point(150, 30);
            lblWelcome.AutoSize = true;
            this.Controls.Add(lblWelcome);

            // Navigation buttons
            int y = 100;
            int buttonWidth = 200;
            int buttonHeight = 40;
            int spacing = 50;

            Button btnMarks = CreateNavButton("Marks Calculator", y);
            btnMarks.BackColor = Color.ForestGreen;
            btnMarks.ForeColor = Color.White;
            btnMarks.Click += (s, e) => NavigateTo(new MainForm());
            y += spacing;

            Button btnStudents = CreateNavButton("Student Management", y);
            btnStudents.BackColor = Color.SeaGreen;
            btnStudents.ForeColor = Color.White;
            btnStudents.Click += (s, e) => NavigateTo(new StudentManagementForm());
            y += spacing;

            Button btnReports = CreateNavButton("Reports", y);
            btnReports.BackColor = Color.MediumSeaGreen;
            btnReports.ForeColor = Color.White;
            btnReports.Click += (s, e) => NavigateTo(new ReportsForm());
            y += spacing;

            Button btnSettings = CreateNavButton("Settings", y);
            btnSettings.BackColor = Color.DarkSeaGreen;
            btnSettings.ForeColor = Color.White;
            btnSettings.Click += (s, e) => NavigateTo(new SettingsForm());
            y += spacing;

            // Logout button
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(250, y);
            btnLogout.Size = new Size(100, 30);
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.ForeColor = Color.White;
            btnLogout.Click += BtnLogout_Click;
            this.Controls.Add(btnLogout);
        }

        private Button CreateNavButton(string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(200, y);
            button.Size = new Size(200, 40);
            this.Controls.Add(button);
            return button;
        }

        private void NavigateTo(Form form)
        {
            form.Show();
            this.Hide();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}

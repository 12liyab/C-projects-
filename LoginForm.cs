using System; 
using System.Windows.Forms;

namespace Total_marks
{
    public partial class LoginForm : Form
    {
        // Simple hardcoded credentials for demo purposes
        private const string ValidUsername = "admin";
        private const string ValidPassword = "password123";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form setup
            this.Text = "Student Marks Calculator - Login";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.LightBlue;

            // Username label
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new System.Drawing.Point(50, 50);
            lblUsername.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblUsername);

            // Username textbox
            TextBox txtUsername = new TextBox();
            txtUsername.Location = new System.Drawing.Point(150, 50);
            txtUsername.Size = new System.Drawing.Size(200, 20);
            txtUsername.Name = "txtUsername";
            this.Controls.Add(txtUsername);

            // Password label
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new System.Drawing.Point(50, 90);
            lblPassword.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblPassword);

            // Password textbox
            TextBox txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(150, 90);
            txtPassword.Size = new System.Drawing.Size(200, 20);
            txtPassword.PasswordChar = '*';
            txtPassword.Name = "txtPassword";
            this.Controls.Add(txtPassword);

            // Login button
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new System.Drawing.Point(150, 130);
            btnLogin.Size = new System.Drawing.Size(100, 30);
            btnLogin.BackColor = Color.SteelBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font(btnLogin.Font, FontStyle.Bold);
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            // Status label
            Label lblStatus = new Label();
            lblStatus.Text = "";
            lblStatus.Location = new System.Drawing.Point(50, 170);
            lblStatus.Size = new System.Drawing.Size(300, 20);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Name = "lblStatus";
            this.Controls.Add(lblStatus);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            TextBox txtUsername = this.Controls["txtUsername"] as TextBox;
            TextBox txtPassword = this.Controls["txtPassword"] as TextBox;
            Label lblStatus = this.Controls["lblStatus"] as Label;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Please enter both username and password.";
                return;
            }

            if (username == ValidUsername && password == ValidPassword)
            {
                lblStatus.Text = "Login successful!";
                lblStatus.ForeColor = Color.Green;

                // Open dashboard form and close login form
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}

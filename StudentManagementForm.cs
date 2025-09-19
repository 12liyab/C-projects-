using System; 
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Total_marks
{
    public partial class StudentManagementForm : Form
    {
        public StudentManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Student Management";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGoldenrodYellow;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Student Management";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(180, 20);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Goldenrod;
            this.Controls.Add(lblTitle);

            // Student list (simulated with listbox)
            ListBox lstStudents = new ListBox();
            lstStudents.Location = new Point(50, 60);
            lstStudents.Size = new Size(400, 200);
            lstStudents.Items.AddRange(new string[] {
                "John Doe - ID: 001",
                "Jane Smith - ID: 002", 
                "Bob Johnson - ID: 003",
                "Alice Brown - ID: 004",
                "Charlie Wilson - ID: 005"
            });
            this.Controls.Add(lstStudents);

            // Action buttons
            Button btnAdd = new Button();
            btnAdd.Text = "Add Student";
            btnAdd.Location = new Point(50, 280);
            btnAdd.Size = new Size(100, 30);
            btnAdd.BackColor = Color.Goldenrod;
            btnAdd.ForeColor = Color.White;
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button();
            btnEdit.Text = "Edit Student";
            btnEdit.Location = new Point(160, 280);
            btnEdit.Size = new Size(100, 30);
            btnEdit.BackColor = Color.DarkGoldenrod;
            btnEdit.ForeColor = Color.White;
            btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete Student";
            btnDelete.Location = new Point(270, 280);
            btnDelete.Size = new Size(100, 30);
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.ForeColor = Color.White;
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);

            Button btnViewMarks = new Button();
            btnViewMarks.Text = "View Marks";
            btnViewMarks.Location = new Point(380, 280);
            btnViewMarks.Size = new Size(100, 30);
            btnViewMarks.BackColor = Color.SteelBlue;
            btnViewMarks.ForeColor = Color.White;
            btnViewMarks.Click += BtnViewMarks_Click;
            this.Controls.Add(btnViewMarks);

            // Navigation buttons
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(180, 320);
            btnBack.Size = new Size(150, 30);
            btnBack.BackColor = Color.SaddleBrown;
            btnBack.ForeColor = Color.White;
            btnBack.Click += (s, e) => NavigateToDashboard();
            this.Controls.Add(btnBack);
        }

        private void NavigateToDashboard()
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowStudentDialog("Add New Student");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ListBox lstStudents = this.Controls.OfType<ListBox>().FirstOrDefault();
            if (lstStudents != null && lstStudents.SelectedItem != null)
            {
                ShowStudentDialog("Edit Student", lstStudents.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a student to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ListBox lstStudents = this.Controls.OfType<ListBox>().FirstOrDefault();
            if (lstStudents != null && lstStudents.SelectedItem != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {lstStudents.SelectedItem}?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.Yes)
                {
                    lstStudents.Items.Remove(lstStudents.SelectedItem);
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnViewMarks_Click(object sender, EventArgs e)
        {
            ListBox lstStudents = this.Controls.OfType<ListBox>().FirstOrDefault();
            if (lstStudents != null && lstStudents.SelectedItem != null)
            {
                string selectedStudent = lstStudents.SelectedItem.ToString();
                MessageBox.Show($"Viewing marks for: {selectedStudent}\n\nThis would show detailed marks and performance data.", 
                    "Student Marks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a student to view marks.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowStudentDialog(string title, string existingData = null)
        {
            Form dialog = new Form();
            dialog.Text = title;
            dialog.Size = new Size(400, 250);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;

            // Student Name
            Label lblName = new Label() { Text = "Student Name:", Location = new Point(30, 30), AutoSize = true };
            TextBox txtName = new TextBox() { Location = new Point(150, 30), Width = 200 };
            
            // Student ID
            Label lblID = new Label() { Text = "Student ID:", Location = new Point(30, 70), AutoSize = true };
            TextBox txtID = new TextBox() { Location = new Point(150, 70), Width = 200 };

            if (existingData != null)
            {
                // Parse existing data (format: "Name - ID: 001")
                var parts = existingData.Split(new[] { " - ID: " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    txtName.Text = parts[0];
                    txtID.Text = parts[1];
                }
            }

            // OK Button
            Button btnOK = new Button() { Text = "OK", Location = new Point(150, 120), Size = new Size(80, 30) };
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += (s, e) => dialog.Close();

            // Cancel Button
            Button btnCancel = new Button() { Text = "Cancel", Location = new Point(240, 120), Size = new Size(80, 30) };
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Click += (s, e) => dialog.Close();

            dialog.Controls.AddRange(new Control[] { lblName, txtName, lblID, txtID, btnOK, btnCancel });
            
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtID.Text))
            {
                ListBox lstStudents = this.Controls.OfType<ListBox>().FirstOrDefault();
                if (lstStudents != null)
                {
                    string newStudent = $"{txtName.Text} - ID: {txtID.Text}";
                    
                    if (existingData != null)
                    {
                        // Replace existing item
                        int index = lstStudents.Items.IndexOf(existingData);
                        if (index != -1)
                        {
                            lstStudents.Items[index] = newStudent;
                        }
                    }
                    else
                    {
                        // Add new item
                        lstStudents.Items.Add(newStudent);
                    }
                    
                    MessageBox.Show("Student saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

using System;
using System.Drawing; 
using System.Windows.Forms;

namespace Total_marks
{
    public partial class MainForm : Form
    {
        // Controls declaration
        private TextBox txtStudentName;
        private TextBox txtStudentID;
        private TextBox txtClassTest;
        private TextBox txtMidsem;
        private TextBox txtPresentation;
        private TextBox txtExamScore;
        private Label lblResult;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Student Total Marks Calculator";
            this.Size = new Size(550, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            int labelX = 40;
            int inputX = 220;
            int y = 20;
            int yStep = 40;

            // Header
            Label lblHeader = new Label() { Text = "Student Marks Calculator", Location = new Point(150, y), AutoSize = true, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.DarkBlue };
            y += 50;

            // Student Name
            Label lblStudentName = new Label() { Text = "Student Name:", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtStudentName = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Student ID
            Label lblStudentID = new Label() { Text = "Student ID:", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtStudentID = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Class Test Marks
            Label lblClassTest = new Label() { Text = "Class Test Marks (0-100):", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtClassTest = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Midsem Marks
            Label lblMidsem = new Label() { Text = "Midsem Marks (0-100):", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtMidsem = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Presentation Marks
            Label lblPresentation = new Label() { Text = "Presentation Marks (0-100):", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtPresentation = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Exam Score
            Label lblExamScore = new Label() { Text = "Exam Score (0-100):", Location = new Point(labelX, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            txtExamScore = new TextBox() { Location = new Point(inputX, y), Width = 250, Font = new Font("Segoe UI", 10) };
            y += yStep;

            // Calculate Button
            Button btnCalculate = new Button() { Text = "Calculate Grade", Location = new Point(inputX, y), Width = 120, Height = 35 };
            btnCalculate.BackColor = Color.FromArgb(0, 123, 255);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Click += BtnCalculate_Click;
            y += yStep + 20;

            // Result Label
            lblResult = new Label() { Location = new Point(labelX, y), Size = new Size(480, 120), AutoSize = false, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.LightGray, Font = new Font("Segoe UI", 9) };
            y += 140;

            // Navigation button
            Button btnBack = new Button() { Text = "Back to Dashboard", Location = new Point(inputX, y), Width = 150, Height = 35 };
            btnBack.BackColor = Color.FromArgb(108, 117, 125);
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Click += (s, e) => NavigateToDashboard();

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                lblHeader,
                lblStudentName, txtStudentName,
                lblStudentID, txtStudentID,
                lblClassTest, txtClassTest,
                lblMidsem, txtMidsem,
                lblPresentation, txtPresentation,
                lblExamScore, txtExamScore,
                btnCalculate,
                lblResult,
                btnBack
            });
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            // Validate and parse inputs
            if (!ValidateInputs(out string studentName, out string studentID,
                                out double classTestMarks, out double midsemMarks,
                                out double presentationMarks, out double examScore))
            {
                return;
            }

            // Calculate total marks (sum of the 4 scores)
            double totalMarks = classTestMarks + midsemMarks + presentationMarks + examScore;
            double percentage = (totalMarks / 400) * 100;

            // Determine grade based on percentage
            string grade;
            if (percentage >= 85)
                grade = "A+";
            else if (percentage >= 80)
                grade = "A";
            else if (percentage >= 75)
                grade = "B+";
            else if (percentage >= 70)
                grade = "B";
            else if (percentage >= 65)
                grade = "C+";
            else if (percentage >= 60)
                grade = "C";
            else if (percentage >= 55)
                grade = "D+";
            else if (percentage >= 50)
                grade = "D";
            else
                grade = "F";

            // Display results
            lblResult.Text = $"Student Details:\n" +
                             $"Name: {studentName}\n" +
                             $"ID: {studentID}\n\n" +
                             $"Marks Breakdown:\n" +
                             $"Class Test: {classTestMarks:F2}\n" +
                             $"Midsem: {midsemMarks:F2}\n" +
                             $"Presentation: {presentationMarks:F2}\n" +
                             $"Exam: {examScore:F2}\n\n" +
                             $"Total Marks: {totalMarks:F2} / 400\n" +
                             $"Percentage: {percentage:F2}%\n" +
                             $"Grade: {grade}";
        }

        private bool ValidateInputs(out string studentName, out string studentID,
                                    out double classTestMarks, out double midsemMarks,
                                    out double presentationMarks, out double examScore)
        {
            studentName = txtStudentName.Text.Trim();
            studentID = txtStudentID.Text.Trim();
            classTestMarks = midsemMarks = presentationMarks = examScore = 0;

            if (string.IsNullOrEmpty(studentName))
            {
                MessageBox.Show("Please enter the student's name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(studentID))
            {
                MessageBox.Show("Please enter the student's ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtClassTest.Text, out classTestMarks))
            {
                ShowInputError("Class Test Marks");
                return false;
            }
            if (!double.TryParse(txtMidsem.Text, out midsemMarks))
            {
                ShowInputError("Midsem Marks");
                return false;
            }
            if (!double.TryParse(txtPresentation.Text, out presentationMarks))
            {
                ShowInputError("Presentation Marks");
                return false;
            }
            if (!double.TryParse(txtExamScore.Text, out examScore))
            {
                ShowInputError("Exam Score");
                return false;
            }

            return true;
        }

        private void ShowInputError(string fieldName)
        {
            MessageBox.Show($"Please enter a valid number for {fieldName}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NavigateToDashboard()
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}

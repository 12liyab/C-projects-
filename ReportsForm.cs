using System;
using System.Drawing;
using System.Windows.Forms;

namespace Total_marks
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reports & Statistics";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Lavender;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Reports & Statistics";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(160, 20);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.DarkSlateBlue;
            this.Controls.Add(lblTitle);

            // Report options
            int y = 70;
            int buttonWidth = 300;
            int buttonHeight = 40;
            int spacing = 50;

            Button btnStudentReport = CreateReportButton("Student Performance Report", y);
            btnStudentReport.BackColor = Color.MediumPurple;
            btnStudentReport.ForeColor = Color.White;
            btnStudentReport.Click += BtnStudentReport_Click;
            y += spacing;

            Button btnClassReport = CreateReportButton("Class Summary Report", y);
            btnClassReport.BackColor = Color.SlateBlue;
            btnClassReport.ForeColor = Color.White;
            btnClassReport.Click += BtnClassReport_Click;
            y += spacing;

            Button btnGradeDistribution = CreateReportButton("Grade Distribution Chart", y);
            btnGradeDistribution.BackColor = Color.DarkSlateBlue;
            btnGradeDistribution.ForeColor = Color.White;
            btnGradeDistribution.Click += BtnGradeDistribution_Click;
            y += spacing;

            Button btnExportData = CreateReportButton("Export Data to CSV", y);
            btnExportData.BackColor = Color.MediumSlateBlue;
            btnExportData.ForeColor = Color.White;
            btnExportData.Click += BtnExportData_Click;
            y += spacing;

            // Navigation buttons
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(180, y);
            btnBack.Size = new Size(150, 30);
            btnBack.BackColor = Color.Indigo;
            btnBack.ForeColor = Color.White;
            btnBack.Click += (s, e) => NavigateToDashboard();
            this.Controls.Add(btnBack);
        }

        private Button CreateReportButton(string text, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(100, y);
            button.Size = new Size(300, 35);
            this.Controls.Add(button);
            return button;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Report Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnStudentReport_Click(object sender, EventArgs e)
        {
            // Simulate generating a student performance report
            string reportContent = "STUDENT PERFORMANCE REPORT\n" +
                                 "==========================\n\n" +
                                 "Student: John Doe (ID: 001)\n" +
                                 "Total Marks: 85.5/100\n" +
                                 "Grade: A\n" +
                                 "Attendance: 95%\n" +
                                 "Assignments Completed: 12/12\n\n" +
                                 "Student: Jane Smith (ID: 002)\n" +
                                 "Total Marks: 78.2/100\n" +
                                 "Grade: B+\n" +
                                 "Attendance: 88%\n" +
                                 "Assignments Completed: 11/12\n\n" +
                                 "Report generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            ShowReportDialog("Student Performance Report", reportContent);
        }

        private void BtnClassReport_Click(object sender, EventArgs e)
        {
            // Simulate generating a class summary report
            string reportContent = "CLASS SUMMARY REPORT\n" +
                                 "====================\n\n" +
                                 "Class: Computer Science 101\n" +
                                 "Total Students: 25\n" +
                                 "Average Score: 76.8/100\n" +
                                 "Highest Score: 95.5 (Alice Brown)\n" +
                                 "Lowest Score: 52.0 (Bob Johnson)\n" +
                                 "Pass Rate: 88%\n\n" +
                                 "Grade Distribution:\n" +
                                 "A: 4 students (16%)\n" +
                                 "B: 10 students (40%)\n" +
                                 "C: 8 students (32%)\n" +
                                 "D: 2 students (8%)\n" +
                                 "F: 1 student (4%)\n\n" +
                                 "Report generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            ShowReportDialog("Class Summary Report", reportContent);
        }

        private void BtnGradeDistribution_Click(object sender, EventArgs e)
        {
            // Simulate generating a grade distribution chart
            string chartContent = "GRADE DISTRIBUTION CHART\n" +
                                "=======================\n\n" +
                                "A (90-100): ████████ (8 students)\n" +
                                "B (80-89):  ██████████████ (12 students)\n" +
                                "C (70-79):  █████████ (8 students)\n" +
                                "D (60-69):  ███ (3 students)\n" +
                                "F (0-59):   █ (1 student)\n\n" +
                                "Total Students: 32\n" +
                                "Class Average: 78.2\n\n" +
                                "Chart generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            ShowReportDialog("Grade Distribution Chart", chartContent);
        }

        private void BtnExportData_Click(object sender, EventArgs e)
        {
            // Simulate CSV export functionality
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.Title = "Export Student Data";
            saveFileDialog.FileName = $"student_data_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Simulate CSV content
                string csvContent = "StudentID,Name,TotalMarks,Grade,Attendance\n" +
                                   "001,John Doe,85.5,A,95%\n" +
                                   "002,Jane Smith,78.2,B+,88%\n" +
                                   "003,Bob Johnson,52.0,F,75%\n" +
                                   "004,Alice Brown,95.5,A+,98%\n" +
                                   "005,Charlie Wilson,82.7,B,92%";
                
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, csvContent);
                    MessageBox.Show($"Data successfully exported to:\n{saveFileDialog.FileName}", 
                        "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}", 
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowReportDialog(string title, string content)
        {
            Form reportDialog = new Form();
            reportDialog.Text = title;
            reportDialog.Size = new Size(600, 500);
            reportDialog.StartPosition = FormStartPosition.CenterParent;
            reportDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            reportDialog.MaximizeBox = false;
            
            TextBox txtReport = new TextBox();
            txtReport.Multiline = true;
            txtReport.ScrollBars = ScrollBars.Vertical;
            txtReport.Location = new Point(20, 20);
            txtReport.Size = new Size(540, 400);
            txtReport.Text = content;
            txtReport.ReadOnly = true;
            txtReport.Font = new Font("Consolas", 10);
            
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(250, 430);
            btnClose.Size = new Size(100, 30);
            btnClose.Click += (s, e) => reportDialog.Close();
            
            reportDialog.Controls.Add(txtReport);
            reportDialog.Controls.Add(btnClose);
            reportDialog.ShowDialog();
        }

        private void NavigateToDashboard()
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}

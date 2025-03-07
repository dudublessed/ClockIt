using ClockIt.Core.Utils;

namespace ClockIt
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            interpriseData = new Label();
            SuspendLayout();
            // 
            // interpriseData
            // 
            string userAvatar = FileHelper.FindFileInProject("user_avatar.png");
            resources.ApplyResources(interpriseData, "interpriseData");
            interpriseData.BackColor = Color.FromArgb(235, 235, 235);
            interpriseData.Name = "interpriseData";
            interpriseData.Image = Image.FromFile(userAvatar);
            interpriseData.ImageAlign = ContentAlignment.MiddleLeft;
            interpriseData.Text = "ARMARINHO NATAL LTDA";
            interpriseData.TextAlign = ContentAlignment.MiddleLeft;
            interpriseData.Size = new Size(480, 60);
            interpriseData.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
            MessageBox.Show(userAvatar);
            interpriseData.Location = new Point(0, 0);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(interpriseData);
            Name = "LoginForm";
            BackColor = Color.FromArgb(245, 245, 245);
            FormBorderStyle = FormBorderStyle.None;
            Load += LoginForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label interpriseData;

    }
}

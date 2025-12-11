namespace ClockIt.src.Presentation.Forms.Main
{
    partial class AdminMainForm
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
            adminActionsMenuStrip = new MenuStrip();
            userToolStripMenuItem = new ToolStripMenuItem();
            createUserToolStripMenuItem = new ToolStripMenuItem();
            viewUsersToolStripMenuItem = new ToolStripMenuItem();
            updateUserToolStripMenuItem = new ToolStripMenuItem();
            deleteUserToolStripMenuItem = new ToolStripMenuItem();
            employeeToolStripMenuItem = new ToolStripMenuItem();
            createEmployeeToolStripMenuItem = new ToolStripMenuItem();
            viewEmployeesToolStripMenuItem = new ToolStripMenuItem();
            updateEmployeeToolStripMenuItem1 = new ToolStripMenuItem();
            deleteEmployeeToolStripMenuItem = new ToolStripMenuItem();
            relatorioToolStripMenuItem = new ToolStripMenuItem();
            positionsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            adminActionsMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // adminActionsMenuStrip
            // 
            adminActionsMenuStrip.BackColor = Color.LightGray;
            adminActionsMenuStrip.Items.AddRange(new ToolStripItem[] { userToolStripMenuItem, employeeToolStripMenuItem, relatorioToolStripMenuItem, positionsToolStripMenuItem, settingsToolStripMenuItem });
            adminActionsMenuStrip.Location = new Point(0, 0);
            adminActionsMenuStrip.Name = "adminActionsMenuStrip";
            adminActionsMenuStrip.Size = new Size(738, 24);
            adminActionsMenuStrip.TabIndex = 0;
            adminActionsMenuStrip.Text = "adminActionsMenuStrip";
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createUserToolStripMenuItem, viewUsersToolStripMenuItem, updateUserToolStripMenuItem, deleteUserToolStripMenuItem });
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(64, 20);
            userToolStripMenuItem.Text = "Usuários";
            // 
            // createUserToolStripMenuItem
            // 
            createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            createUserToolStripMenuItem.Size = new Size(171, 22);
            createUserToolStripMenuItem.Text = "Criar Usuário";
            createUserToolStripMenuItem.Click += showCreateUserForm;
            // 
            // viewUsersToolStripMenuItem
            // 
            viewUsersToolStripMenuItem.Name = "viewUsersToolStripMenuItem";
            viewUsersToolStripMenuItem.Size = new Size(171, 22);
            viewUsersToolStripMenuItem.Text = "Visualizar Usuários";
            // 
            // updateUserToolStripMenuItem
            // 
            updateUserToolStripMenuItem.Name = "updateUserToolStripMenuItem";
            updateUserToolStripMenuItem.Size = new Size(171, 22);
            updateUserToolStripMenuItem.Text = "Atualizar Usuário";
            // 
            // deleteUserToolStripMenuItem
            // 
            deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            deleteUserToolStripMenuItem.Size = new Size(171, 22);
            deleteUserToolStripMenuItem.Text = "Deletar Usuário";
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createEmployeeToolStripMenuItem, viewEmployeesToolStripMenuItem, updateEmployeeToolStripMenuItem1, deleteEmployeeToolStripMenuItem });
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(87, 20);
            employeeToolStripMenuItem.Text = "Funcionários";
            // 
            // createEmployeeToolStripMenuItem
            // 
            createEmployeeToolStripMenuItem.Name = "createEmployeeToolStripMenuItem";
            createEmployeeToolStripMenuItem.Size = new Size(194, 22);
            createEmployeeToolStripMenuItem.Text = "Criar Funcionário";
            createEmployeeToolStripMenuItem.Click += showCreateEmployeeForm;
            // 
            // viewEmployeesToolStripMenuItem
            // 
            viewEmployeesToolStripMenuItem.Name = "viewEmployeesToolStripMenuItem";
            viewEmployeesToolStripMenuItem.Size = new Size(194, 22);
            viewEmployeesToolStripMenuItem.Text = "Visualizar Funcionários";
            // 
            // updateEmployeeToolStripMenuItem1
            // 
            updateEmployeeToolStripMenuItem1.Name = "updateEmployeeToolStripMenuItem1";
            updateEmployeeToolStripMenuItem1.Size = new Size(194, 22);
            updateEmployeeToolStripMenuItem1.Text = "Atualizar Funcionário";
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            deleteEmployeeToolStripMenuItem.Size = new Size(194, 22);
            deleteEmployeeToolStripMenuItem.Text = "Deletar Funcionário";
            // 
            // relatorioToolStripMenuItem
            // 
            relatorioToolStripMenuItem.Name = "relatorioToolStripMenuItem";
            relatorioToolStripMenuItem.Size = new Size(128, 20);
            relatorioToolStripMenuItem.Text = "Relatórios Gerenciais";
            // 
            // positionsToolStripMenuItem
            // 
            positionsToolStripMenuItem.Name = "positionsToolStripMenuItem";
            positionsToolStripMenuItem.Size = new Size(56, 20);
            positionsToolStripMenuItem.Text = "Cargos";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(96, 20);
            settingsToolStripMenuItem.Text = "Configurações";
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(738, 201);
            Controls.Add(adminActionsMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = adminActionsMenuStrip;
            MaximizeBox = false;
            Name = "AdminMainForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt - Administrator Panel";
            Load += AdminMainForm_Load;
            adminActionsMenuStrip.ResumeLayout(false);
            adminActionsMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip adminActionsMenuStrip;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem createUserToolStripMenuItem;
        private ToolStripMenuItem viewUsersToolStripMenuItem;
        private ToolStripMenuItem updateUserToolStripMenuItem;
        private ToolStripMenuItem deleteUserToolStripMenuItem;

        private ToolStripMenuItem employeeToolStripMenuItem;
        private ToolStripMenuItem createEmployeeToolStripMenuItem;
        private ToolStripMenuItem viewEmployeesToolStripMenuItem;
        private ToolStripMenuItem updateEmployeeToolStripMenuItem1;
        private ToolStripMenuItem deleteEmployeeToolStripMenuItem;

        private ToolStripMenuItem relatorioToolStripMenuItem;
        private ToolStripMenuItem positionsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;

    }
}
using Npgsql;
using System.Drawing.Text;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.Presentation.Forms.Start
{
    public partial class LoginForm : Form, ILoginForm
    {
        public string Login => nameBox.Text;
        public string InputPassword => passwordBox.Text;
        public string EnterpriseName
        {
            get => companyLabel.Text;
            set => companyLabel.Text = value;
        }

        public event EventHandler FormShown;
        public event EventHandler FormActivated;
        public event EventHandler LoginRequested;

        public LoginForm()
        {
            InitializeComponent();

            this.Shown += (s, e) => FormShown?.Invoke(this, EventArgs.Empty);
            this.Activated += (s, e) => FormActivated?.Invoke(this, EventArgs.Empty);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            companyLabel.Text = EnterpriseName;  
        }

        public void ShowUsers(List<ShowUsersDTO> users)
        {
            usersContainer.Controls.Clear();

            int usersInX = 1;
            int chosenX = 15;
            int startY = 15;

            foreach (var user in users)
            {
                bool exceededScreenSize = (usersInX == 5);
                bool isFirstUser = ((usersInX == 1) || exceededScreenSize);

                chosenX = exceededScreenSize ? 15 : chosenX;

                if (!isFirstUser)
                {
                    chosenX = (chosenX + 115);
                }
                if (exceededScreenSize)
                {
                    startY = (startY + 115);
                }

                Button userButton = new Button();

                this.ApplyHoverEffect(userButton, [245, 245, 245]);

                string userLogin = user.Login;
                string userAvatar = FileHelper.FindFileInProject("user_avatar.png");

                Image original = Image.FromFile(userAvatar);
                Image resizedUserAvatar = new Bitmap(original, new Size(50, 50));

                userButton.Name = $"userCard_{userLogin}";
                userButton.Location = new Point(chosenX, startY);
                userButton.Size = new Size(110, 90);
                userButton.BackColor = Color.Transparent;
                userButton.FlatStyle = FlatStyle.Flat;
                userButton.FlatAppearance.BorderSize = 0;
                userButton.Cursor = Cursors.Hand;
                userButton.Text = userLogin;
                userButton.Font = new Font("Trebuchet MS", 13, FontStyle.Regular);
                userButton.TextAlign = ContentAlignment.BottomCenter;
                userButton.TextImageRelation = TextImageRelation.ImageAboveText;
                userButton.Image = resizedUserAvatar;
                userButton.ImageAlign = ContentAlignment.TopCenter;
                userButton.Padding = new Padding(1, 5, 0, 0);

                userButton.Click += (s, e) => { SelectUser(userLogin); };

                userButton.BringToFront();
                usersContainer.Controls.Add(userButton);

                usersInX = exceededScreenSize ? 0 : usersInX;
                usersInX++;
            }
        }

        private void SelectUser(string userLogin)
        {
            nameBox.Text = userLogin;
            passwordBox.Text = "";
        }

        private void ApplyHoverEffect(Control container, int[] argb)
        {
            bool isHovering = false;

            container.MouseMove += (s, e) =>
            {
                if (!isHovering)
                {
                    container.BackColor = Color.FromArgb(argb[0], argb[1], argb[2]);
                    isHovering = true;
                }
            };

            container.MouseLeave += (s, e) =>
            {
                if (!isHovering)
                {
                    container.BackColor = Color.Transparent;
                    isHovering = false;
                }
            };
        }

        private void IsKeyDownEnter(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginRequested?.Invoke(this, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        public void ClearInputFields()
        {
            nameBox.Text = "";
            passwordBox.Text = "";
        }
    }
}

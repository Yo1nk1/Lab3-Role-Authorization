using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RoleAuthorizationLab3.Data;

namespace RoleAuthorizationLab3.Forms
{
    public class FormAutorization : Form
    {
        private readonly TextBox textBoxLogin = new TextBox();
        private readonly TextBox textBoxPassword = new TextBox();
        private readonly Label labelError = new Label();

        public FormAutorization()
        {
            Text = "Авторизация";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            ClientSize = new Size(390, 245);

            var title = new Label
            {
                Text = "Вход в систему",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(118, 22)
            };
            var loginLabel = new Label { Text = "Логин", AutoSize = true, Location = new Point(45, 83) };
            var passwordLabel = new Label { Text = "Пароль", AutoSize = true, Location = new Point(45, 123) };

            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Location = new Point(125, 78);
            textBoxLogin.Size = new Size(215, 25);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Location = new Point(125, 118);
            textBoxPassword.Size = new Size(215, 25);
            textBoxPassword.UseSystemPasswordChar = true;

            var buttonEnter = new Button
            {
                Name = "buttonEnter",
                Text = "Войти",
                Location = new Point(145, 164),
                Size = new Size(100, 32)
            };
            buttonEnter.Click += buttonEnter_Click;
            AcceptButton = buttonEnter;

            labelError.ForeColor = Color.Firebrick;
            labelError.AutoSize = true;
            labelError.Location = new Point(45, 207);

            Controls.AddRange(new Control[] { title, loginLabel, passwordLabel, textBoxLogin, textBoxPassword, buttonEnter, labelError });
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            labelError.Text = string.Empty;
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text;
            if (login.Length == 0 || password.Length == 0)
            {
                labelError.Text = "Введите логин и пароль.";
                return;
            }

            try
            {
                using (var model = new User_DataEntities())
                {
                    User user = model.Users
                        .Include(item => item.Role)
                        .FirstOrDefault(item => item.Login == login && item.Password == password);

                    if (user == null || user.Role == null)
                    {
                        labelError.Text = "Неверный логин или пароль.";
                        return;
                    }

                    using (Form roleForm = CreateRoleForm(user))
                    {
                        if (roleForm == null)
                        {
                            labelError.Text = "Для пользователя не назначена поддерживаемая роль.";
                            return;
                        }

                        Hide();
                        roleForm.ShowDialog(this);
                        Show();
                        textBoxPassword.Clear();
                        textBoxLogin.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Не удалось подключиться к базе User_Data. Проверьте SQL Server и строку подключения в App.config.",
                    "Ошибка подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static Form CreateRoleForm(User user)
        {
            switch (user.RoleID)
            {
                case 1: return new FormManager(user);
                case 2: return new FormSeller(user);
                case 3: return new FormDirector(user);
                default: return null;
            }
        }
    }
}

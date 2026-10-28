using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RoleAuthorizationLab3.Data;

namespace RoleAuthorizationLab3.Forms
{
    public class RoleFormBase : Form
    {
        protected RoleFormBase(User user, string roleTitle)
        {
            Text = roleTitle;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            ClientSize = new Size(540, 310);

            var heading = new Label
            {
                Text = "Форма " + roleTitle,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(28, 27)
            };
            var nameLabel = new Label
            {
                Name = "labelNames",
                Text = ((user.FirstName ?? "") + " " + (user.SecondName ?? "")).Trim(),
                Font = new Font("Segoe UI", 12F),
                AutoSize = true,
                Location = new Point(32, 98)
            };
            var roleLabel = new Label
            {
                Name = "labelRole",
                Text = "Роль: " + roleTitle,
                Font = new Font("Segoe UI", 10F),
                AutoSize = true,
                Location = new Point(32, 137)
            };
            var picture = new PictureBox
            {
                Name = "pictureBox1",
                Location = new Point(345, 68),
                Size = new Size(150, 170),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            string picturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Photo", user.Pictures ?? "");
            if (!string.IsNullOrWhiteSpace(user.Pictures) && File.Exists(picturePath))
            {
                using (var stream = new FileStream(picturePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    picture.Image = new Bitmap(stream);
            }

            var buttonBack = new Button
            {
                Name = "buttonBack",
                Text = "Назад",
                Location = new Point(32, 225),
                Size = new Size(100, 32)
            };
            buttonBack.Click += (sender, args) => Close();

            Controls.AddRange(new Control[] { heading, nameLabel, roleLabel, picture, buttonBack });
        }
    }
}

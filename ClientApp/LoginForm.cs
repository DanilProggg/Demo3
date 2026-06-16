namespace ClientApp;

public partial class LoginForm : Form
{
    int attempts = 0;

    public LoginForm()
    {
        InitializeComponent();
        txtPassword.PasswordChar = '*';
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Введите логин и пароль.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string hash = PasswordHelper.HashPassword(txtPassword.Text);
        var user = UserStorage.Find(txtLogin.Text.Trim(), hash);

        if (user == null)
        {
            attempts++;
            if (attempts >= 3)
            {
                UserStorage.Block(txtLogin.Text);
                MessageBox.Show("Вы заблокированы. Обратитесь к администратору.", "Блокировка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show($"Неверный логин или пароль. Осталось попыток: {3 - attempts}.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (user.Blocked)
        {
            MessageBox.Show("Вы заблокированы. Обратитесь к администратору.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        attempts = 0;
        MessageBox.Show("Вы успешно авторизовались.", "Успех",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        if (user.Role == 1)
        {
            var frm = new AdminForm();
            Hide();
            frm.ShowDialog();
            Close();
        }
        else
        {
            var frm = new UserForm();
            Hide();
            frm.ShowDialog();
            Close();
        }
    }
}

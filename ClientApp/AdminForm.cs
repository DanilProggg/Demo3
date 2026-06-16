namespace ClientApp;

public partial class AdminForm : Form
{
    public AdminForm()
    {
        InitializeComponent();
    }

    private void AdminForm_Load(object sender, EventArgs e)
    {
        cmbRole.Items.Clear();
        cmbRole.Items.Add("Администратор");
        cmbRole.Items.Add("Пользователь");
        cmbRole.SelectedIndex = 0;

        cmbAction.Items.Clear();
        cmbAction.Items.Add("Добавить");
        cmbAction.Items.Add("Обновить");
        cmbAction.SelectedIndex = 0;

        LoadUsers();
    }

    private void LoadUsers()
    {
        var users = UserStorage.GetAll();
        dgv1.DataSource = null;
        dgv1.DataSource = users.Select(u => new
        {
            u.Id,
            u.Login,
            Роль = u.Role == 1 ? "Администратор" : "Пользователь",
            Заблокирован = u.Blocked
        }).ToList();

        comboBoxUsers.DataSource = null;
        comboBoxUsers.DataSource = users;
        comboBoxUsers.DisplayMember = "Login";
        comboBoxUsers.ValueMember = "Id";
    }

    private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxUsers.SelectedItem is UserStorage.User u)
        {
            txtLogin.Text = u.Login;
            cmbRole.SelectedIndex = u.Role - 1;
            checkBoxActive.Checked = u.Blocked;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Заполните логин и пароль.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string action = cmbAction.SelectedItem!.ToString()!;
        int roleId = cmbRole.SelectedIndex + 1;
        string hash = PasswordHelper.HashPassword(txtPassword.Text);

        if (action == "Добавить")
        {
            if (UserStorage.Exists(txtLogin.Text.Trim()))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserStorage.Add(txtLogin.Text.Trim(), hash, roleId);
            MessageBox.Show("Пользователь успешно добавлен.", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else if (action == "Обновить")
        {
            if (comboBoxUsers.SelectedItem is not UserStorage.User u)
            {
                MessageBox.Show("Выберите пользователя для обновления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserStorage.Update(u.Id, txtLogin.Text.Trim(), hash, roleId, checkBoxActive.Checked);
            MessageBox.Show("Данные пользователя успешно обновлены.", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        LoadUsers();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        var frm = new LoginForm();
        Hide();
        frm.ShowDialog();
        Close();
    }
}

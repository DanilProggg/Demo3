namespace ClientApp;

partial class AdminForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblLogin = new Label();
        lblPassword = new Label();
        lblRole = new Label();
        lblAction = new Label();
        txtLogin = new TextBox();
        txtPassword = new TextBox();
        cmbRole = new ComboBox();
        cmbAction = new ComboBox();
        comboBoxUsers = new ComboBox();
        checkBoxActive = new CheckBox();
        dgv1 = new DataGridView();
        btnSave = new Button();
        btnBack = new Button();
        lblUsers = new Label();
        ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
        SuspendLayout();

        lblUsers.Text = "Пользователь:";
        lblUsers.Location = new Point(20, 18);
        lblUsers.Size = new Size(100, 23);

        comboBoxUsers.Location = new Point(130, 15);
        comboBoxUsers.Size = new Size(200, 23);
        comboBoxUsers.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;

        lblLogin.Text = "Логин:";
        lblLogin.Location = new Point(20, 55);
        lblLogin.Size = new Size(100, 23);

        txtLogin.Location = new Point(130, 52);
        txtLogin.Size = new Size(200, 23);
        txtLogin.Name = "txtLogin";

        lblPassword.Text = "Пароль:";
        lblPassword.Location = new Point(20, 88);
        lblPassword.Size = new Size(100, 23);

        txtPassword.Location = new Point(130, 85);
        txtPassword.Size = new Size(200, 23);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';

        lblRole.Text = "Роль:";
        lblRole.Location = new Point(20, 121);
        lblRole.Size = new Size(100, 23);

        cmbRole.Location = new Point(130, 118);
        cmbRole.Size = new Size(200, 23);
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

        lblAction.Text = "Действие:";
        lblAction.Location = new Point(20, 154);
        lblAction.Size = new Size(100, 23);

        cmbAction.Location = new Point(130, 151);
        cmbAction.Size = new Size(200, 23);
        cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;

        checkBoxActive.Text = "Заблокирован";
        checkBoxActive.Location = new Point(130, 185);
        checkBoxActive.Size = new Size(150, 23);
        checkBoxActive.Name = "checkBoxActive";

        btnSave.Text = "Сохранить";
        btnSave.Location = new Point(130, 220);
        btnSave.Size = new Size(100, 30);
        btnSave.Click += btnSave_Click;

        btnBack.Text = "Назад";
        btnBack.Location = new Point(240, 220);
        btnBack.Size = new Size(90, 30);
        btnBack.Click += btnBack_Click;

        dgv1.Location = new Point(20, 270);
        dgv1.Size = new Size(540, 160);
        dgv1.Name = "dgv1";
        dgv1.ReadOnly = true;
        dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        ClientSize = new Size(580, 450);
        Controls.AddRange([lblUsers, comboBoxUsers, lblLogin, txtLogin, lblPassword,
            txtPassword, lblRole, cmbRole, lblAction, cmbAction, checkBoxActive,
            btnSave, btnBack, dgv1]);
        Text = "Управление пользователями";
        StartPosition = FormStartPosition.CenterScreen;
        Load += AdminForm_Load;

        ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblLogin, lblPassword, lblRole, lblAction, lblUsers;
    private TextBox txtLogin, txtPassword;
    private ComboBox cmbRole, cmbAction, comboBoxUsers;
    private CheckBox checkBoxActive;
    private DataGridView dgv1;
    private Button btnSave, btnBack;
}

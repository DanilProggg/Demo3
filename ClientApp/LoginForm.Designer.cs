namespace ClientApp;

partial class LoginForm
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
        txtLogin = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        SuspendLayout();

        lblLogin.Text = "Логин:";
        lblLogin.Location = new Point(20, 22);
        lblLogin.Size = new Size(70, 23);

        lblPassword.Text = "Пароль:";
        lblPassword.Location = new Point(20, 58);
        lblPassword.Size = new Size(70, 23);

        txtLogin.Location = new Point(100, 19);
        txtLogin.Size = new Size(200, 23);
        txtLogin.Name = "txtLogin";

        txtPassword.Location = new Point(100, 55);
        txtPassword.Size = new Size(200, 23);
        txtPassword.Name = "txtPassword";

        btnLogin.Text = "Войти";
        btnLogin.Location = new Point(100, 95);
        btnLogin.Size = new Size(100, 30);
        btnLogin.Click += btnLogin_Click;

        ClientSize = new Size(340, 160);
        Controls.AddRange([lblLogin, lblPassword, txtLogin, txtPassword, btnLogin]);
        Text = "Авторизация";
        StartPosition = FormStartPosition.CenterScreen;

        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblLogin;
    private Label lblPassword;
    private TextBox txtLogin;
    private TextBox txtPassword;
    private Button btnLogin;
}

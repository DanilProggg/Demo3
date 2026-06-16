namespace ClientApp;

partial class UserForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblValueCaption = new Label();
        lbl1 = new Label();
        lblResultCaption = new Label();
        lbl2 = new Label();
        btnGet = new Button();
        btnSend = new Button();
        btnBack = new Button();
        SuspendLayout();

        lblTitle.Text = "Проверка данных с эмулятора";
        lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        lblTitle.Location = new Point(20, 15);
        lblTitle.Size = new Size(340, 25);

        lblValueCaption.Text = "Полученное значение:";
        lblValueCaption.Location = new Point(20, 60);
        lblValueCaption.Size = new Size(160, 23);

        lbl1.Text = "—";
        lbl1.Location = new Point(190, 60);
        lbl1.Size = new Size(200, 23);
        lbl1.Name = "lbl1";
        lbl1.Font = new Font("Segoe UI", 9, FontStyle.Bold);

        lblResultCaption.Text = "Результат проверки:";
        lblResultCaption.Location = new Point(20, 100);
        lblResultCaption.Size = new Size(160, 23);

        lbl2.Text = "—";
        lbl2.Location = new Point(190, 100);
        lbl2.Size = new Size(220, 23);
        lbl2.Name = "lbl2";

        btnGet.Text = "Получить";
        btnGet.Location = new Point(20, 145);
        btnGet.Size = new Size(110, 32);
        btnGet.Click += btnGet_Click;

        btnSend.Text = "Отправить";
        btnSend.Location = new Point(145, 145);
        btnSend.Size = new Size(110, 32);
        btnSend.Click += btnSend_Click;

        btnBack.Text = "Назад";
        btnBack.Location = new Point(270, 145);
        btnBack.Size = new Size(90, 32);
        btnBack.Click += btnBack_Click;

        ClientSize = new Size(420, 210);
        Controls.AddRange([lblTitle, lblValueCaption, lbl1, lblResultCaption, lbl2,
            btnGet, btnSend, btnBack]);
        Text = "Пользователь — проверка данных";
        StartPosition = FormStartPosition.CenterScreen;

        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle, lblValueCaption, lbl1, lblResultCaption, lbl2;
    private Button btnGet, btnSend, btnBack;
}

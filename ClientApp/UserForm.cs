using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ClientApp;

public partial class UserForm : Form
{
    public class Data
    {
        [JsonPropertyName("value")]
        public string Value { get; set; } = "";
    }

    public UserForm()
    {
        InitializeComponent();
        btnSend.Enabled = false;
    }

    private void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            string url = "http://127.0.0.1:4444/TransferSimulator/inn";
            using var client = new System.Net.WebClient();
            string json = client.DownloadString(url);
            Data? data = JsonSerializer.Deserialize<Data>(json);
            lbl1.Text = data?.Value ?? "";
            btnSend.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось получить данные. " + ex.Message,
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        bool identityCard = IsValidIdentityCard(lbl1.Text.Trim());

        lbl2.Text = identityCard ? "Данные корректны" : "ФИО содержит запрещенные символы";

        SaveTestResult(identityCard);
    }

    private bool IsValidFullName(string s) =>
        Regex.IsMatch(s, @"^([А-Яа-яёЁ]+) ([А-Яа-яёЁ]+) ([А-Яа-яёЁ]+)$");

    private bool IsValidEmail(string s) =>
        Regex.IsMatch(s, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

    private bool IsValidMobilePhone(string s) =>
        Regex.IsMatch(s, @"^\+7 \d{3} \d{3}-\d{2}-\d{2}$");

    private bool IsValidINN(string s) =>
        Regex.IsMatch(s, @"^\d{10}$");

    private bool IsValidSnils(string s) =>
        Regex.IsMatch(s, @"^\d{3}-\d{3}-\d{3} \d{2}$");

    private bool IsValidIdentityCard(string s) =>
        Regex.IsMatch(s, @"^\d{2} \d{2} \d{6}$");

    private void SaveTestResult(bool isValid)
    {
        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "ТестКейс_результат.txt");

        string result =
            $"Тест: Проверка ФИО на запрещенные символы\r\n" +
            $"Дата: {DateTime.Now}\r\n" +
            $"Полученное значение: {lbl1.Text}\r\n" +
            $"Получение с эмулятора: Успешно\r\n" +
            $"Получение без запрещенных символов: {(isValid ? "Успешно" : "Не успешно")}\r\n";

        File.WriteAllText(path, result);
        MessageBox.Show($"Результат сохранен на рабочем столе:\n{path}",
            "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        var frm = new LoginForm();
        Hide();
        frm.ShowDialog();
        Close();
    }
}

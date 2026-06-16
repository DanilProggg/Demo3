namespace TransferSimulatorApi;

static class DataGenerator
{
    static readonly Random rnd = new();

    static bool Corrupt() => rnd.Next(2) == 0;

    public static string GenerateFullName()
    {
        string[] last = ["Иванов", "Петров", "Сидоров", "Кузнецов", "Морозов"];
        string[] first = ["Иван", "Пётр", "Алексей", "Дмитрий", "Сергей"];
        string[] mid = ["Иванович", "Петрович", "Алексеевич", "Дмитриевич", "Сергеевич"];

        if (Corrupt())
            return $"{last[rnd.Next(last.Length)]}1 {first[rnd.Next(first.Length)]} {mid[rnd.Next(mid.Length)]}";

        return $"{last[rnd.Next(last.Length)]} {first[rnd.Next(first.Length)]} {mid[rnd.Next(mid.Length)]}";
    }

    public static string GenerateInn()
    {
        if (Corrupt())
            return string.Concat(Enumerable.Range(0, rnd.Next(1, 9)).Select(_ => rnd.Next(10)));

        return string.Concat(Enumerable.Range(0, 10).Select(_ => rnd.Next(10)));
    }

    public static string GenerateEmail()
    {
        string[] domains = ["mail.ru", "yandex.ru", "gmail.com"];
        string user = $"user{rnd.Next(1000)}";

        if (Corrupt())
            return $"{user}[at]{domains[rnd.Next(domains.Length)]}";

        return $"{user}@{domains[rnd.Next(domains.Length)]}";
    }

    public static string GenerateMobilePhone()
    {
        int a = rnd.Next(900, 1000);
        int b = rnd.Next(100, 1000);
        int c = rnd.Next(10, 100);
        int d = rnd.Next(10, 100);

        if (Corrupt())
            return $"8{a}{b}{c}{d}";

        return $"+7 {a} {b}-{c}-{d}";
    }

    public static string GenerateSnils()
    {
        int a = rnd.Next(100, 1000);
        int b = rnd.Next(100, 1000);
        int c = rnd.Next(100, 1000);
        int d = rnd.Next(10, 100);

        if (Corrupt())
            return $"{a}{b}{c}{d}";

        return $"{a}-{b}-{c} {d:D2}";
    }

    public static string GenerateIdentityCard()
    {
        int series1 = rnd.Next(10, 100);
        int series2 = rnd.Next(10, 100);
        int number = rnd.Next(100000, 1000000);

        if (Corrupt())
            return $"{series1}{series2}{number}";

        return $"{series1} {series2} {number:D6}";
    }
}

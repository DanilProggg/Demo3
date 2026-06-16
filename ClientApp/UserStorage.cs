namespace ClientApp;

static class UserStorage
{
    public record User(int Id, string Login, string Password, int Role, bool Blocked);

    static readonly List<User> users =
    [
        new User(1, "admin", PasswordHelper.HashPassword("admin"), 1, false),
        new User(2, "user",  PasswordHelper.HashPassword("user"),  2, false),
    ];

    static int nextId = 3;

    public static User? Find(string login, string hash) =>
        users.FirstOrDefault(u => u.Login == login && u.Password == hash);

    public static List<User> GetAll() => [.. users];

    public static bool Exists(string login) => users.Any(u => u.Login == login);

    public static void Add(string login, string hash, int role) =>
        users.Add(new User(nextId++, login, hash, role, false));

    public static void Update(int id, string login, string hash, int role, bool blocked)
    {
        int i = users.FindIndex(u => u.Id == id);
        if (i >= 0) users[i] = new User(id, login, hash, role, blocked);
    }

    public static void Block(string login)
    {
        int i = users.FindIndex(u => u.Login == login);
        if (i >= 0) users[i] = users[i] with { Blocked = true };
    }
}

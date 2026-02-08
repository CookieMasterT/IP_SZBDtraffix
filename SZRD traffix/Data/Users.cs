namespace SZRD_traffix
{
    public static class Users
    {
        public static User? CurrentUser { get; set; }

        public static List<User> users = new List<User>
        {
            new User("admin@szrd.pl", "traffix123", "Administrator", Role.Admin),
            new User("techie@szrd.pl", "engineergaming", "Bartosz Kowalski", Role.Technician),
            new User("tytbara77@edu.gdansk.pl", "zaq12wsx", "Tytus Barański", Role.User)
        };

        public static bool UserInList(string email, string password)
        {
            foreach (var item in users)
            {
                if (item.email == email && item.password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CurrentUserHasRole(Role role)
        {
            if (CurrentUser == null)
                return false;
            if (CurrentUser.role == role)
                return true;
            return false;
        }
        public static bool CurrentUserHasRole(Role[] roles)
        {
            if (CurrentUser == null)
                return false;
            foreach (var role in roles)
            {
                if (CurrentUser.role == role)
                {
                    return true;
                }
            }
            return false;
        }
        public static void LogUserIn(string email, string password)
        {
            foreach (var item in users)
            {
                if (item.email == email && item.password == password)
                {
                    CurrentUser = item;
                    return;
                }
            }
            throw new InvalidOperationException("Taki użytkownik nie istnieje, program nie powinienen próbować się zalogować jako on");
        }
        public static bool LogUserOut()
        {
            if (CurrentUser != null)
            {
                CurrentUser = null;
                return true;
            }
            return false;
        }
    }
    public class User
    {
        public string email;
        public string password;
        public string nazwa;
        public Role role;

        public User(string email, string password, string nazwa, Role role)
        {
            this.email = email;
            this.password = password;
            this.nazwa = nazwa;
            this.role = role;
        }
    }
    public enum Role
    {
        User,
        Technician,
        Admin
    }
}

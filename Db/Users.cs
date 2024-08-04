namespace getData.Db
{
    public class Users
    {
        public static bool CheckUser(string username, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.users
                    .FirstOrDefault(u => u.username == username);

                if (user != null)
                {

                    byte[] salt = Convert.FromBase64String(user.salt);
                    string hashedPassword = Password.HashPassword(password, salt);

                    if (hashedPassword == user.password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else 
                {
                    return false;
                }
            }
        }
    }
}

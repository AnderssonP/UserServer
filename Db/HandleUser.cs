using System.Data.SqlClient;

namespace getData.Db
{
    public class HandleUser
    {
        public static bool SendUserToDatabase(string username, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashedPassword = Password.HashPassword(password, salt);

            using (var context = new ApplicationDbContext())
            {
                var newUser = new UserInfo
                {
                    username = username,
                    password = hashedPassword,
                    salt = Convert.ToBase64String(salt)
                };

                try
                {
                    context.users.Add(newUser);
                    context.SaveChanges();
                    return true; 
                }
                catch (DbUpdateException ex)
                {
                    
                    if (ex.InnerException?.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                    {
                        
                        return false; 
                    }
                    throw; 
                }
            }
        }

    }
}

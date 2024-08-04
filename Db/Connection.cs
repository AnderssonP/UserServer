namespace getData.Db
{
    internal class Connection
    {
        public static void ConnectAndExecute()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var users = context.users.ToList();

                    Console.WriteLine("Connection successful!");

                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.id}, Name: {user.username}, Email: {user.password}");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public static void HandleException(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

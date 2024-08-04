namespace getData.Socket
{
    public class ClientHandler
    {
        private TcpClient tcpClient;

        public ClientHandler(TcpClient client)
        {
            tcpClient = client;
        }

        public void HandleClient()
        {
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading from client: " + ex.Message);
                    break;
                }

                if (bytesRead == 0)
                {
                    Console.WriteLine("Client disconnected.");
                    break;
                }

                var dataReceived = Encoding.UTF8.GetString(message, 0, bytesRead);
                Console.WriteLine("Received: " + dataReceived);

                var parts = dataReceived.Split(':');
                user(parts);

                byte[] sendBytes = Encoding.UTF8.GetBytes("Acknowledged");
                clientStream.Write(sendBytes, 0, sendBytes.Length);
            }

            tcpClient.Close();
        }

        private static void user(string[] parts)
        {
             var username = parts[0];
             var password = parts[1];
             var site = parts[2];
            if (site == "1")
            {
               var newUser = HandleUser.SendUserToDatabase(username, password);
            }
            else if (site == "2")
            {
               var userExist = Users.CheckUser(username, password);
            }
              
        }

    }
}

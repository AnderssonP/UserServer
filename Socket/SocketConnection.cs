namespace getData.Socket
{
    public class SocketConnection
    {
        private TcpListener listener;
        private bool isRunning = true;

        public SocketConnection(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            try
            {
                listener.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected: {0}", client.Client.RemoteEndPoint);

                    ClientHandler clientHandler = new ClientHandler(client);
                    Thread clientThread = new Thread(new ThreadStart(clientHandler.HandleClient));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                listener.Stop();
                Console.WriteLine("Server stopped.");
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}

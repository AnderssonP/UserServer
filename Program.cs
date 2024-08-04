class Program
{
    static void Main(string[] args)
    {
        Connection.ConnectAndExecute();
        int port = 8080;
        SocketConnection socketConnection = new SocketConnection(8080);
        socketConnection.Start();
    }

}

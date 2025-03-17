using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClient
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            
            
            Client client = new Client();
            client.ConnectAsync().Wait();

            Console.Write("Input you name: ");
            string user = Console.ReadLine();

            bool isExit = false;
            string message = string.Empty;

            while (!isExit) 
            {
                message = Console.ReadLine();

                await client.SendMessage(user, message);
            }
        }
    }

    class Client
    {
        private readonly string _url;
        HubConnection connection;

        public Client(string url = "https://localhost:7234/chatHub")
        {
            connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            connection.On<string, string>("ReceiveMessage", OnReceiveMessage);
            _url = url;
        }

        public async Task ConnectAsync()
        {
            await connection.StartAsync();
            await Console.Out.WriteLineAsync($"Connected to {_url}");
        }

        public async Task SendMessage(string user, string message)
        {
            await connection.SendAsync("SendMessage", user, message);
        }

        private void OnReceiveMessage(string user, string message)
        {
            Console.WriteLine(user+ ": " + message);
        }
    }
}

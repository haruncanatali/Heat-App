using Grpc.Net.Client;
using HeatApp.GrpcService;

class Program
{
    static async Task Main(string[] args)
    {
        string serverUri = "http://localhost:5247";
        var channel = GrpcChannel.ForAddress(serverUri);

        var heatClient = new TemperatureReceiver.TemperatureReceiverClient(channel);

        while (true)
        {
            TemperatureReply result = await heatClient.SendTemperatureAsync(new TemperatureRequest
            {
                Device = Guid.NewGuid().ToString(),
                Temperature = (new Random()).Next(-30,60)
            });
            
            System.Threading.Thread.Sleep(80);
        }
    }
}
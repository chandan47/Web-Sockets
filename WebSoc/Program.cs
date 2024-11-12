using Fleck;

var server = new WebSocketServer("ws://0.0.0.0:8181");
server.Start(ws =>
{
    ws.OnMessage = message =>
    {

        {
            ws.Send("replying back " + message);
            Console.WriteLine(message);
        }
    };
});
WebApplication.CreateBuilder(args).Build().Run();


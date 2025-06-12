using System;
using System.Threading;
using System.Threading.Tasks;
using SmtpServer;
using SmtpSink;
/*
 maybe make this a worker thread but for now just a console app

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
*/


var cfg = Config.LoadFromCli(args);
var service = new EmailCaptureService(port: cfg.Port);
var cts = new CancellationTokenSource();

Console.WriteLine($"Starting SMTP server on localhost:{cfg.Port}. Press Ctrl+C to stop...");
var serverTask = service.StartAsync(cts.Token);

Console.CancelKeyPress += (sender, e) =>
{
    switch (e.SpecialKey)
    {
        case ConsoleSpecialKey.ControlC:
        case ConsoleSpecialKey.ControlBreak:            
            e.Cancel = true;
            Console.WriteLine("Stopping SMTP server...");
            cts.Cancel();
            break;
    }
};

try
{
 await serverTask;
}
catch (OperationCanceledException)
{
 Console.WriteLine("SMTP server stopped.");
}

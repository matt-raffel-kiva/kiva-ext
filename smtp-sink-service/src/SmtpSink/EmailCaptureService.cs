using System.Buffers;
using MimeKit;
using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using SmtpSink.Properties;

namespace SmtpSink;

public class EmailCaptureService
{
    private readonly SmtpServer.SmtpServer _smtpServer;
    private readonly List<MimeMessage> _receivedEmails;

    public EmailCaptureService(int port = 2525)
    {
        _receivedEmails = new List<MimeMessage>();

        // Build SMTP server options
        var options = new SmtpServerOptionsBuilder()
            .ServerName("localhost")
            .Port(port)
            .Build();

        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMessageStore>(new SimpleMessageStore(_receivedEmails))
            .BuildServiceProvider();

        // Create SmtpServer with options and service provider
        _smtpServer = new SmtpServer.SmtpServer(options, serviceProvider);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return _smtpServer.StartAsync(cancellationToken);
    }

    public IReadOnlyList<MimeMessage> GetReceivedEmails()
    {
        return _receivedEmails.AsReadOnly();
    }
}

using System.Buffers;
using MimeKit;
using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;


namespace SmtpSink.Properties;

public class SimpleMessageStore : MessageStore
{
    private readonly List<MimeMessage> _receivedEmails;

    public SimpleMessageStore(List<MimeMessage> receivedEmails)
    {
        _receivedEmails = receivedEmails;
    }

    public override Task<SmtpResponse> SaveAsync(ISessionContext context, IMessageTransaction transaction, ReadOnlySequence<byte> buffer, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream(buffer.ToArray());
        var message = MimeMessage.Load(stream);
        _receivedEmails.Add(message);
        Console.WriteLine($"Received email from: {message.From}, subject: {message.Subject}");
        return Task.FromResult(SmtpResponse.Ok);
    }
}

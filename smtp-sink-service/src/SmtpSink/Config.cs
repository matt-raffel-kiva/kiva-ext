namespace SmtpSink;

public class Config
{
    public int Port { get; set; } = 2525;

    public static Config LoadFromCli(string[] args)
    {
        Config cfg = new Config();
        ArgumentParser parser = new ArgumentParser(args);
        cfg.Port = parser.GetArgument<int>("port", cfg.Port);
        return cfg;
    }
}
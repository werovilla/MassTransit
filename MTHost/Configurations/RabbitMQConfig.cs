namespace MTHost.Configurations;

public record RabbitMQConfig(IConfiguration configuration)
{
    private readonly IConfigurationSection _section = configuration.GetSection("RabbitMQ");
    public string HostAddress => _section.GetValue<string>("HostAddress");
    public string VirtualHost => _section.GetValue<string>("VirtualHost");
    public string Username => _section.GetValue<string>("Username");
    public string Password => _section.GetValue<string>("Password");
}

//Configuration file used to setup AWS EventBUS

namespace MTHost.Configurations;

public record AWSConfig(IConfiguration configuration)
{
    private readonly IConfigurationSection _section = configuration.GetSection("AWS");
    public string Host => _section.GetValue<string>("Host");
    public string AccessKey => _section.GetValue<string>("AccessKey");
    public string SecretKey => _section.GetValue<string>("SecretKey");
}
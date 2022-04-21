//Configuration file used to setup Azure EventBUS

namespace MTHost.Configurations;

public record AzureConfig(IConfiguration configuration)
{
    private readonly IConfigurationSection _section = configuration.GetSection("Azure");
    public string EndPoint => _section.GetValue<string>("EndPoint");
    public string SharedAccessKeyName => _section.GetValue<string>("SharedAccessKeyName");
    public string SharedAccessKey => _section.GetValue<string>("SharedAccessKey");
    public string EntityPath => _section.GetValue<string>("EntityPath");
    public string ConnectionString => $"Endpoint={EndPoint};SharedAccessKeyName={SharedAccessKeyName};SharedAccessKey={SharedAccessKey};EntityPath={EntityPath}";
}
using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient: ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}/api/c/platforms", httpContent);
        Console.WriteLine(response.IsSuccessStatusCode
            ? "--> Sync Post to commandService was OK!"
            : "--> Sync Post to commandService was NOT OK!");
    }
}
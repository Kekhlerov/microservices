using PlatformService.Dtos;

namespace PlatformService.AsyncDataServices;

public interface IMessageBusClient
{
    void PublishedNewPlatform(PlatformPublishedDto platformPublishedDto);
}
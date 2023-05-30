using CommandService.Models;

namespace CommandService.Data;

public interface ICommandRepo
{
    IEnumerable<Platform> GetAllPlatforms();
    void CreatePlatform(Platform platform);
    bool PlatformExists(int platformId);
    
    
    IEnumerable<Command> GetCommandsForPlatform(int platformId);
    Command? GetCommand(int platformId, int commandId);
    void CreateCommand(int platformId, Command? command);
    
    bool SaveChanges();
}
namespace NotepadWebApp.Service.Controllers.Entities.UserEntities;

public class UserFilter
{
    public string? NicknamePart { get; set; }
    public string? EmailPart { get; set; }
    
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
    
    public string? Role { get; set; }
}
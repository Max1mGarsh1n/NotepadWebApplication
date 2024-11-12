namespace BL.Users.Entity;

public class UpdateUserModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public string UserNickname { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime UnbanningDate { get; set; }
    public string Role { get; set; }
}
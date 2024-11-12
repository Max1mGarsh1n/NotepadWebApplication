namespace NotepadWebApp.Service.Controllers.Users.Entities;

public class RegisterUserRequest
{
    public string Nickname { get; set; }
    public string HashPassword { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime UnbanningDate { get; set; }
    public string Role { get; set; }
}
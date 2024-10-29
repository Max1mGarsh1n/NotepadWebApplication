using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace NotepadWebApp.DataAccess.Entities;

[Table("User")]
public class UserEntity : BaseEntity
{
    public string User_nickname { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime Registration_date { get; set; }
    public DateTime Unbanning_date { get; set; }
    public string PasswordHash { get; set; }
    
    public virtual ICollection<NoteEntity> Notes { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace NotepadWebApp.DataAccess.Entities;

[Table("Note")]
public class NoteEntity : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }
    
    public virtual ICollection<NoteTagEntity> NoteTags { get; set; }
}
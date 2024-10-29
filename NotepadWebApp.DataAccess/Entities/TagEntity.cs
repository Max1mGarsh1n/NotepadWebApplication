using System.ComponentModel.DataAnnotations.Schema;

namespace NotepadWebApp.DataAccess.Entities;

[Table("Tag")]
public class TagEntity : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<NoteTagEntity> NoteTags { get; set; }
}
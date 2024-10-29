using System.ComponentModel.DataAnnotations.Schema;

namespace NotepadWebApp.DataAccess.Entities;

[Table("Category")]
public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<NoteEntity> Notes { get; set; }
}
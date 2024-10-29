using System.ComponentModel.DataAnnotations.Schema;

namespace NotepadWebApp.DataAccess.Entities;

[Table("NoteTag")]
public class NoteTagEntity : BaseEntity
{
    public int NoteId { get; set; }
    public virtual NoteEntity Note { get; set; }

    public int TagId { get; set; }
    public virtual TagEntity Tag { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryService.Model
{
    [Table("tblBooks")]
    public class tblBooks
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? BooKId { get; set; }

        public string? Name { get; set; }

        public string? AuthorName { get; set; }
    }
}

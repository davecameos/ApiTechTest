using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AareonTechnicalTest.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public bool IsAdmin { get; set; }
    }
}

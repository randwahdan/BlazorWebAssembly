using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUDApp.Server.Models
{
    [Table("Contact", Schema ="dbo")]
    public class Contact
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string FirstName { get; set; }
        
        [Required] 
        public string LastName { get; set; }
        
        [Required] 
        public string Email { get;set; }
        
        [Required] 
        public string PhoneNumber { get; set; }
    }
}

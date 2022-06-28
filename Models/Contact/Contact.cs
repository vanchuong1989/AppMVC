using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC.Models.Contact
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="You have to Enter {0}")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You have to Enter {0}")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Email is wrong format")]
        
        public string Email { get; set; }

        [DisplayName("Date Sent")]

        public DateTime DateSent { get; set; }

        [StringLength(50)]
        public string Message { get; set; }

        [StringLength (50)]
        [Phone(ErrorMessage ="Must be a phone number")]
        [DisplayName("Phone Number")]


        public string Phone { get; set; }

    }
}

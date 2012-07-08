using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
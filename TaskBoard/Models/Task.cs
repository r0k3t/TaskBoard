using System;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public int ProjectId { get; set; }
        public int CreatedById { get; set; }
        public int TaskOwnerId { get; set; }
        public int UpdatedById { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public User Owner { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public Project Project { get; set; }
        public int LocationTop { get; set; }
        public int LocationLeft { get; set; }
    }
}
using System;

namespace Ways_DAO.Models
{
    public class Choice
    {
        public int Id { get; set; }

        public string Label { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Question Question { get; set; }

        public Choice()
        {
            CreatedAt = DateTime.Now;
        }

        public Choice(string label, DateTime createdAt)
        {
            Label = label;
            CreatedAt = DateTime.Now;
        }
    }
}
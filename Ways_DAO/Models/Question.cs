using System;
using System.Collections.Generic;

namespace Ways_DAO.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public List<AbstractChoice> Choices { get; set; }

        public Question()
        {
            CreatedAt = DateTime.Now;
        }

        protected Question(string label, int position, DateTime createdAt)
        {
            Label = label;
            Position = position;
            CreatedAt = createdAt;
        }
    }
}
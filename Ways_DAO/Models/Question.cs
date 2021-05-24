using System;
using System.Collections.Generic;

namespace Ways_DAO.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Position { get; set; }
        
        public QuestionTypeEnum Type { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public List<Choice> Choices { get; set; }

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
        
        public enum QuestionTypeEnum
        {
            Orientation, Game
        }
    }
}
using System;

namespace Ways_DAO.Models
{
    public class AbstractChoice
    {
        public int Id { get; set; }

        public string Label { get; set; }
        public DateTime CreatedAt { get; set; }

        public AbstractChoice()
        {
            CreatedAt = DateTime.Now;
        }

        public AbstractChoice(string label, DateTime createdAt)
        {
            Label = label;
            CreatedAt = DateTime.Now;
        }
    }
}
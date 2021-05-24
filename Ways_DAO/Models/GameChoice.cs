using System;

namespace Ways_DAO.Models
{
    public class GameChoice : AbstractChoice
    {
        public int Value { get; set; }

        public GameChoice(string label, DateTime createdAt, int value) : base(label, createdAt)
        {
            Value = value;
        }
    }
}
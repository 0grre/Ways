using System;
using System.Collections.Generic;
using Ways_DAO.Models;

namespace Ways_DAO.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public QuestionnaireTypeEnum Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Candidate { get; set; }

        public List<Answer> Answers { get; set; }

        public Questionnaire()
        {
            CreatedAt = DateTime.Now;
        }

        public Questionnaire(QuestionnaireTypeEnum type, User candidate)
        {
            Type = type;
            Candidate = candidate;
            CreatedAt = DateTime.Now;
        }

        public List<Answer> AddAnswer(Answer answer)
        {
            Answers.Add(answer);

            return Answers;
        }
    }

    public enum QuestionnaireTypeEnum
    {
        Game,
        Orientation
    }
}
using System;

namespace Ways_DAO.Models
{
    public class Answer
    {
        public DateTime CreatedAt { get; set; }
        
        public Questionnaire Questionnaire { get; set; }
        public GameChoice GameChoice { get; set; }
        public OrientationChoice OrientationChoice { get; set; }

        public Answer()
        {
            CreatedAt = DateTime.Now;
        }

        public Answer(Questionnaire questionnaire, GameChoice choice)
        {
            Questionnaire = questionnaire;
            GameChoice = choice;
            CreatedAt = DateTime.Now;
        }

        public Answer(Questionnaire questionnaire, OrientationChoice choice)
        {
            Questionnaire = questionnaire;
            OrientationChoice = choice;
            CreatedAt = DateTime.Now;
        }
    }
}
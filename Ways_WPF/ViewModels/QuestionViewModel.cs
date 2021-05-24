using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ways_DAO.Models;
using Ways_DAO.Repositories;
using Ways_WPF.Services;

namespace Ways_WPF.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        #region Interfaces

        private IFrameNavigationService _navigationService;
        public ICommand AnswerQuestionCommand { get; set; }
        public ICommand CheckRadioButtonCommand { get; set; }

        #endregion

        #region Repositories

        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;

        #endregion

        #region Properties

        private StartViewModel.UserQuestionTypeParameter _parameter;
        private User _user;
        private Question.QuestionTypeEnum _type;
        private List<Question> _questions;
        private List<Choice> _currentChoices;
        private Question _currentQuestion;
        private string _currentQuestionNumberLabel;
        private Answer _currentAnswer;

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                RaisePropertyChanged();
            }
        }

        public List<Question> Questions
        {
            get => _questions;
            set => _questions = value;
        }

        public List<Choice> CurrentChoices
        {
            get => _currentChoices;
            set
            {
                _currentChoices = value;
                RaisePropertyChanged();
            }
        }

        public string CurrentQuestionNumberLabel
        {
            get => _currentQuestionNumberLabel;
            set
            {
                _currentQuestionNumberLabel = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        public QuestionViewModel(IFrameNavigationService navigationService)
        {
            AnswerQuestionCommand = new RelayCommand(ActionAnswerQuestions);
            CheckRadioButtonCommand = new RelayCommand<Choice>(ActionCheckRadio);

            _navigationService = navigationService;
            _questionRepository = new QuestionRepository();
            _answerRepository = new AnswerRepository();
            CurrentQuestion = new Question();
            CurrentChoices = new List<Choice>();

            _parameter = _navigationService.Parameter as StartViewModel.UserQuestionTypeParameter;

            if (_parameter != null)
            {
                _user = _parameter.User;
                _type = _parameter.Type == nameof(Question.QuestionTypeEnum.Game)
                    ? Question.QuestionTypeEnum.Game
                    : Question.QuestionTypeEnum.Orientation;
            }

            
            _questions = new List<Question>(_questionRepository.FindAllByType(_type));

            _currentQuestion = _questions[0];
            _currentQuestionNumberLabel = $"Question {CurrentQuestion.Position}";
            _currentChoices = CurrentQuestion.Choices;
        }

        private void ActionCheckRadio(Choice choice)
        {
            if (_type == Question.QuestionTypeEnum.Game)
            {
                GameChoice gameChoice = new GameChoice();
                
                gameChoice.Id = choice.Id;

                _currentAnswer = new Answer(_user, gameChoice);
            }
            else
            {
                OrientationChoice orientationChoice = new OrientationChoice();
                
                orientationChoice.Id = choice.Id;

                _currentAnswer = new Answer(_user, orientationChoice);
            }
        }

        private void ActionAnswerQuestions()
        {
            if (_currentAnswer == null)
            {
                MessageBox.Show("Veuillez répondre");
                return;
            }
            _answerRepository.Create(_currentAnswer);

            Question nextQuestion = null;
            try
            {
                nextQuestion = _questions[CurrentQuestion.Position];
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show($"{e}");
            }

            CurrentQuestion = nextQuestion;
            if (CurrentQuestion == null) return;

            CurrentChoices = CurrentQuestion.Choices;
            CurrentQuestionNumberLabel = $"Question {CurrentQuestion.Position}";
            MessageBox.Show($"{CurrentQuestion.Label}");
            _currentAnswer = null;
        }
    }
}
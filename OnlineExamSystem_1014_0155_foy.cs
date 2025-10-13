// 代码生成时间: 2025-10-14 01:55:27
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Essentials;

// Define a simple Exam Question model.
public class ExamQuestion
{
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
    public string CorrectAnswer { get; set; }
}

// Define a ViewModel for the Exam.
[XamlCompilation(XamlCompilationOptions.Compile)]
public class ExamViewModel : BindableObject
{
    private List<ExamQuestion> questions;
    private int currentQuestionIndex;
    private string selectedOption;
    private bool isCompleted;
    private int score;

    public ExamViewModel()
    {
        questions = new List<ExamQuestion>();
        currentQuestionIndex = 0;
        isCompleted = false;
        score = 0;
    }

    public List<ExamQuestion> Questions
    {
        get => questions;
        set => SetProperty(ref questions, value);
    }

    public int CurrentQuestionIndex
    {
        get => currentQuestionIndex;
        set => SetProperty(ref currentQuestionIndex, value);
    }

    public string SelectedOption
    {
        get => selectedOption;
        set
        {
            if (SetProperty(ref selectedOption, value))
            {
                CheckAnswer();
            }
        }
    }

    public bool IsCompleted
    {
        get => isCompleted;
        set => SetProperty(ref isCompleted, value);
    }

    public int Score
    {
        get => score;
        set => SetProperty(ref score, value);
    }

    public async Task NavigateToNextQuestion()
    {
        if (CurrentQuestionIndex < Questions.Count - 1)
        {
            CurrentQuestionIndex++;
        }
        else
        {
            IsCompleted = true;
            await App.Current.MainPage.DisplayAlert("Exam Completed", "You have completed the exam. Your score is: " + Score, "OK");
        }
    }

    private void CheckAnswer()
    {
        if (Questions[CurrentQuestionIndex].CorrectAnswer == SelectedOption)
        {
            Score++;
        }
    }
}

// Define the MainPage of the MAUI application.
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ExamViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Load questions into the ViewModel.
        (BindingContext as ExamViewModel).Questions = LoadExamQuestions();
    }

    private List<ExamQuestion> LoadExamQuestions()
    {
        // This is where you would fetch questions from a database or service.
        // For simplicity, we'll hardcode some questions.
        var questions = new List<ExamQuestion>
        {
            new ExamQuestion {
                QuestionText = "What is the capital of France?",
                Options = new List<string> {"Paris", "London", "Berlin", "Madrid"},
                CorrectAnswer = "Paris"
            },
            // ... Add more questions here.
        };

        return questions;
    }
}

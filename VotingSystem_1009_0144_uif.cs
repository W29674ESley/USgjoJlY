// 代码生成时间: 2025-10-09 01:44:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace VotingApp
{
    public class VotingViewModel
    {
        // Dictionary to hold the options and their votes
        private Dictionary<string, int> options = new Dictionary<string, int>();

        public VotingViewModel()
        {
            // Initialize some options
            AddOption("Option 1");
            AddOption("Option 2");
            AddOption("Option 3");
        }

        // Method to add an option
        public void AddOption(string option)
        {
            if (!options.ContainsKey(option))
            {
                options[option] = 0;
            }
            else
            {
                throw new ArgumentException("Option already exists.");
            }
        }

        // Method to vote for an option
        public void VoteForOption(string option)
        {
            if (options.ContainsKey(option))
            {
                options[option]++;
            }
            else
            {
                throw new KeyNotFoundException("Option not found.");
            }
        }

        // Method to get the vote count for an option
        public int GetVotesForOption(string option)
        {
            if (options.TryGetValue(option, out int votes))
            {
                return votes;
            }
            else
            {
                throw new KeyNotFoundException("Option not found.");
            }
        }

        // Method to get all options with their vote counts
        public Dictionary<string, int> GetAllVotes()
        {
            return new Dictionary<string, int>(options); // Return a copy of the dictionary
        }
    }

    // Main page for the MAUI application
    public class MainPage : ContentPage
    {
        private VotingViewModel viewModel;

        public MainPage()
        {
            viewModel = new VotingViewModel();

            // Layout for the options
            var optionsLayout = new StackLayout();

            // Button to add a vote
            Button voteButton = new Button
            {
                Text = "Vote"
            };
            voteButton.Clicked += OnVoteButtonClicked;

            // Label to display the total votes
            Label totalVotesLabel = new Label
            {
                Text = "Total Votes: " + string.Join(", ", viewModel.GetAllVotes().Select(kvp => kvp.Key + ": " + kvp.Value))
            };

            // Add the vote button and total votes label to the layout
            optionsLayout.Children.Add(voteButton);
            optionsLayout.Children.Add(totalVotesLabel);

            // Add the options layout to the page
            Content = optionsLayout;
        }

        // Event handler for the vote button click
        private async void OnVoteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Simulate voting for a random option
                var option = viewModel.GetAllVotes().ElementAt(new Random().Next(viewModel.GetAllVotes().Count)).Key;
                viewModel.VoteForOption(option);

                // Update the total votes label
                (Label)Content.Children[1].Text = "Total Votes: " + string.Join(", ", viewModel.GetAllVotes().Select(kvp => kvp.Key + ": " + kvp.Value));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

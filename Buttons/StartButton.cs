/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System;
using System.Collections.Generic;
using System.Windows;
using _312554Hangman.Screens;
using _312554Hangman.Utils;

namespace _312554Hangman.Buttons
{
    /// <summary>
    /// The button that begins the game.
    /// </summary>
    public class StartButton : Button
    {
        // Variables to control the random word:
        private Random random;
        private int difficulty;
        private List<string> easyWords;
        private List<string> mediumWords;
        private List<string> hardWords;

        public StartButton(Screen screen, int x, int y, int width, int height, int fontSize)
            : base(screen, "Start Game", x, y, width, height, fontSize)
        {
            random = new Random();
            // Get all the random words from files:
            easyWords = WordFetcher.FetchWords("easy");
            mediumWords = WordFetcher.FetchWords("medium");
            hardWords = WordFetcher.FetchWords("hard");
        }

        public override void OnClick(object sender, RoutedEventArgs e)
        {
            // Choose random word from appropriate list:
            string word = "";
            int wordIndex = random.Next(0, 10);
            if (difficulty == 0)
                word = easyWords[wordIndex];
            else if (difficulty == 1)
                word = mediumWords[wordIndex];
            else if (difficulty == 2)
                word = hardWords[wordIndex];

            // Notify all the screens about the current word:
            GetMainWindow().playScreen.StartNewGame(word);
            GetMainWindow().winScreen.SetCurrentWord(word);
            GetMainWindow().loseScreen.SetCurrentWord(word);

            // Transition to the play screen:
            GetMainWindow().SetCurrentScreen(GetMainWindow().playScreen);
        }

        public void SetDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
        }
    }
}
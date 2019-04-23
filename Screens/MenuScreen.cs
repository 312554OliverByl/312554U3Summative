/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System;
using System.Windows.Controls;
using _312554Hangman.Buttons;
using _312554Hangman.Utils;

namespace _312554Hangman.Screens
{
    /// <summary>
    /// The main menu where the player can select difficulty and start the game.
    /// </summary>
    public class MenuScreen : Screen
    {
        public MenuScreen(MainWindow window) : base(window) { }

        protected override void LoadElements()
        {
            // Game title.
            Label title = new Label();
            title.Content = "Hangman";
            title.FontSize = 48;
            Canvas.SetTop(title, 20);
            Canvas.SetLeft(title, 280);
            AddChild(title);

            // Game description.
            Label desc = new Label();
            desc.Content = "By Oliver Byl" + Environment.NewLine +
                           "For ICS3U Unit 3, 2019";
            Canvas.SetTop(desc, 370);
            AddChild(desc);

            // Start game.
            StartButton start = new StartButton(this, 290, 210, 200, 60, 24);
            AddChild(start);

            // Difficulty selector label.
            Label difficultyExplainer = new Label();
            difficultyExplainer.Content = "Select the difficulty:";
            difficultyExplainer.FontSize = 14;
            Canvas.SetLeft(difficultyExplainer, 290);
            Canvas.SetTop(difficultyExplainer, 130);
            AddChild(difficultyExplainer);

            // Change difficulty.
            DifficultySelector selector = new DifficultySelector(start, 290, 160, 100, 30, 16);
            AddChild(selector);

            // Quit game.
            QuitButton quit = new QuitButton(this, 290, 290, 200, 60, 24);
            AddChild(quit);
        }
    }
}
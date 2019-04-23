/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using _312554Hangman.Buttons;
using _312554Hangman.Utils;

namespace _312554Hangman.Screens
{
    /// <summary>
    /// The screen in view while the player is playing the game.
    /// </summary>
    public class PlayScreen : Screen
    {
        // Keep track of the status of the game:
        private string currentWord;
        private int guesses, wrongGuesses;
        private TextBlock output;

        // The "keyboard" the player uses to make their guesses.
        private GuessBoard board;

        // Hangman shapes:
        private List<UIElement> man;

        public PlayScreen(MainWindow window) : base(window) { }

        protected override void LoadElements()
        {
            currentWord = null;

            // Return to menu.
            ReturnButton returnToMenu = new ReturnButton(this, 10, 330, 120, 30, 14);
            AddChild(returnToMenu);

            // Quit button.
            QuitButton quit = new QuitButton(this, 10, 370, 120, 30, 14);
            AddChild(quit);
            
            // Output label.
            output = new TextBlock();
            output.FontSize = 42;
            Canvas.SetLeft(output, 30);
            Canvas.SetTop(output, 50);
            AddChild(output);

            // Guess board.
            board = new GuessBoard(this, 440, 290, 30, 16);
            AddChild(board);

            // Hangman structure:
            Line structBase = LazyLine.CreateLine(630, 260, 750, 260, 5);
            AddChild(structBase);

            Line structPole = LazyLine.CreateLine(730, 15, 730, 260, 5);
            AddChild(structPole);

            Line structTop = LazyLine.CreateLine(570, 15, 733, 15, 5);
            AddChild(structTop);

            Line structSupport = LazyLine.CreateLine(700, 15, 730, 45, 5);
            AddChild(structSupport);

            Line rope = LazyLine.CreateLine(590, 15, 590, 35, 2);
            AddChild(rope);

            // Elements to create the man:
            man = new List<UIElement>();

            Ellipse head = new Ellipse();
            Canvas.SetTop(head, 35);
            Canvas.SetLeft(head, 565);
            head.Width = 50;
            head.Height = 50;
            head.Stroke = Brushes.Black;
            head.StrokeThickness = 3;
            man.Add(head);

            Line body = LazyLine.CreateLine(590, 85, 590, 170, 3);
            man.Add(body);

            Line leftArm = LazyLine.CreateLine(590, 85, 570, 140, 3);
            man.Add(leftArm);

            Line rightArm = LazyLine.CreateLine(590, 85, 610, 140, 3);
            man.Add(rightArm);

            Line leftLeg = LazyLine.CreateLine(590, 170, 570, 235, 3);
            man.Add(leftLeg);

            Line rightLeg = LazyLine.CreateLine(590, 170, 610, 235, 3);
            man.Add(rightLeg);

            foreach (UIElement element in man)
                AddChild(element);
        }

        /// <summary>
        /// Start a new game using the given word.
        /// </summary>
        /// <param name="word"></param>
        public void StartNewGame(string word)
        {
            // Reset the wrong guess count.
            wrongGuesses = 0;

            // Hide all parts of the hangman.
            foreach (UIElement element in man)
                element.Visibility = Visibility.Hidden;

            // Re-enable all buttons the guessing board.
            board.Reset();

            // Update the current word and reset the output text to just underscores.
            currentWord = word;
            output.Text = "";
            for (int i = 0; i < currentWord.Length; i++)
                output.Text += "_ ";
            output.Text += Environment.NewLine + Environment.NewLine;
        }

        public void MakeGuess(char letter)
        {
            guesses++;
            // If guesses is 14, we need to start a new line to make sure the guesses don't
            // intersect with the hangman.
            if (guesses == 14)
                output.Text += Environment.NewLine;

            // Add the guessed letter to the output, regardless if it's correct or not.
            output.Text += letter.ToString() + " ";
            
            if (currentWord.Contains(letter))
            {
                // Look through all the words in the target word, and replace letters in the
                // output as necessary.
                int index = 0;
                foreach(char c in currentWord)
                {
                    if(c == letter)
                    {
                        string beforeLetter = output.Text.Substring(0, index * 2);
                        string afterLetter = output.Text.Substring((index * 2) + 1);
                        output.Text = beforeLetter + letter.ToString() + afterLetter;
                    }

                    index++;
                }
            }
            else
            {
                // If we haven't guessed wrong too many times, show a new piece of the hangman.
                // If we've run out of guesses, make the player lose the game.
                if (wrongGuesses < 5)
                    man[wrongGuesses++].Visibility = Visibility.Visible;
                else
                    GetMainWindow().SetCurrentScreen(GetMainWindow().loseScreen);
            }

            // If there are no underscores in the output text, we know that there are no unguessed
            // letters and therefore the player has won the game.
            if (!output.Text.Contains('_'))
                GetMainWindow().SetCurrentScreen(GetMainWindow().winScreen);
        }
    }
}
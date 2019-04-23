/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows.Controls;
using System.Windows;
using _312554Hangman.Screens;

namespace _312554Hangman.Utils
{
    /// <summary>
    /// The collection of buttons that lets the player make their guesses.
    /// </summary>
    public class GuessBoard : StackPanel
    {
        private Screen screen;

        // Guessable letters, in QWERTY keyboard format.
        private char[] board = 
        {
            'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
            'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ' ',
            'z', 'x', 'c', 'v', 'b', 'n', 'm', ' ', ' ', ' '
        };

        public GuessBoard(Screen screen, int x, int y, int buttonSize, int buttonFontSize)
        {
            this.screen = screen;
            Orientation = Orientation.Vertical;
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            
            // Make three rows of 10 buttons each to create the keyboard.
            for(int row = 0; row < 3; row++)
            {
                StackPanel rowPanel = new StackPanel();
                rowPanel.Orientation = Orientation.Horizontal;

                for(int column = 0; column < 10; column++)
                {
                    char letter = board[column + row * 10];
                    if (letter == ' ')
                        continue;

                    Button button = new Button();
                    button.Content = letter;
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.FontSize = buttonFontSize;
                    button.Click += OnButtonClick;

                    rowPanel.Children.Add(button);
                }

                Children.Add(rowPanel);
            }
        }

        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false;

            screen.GetMainWindow().playScreen.MakeGuess((char) button.Content);
        }

        public void Reset()
        {
            foreach (StackPanel row in Children)
                foreach (Button button in row.Children)
                    button.IsEnabled = true;
        }
    }
}

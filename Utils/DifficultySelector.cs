/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows.Controls;
using _312554Hangman.Buttons;

namespace _312554Hangman.Utils
{
    /// <summary>
    /// The drop-down menu that lets the player select their difficulty.
    /// </summary>
    public class DifficultySelector : ComboBox
    {
        private StartButton targetButton;

        public DifficultySelector(StartButton targetButton, int x, int y, int width, int height, int fontSize)
        {
            this.targetButton = targetButton;

            Width = width;
            Height = height;
            FontSize = fontSize;
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);

            Items.Add("Easy");
            Items.Add("Medium");
            Items.Add("Hard");
            SelectedIndex = 0;

            SelectionChanged += OnChange;
        }

        private void OnChange(object sender, SelectionChangedEventArgs e)
        {
            targetButton.SetDifficulty(SelectedIndex);
        }
    }
}
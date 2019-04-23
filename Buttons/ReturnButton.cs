/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows;
using _312554Hangman.Screens;

namespace _312554Hangman.Buttons
{
    /// <summary>
    /// The button that returns the player to the main menu.
    /// </summary>
    public class ReturnButton : Button
    {
        public ReturnButton(Screen screen, int x, int y, int width, int height, int fontSize)
            : base(screen, "Return to Menu", x, y, width, height, fontSize)
        { }

        public override void OnClick(object sender, RoutedEventArgs e)
        {
            GetMainWindow().SetCurrentScreen(GetMainWindow().menuScreen);
        }
    }
}
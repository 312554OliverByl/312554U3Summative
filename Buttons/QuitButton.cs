/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System;
using System.Windows;
using _312554Hangman.Screens;

namespace _312554Hangman.Buttons
{
    /// <summary>
    /// The button that quits the game. (Closes the window.)
    /// </summary>
    public class QuitButton : Button
    {
        public QuitButton(Screen screen, int x, int y, int width, int height, int fontSize)
            : base(screen, "Quit Game", x, y, width, height, fontSize)
        { }

        public override void OnClick(object sender, RoutedEventArgs e)
        {
            GetMainWindow().Close();
        }
    }
}
/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows;
using System.Windows.Controls;
using _312554Hangman.Screens;

namespace _312554Hangman.Buttons
{
    /// <summary>
    /// A class to automatically add a click event handler to buttons.
    /// </summary>
    public abstract class Button : System.Windows.Controls.Button
    {
        private Screen screen;

        public Button(Screen screen, string text, int x, int y, int width, int height, int fontSize)
        {
            this.screen = screen;
            Content = text;
            Width = width;
            Height = height;
            FontSize = fontSize;
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);

            Click += OnClick;
        }

        public abstract void OnClick(object sender, RoutedEventArgs e);

        public MainWindow GetMainWindow()
        {
            return screen.GetMainWindow();
        }
    }
}

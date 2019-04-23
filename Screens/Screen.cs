/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows;
using System.Windows.Controls;

namespace _312554Hangman.Screens
{
    /// <summary>
    /// Base class for the game screens.
    /// </summary>
    public abstract class Screen
    {
        private MainWindow window;
        private Canvas canvas;

        public Screen(MainWindow window)
        {
            this.window = window;
            canvas = new Canvas();

            LoadElements();
        }

        protected abstract void LoadElements();

        public Canvas GetCanvas()
        {
            return canvas;
        }

        public MainWindow GetMainWindow()
        {
            return window;
        }

        public void AddChild(UIElement child)
        {
            canvas.Children.Add(child);
        }
    }
}
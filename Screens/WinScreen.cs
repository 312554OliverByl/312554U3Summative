/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using _312554Hangman.Buttons;
using _312554Hangman.Utils;

namespace _312554Hangman.Screens
{
    /// <summary>
    /// Screen that shows when the player wins the game.
    /// </summary>
    public class WinScreen : Screen
    {
        private Label wordReveal;

        public WinScreen(MainWindow window) : base(window) { }
        
        protected override void LoadElements()
        {
            // Happiness
            Label message = new Label();
            message.Content = "You Win!";
            message.FontSize = 48;
            Canvas.SetTop(message, 20);
            Canvas.SetLeft(message, 300);
            AddChild(message);

            // Smile
            Ellipse head = new Ellipse();
            Canvas.SetTop(head, 90);
            Canvas.SetLeft(head, 310);
            head.Width = 180;
            head.Height = 180;
            head.Stroke = Brushes.Black;
            head.StrokeThickness = 3;
            AddChild(head);

            Ellipse leftEye = new Ellipse();
            leftEye.Fill = Brushes.Black;
            leftEye.Width = 10;
            leftEye.Height = 10;
            Canvas.SetTop(leftEye, 130);
            Canvas.SetLeft(leftEye, 360);
            AddChild(leftEye);

            Ellipse rightEye = new Ellipse();
            rightEye.Fill = Brushes.Black;
            rightEye.Width = 10;
            rightEye.Height = 10;
            Canvas.SetTop(rightEye, 130);
            Canvas.SetLeft(rightEye, 430);
            AddChild(rightEye);

            Line mouth0 = LazyLine.CreateLine(370, 220, 350, 200, 3);
            AddChild(mouth0);
            
            Line mouth1 = LazyLine.CreateLine(370, 220, 430, 220, 3);
            AddChild(mouth1);

            Line mouth2 = LazyLine.CreateLine(430, 220, 450, 200, 3);
            AddChild(mouth2);

            // Word reveal
            wordReveal = new Label();
            wordReveal.FontSize = 24;
            Canvas.SetTop(wordReveal, 280);
            Canvas.SetLeft(wordReveal, 250);
            AddChild(wordReveal);

            // Return to menu
            ReturnButton returnToMenu = new ReturnButton(this, 180, 330, 200, 60, 24);
            AddChild(returnToMenu);

            // Quit button
            QuitButton quit = new QuitButton(this, 420, 330, 200, 60, 24);
            AddChild(quit);
        }

        public void SetCurrentWord(string word)
        {
            wordReveal.Content = "The word was: " + word;
        }
    }
}
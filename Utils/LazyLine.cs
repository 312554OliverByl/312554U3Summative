/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows.Shapes;
using System.Windows.Media;

namespace _312554Hangman.Utils
{
    /// <summary>
    /// Helper class to compactify line creation.
    /// </summary>
    public static class LazyLine
    {
        public static Line CreateLine(int x1, int y1, int x2, int y2, int strokeSize)
        {
            Line result = new Line();
            result.X1 = x1;
            result.Y1 = y1;
            result.X2 = x2;
            result.Y2 = y2;
            result.Stroke = Brushes.Black;
            result.StrokeThickness = strokeSize;
            return result;
        }
    }
}
/* Unit 3 Summative - Hangman
 * April 23, 2019
 * Oliver Byl */
using System.Windows;
using _312554Hangman.Screens;

namespace _312554Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // All the screens the game can use.
        public MenuScreen menuScreen;
        public PlayScreen playScreen;
        public WinScreen winScreen;
        public LoseScreen loseScreen;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize all screens.
            menuScreen = new MenuScreen(this);
            playScreen = new PlayScreen(this);
            winScreen = new WinScreen(this);
            loseScreen = new LoseScreen(this);

            // Start on the menu screen.
            SetCurrentScreen(menuScreen);
        }

        public void SetCurrentScreen(Screen screen)
        {
            display.Children.Clear();
            display.Children.Add(screen.GetCanvas());
        }
    }
}

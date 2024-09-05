using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowEngine.GameProject
{
    /// <summary>
    /// Interaction logic for Browse_Window.xaml
    /// </summary>
    public partial class Browse_Window : Window
    {
        public Browse_Window()
        {
            InitializeComponent();
        }
        
        private void OnToggleButton_Click(object sender, RoutedEventArgs args)
        {
            if(sender == OpenProjectButton)
            {
                if(CreateProjectButton.IsChecked == true)
                {
                    CreateProjectButton.IsChecked = false;
                    BrowsePanel.Margin = new Thickness(0);
                }    
                OpenProjectButton.IsChecked = true;
            }
            else
            {
                if (OpenProjectButton.IsChecked == true)
                {
                    OpenProjectButton.IsChecked = false;
                    BrowsePanel.Margin = new Thickness(-800, 0, 0, 0);
                }
                CreateProjectButton.IsChecked = true;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {

                    if (CreateProjectButton.IsChecked == true)
                    {
                        CreateProjectButton.IsChecked = false;
                        BrowsePanel.Margin = new Thickness(0);
                    }
                OpenProjectButton.IsChecked = true;
            }
            else if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (OpenProjectButton.IsChecked == true)
                {
                    OpenProjectButton.IsChecked = false;
                    BrowsePanel.Margin = new Thickness(-800, 0, 0, 0);
                }
                CreateProjectButton.IsChecked = true;
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowEngine.GameProject;

namespace WindowEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnMainWindowLoaded;
            OpenProjectBrowseDialog();
        }

        private void OpenProjectBrowseDialog()
        {
            var Dialog = new Browse_Window();
            bool? result = Dialog.ShowDialog();
            if (result == false || result == null)
            {
                if (Application.Current != null)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    // Handle the case where Application.Current is null
                }
            }
            else
            {
                // Handle the case where the dialog result is true
            }
        }
    }
}

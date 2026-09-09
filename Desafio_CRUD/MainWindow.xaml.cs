using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desafio_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool menu_opened = false;

        public MainWindow()
        {
            InitializeComponent();
            setScreen();
        }

        private void setScreen()
        {

            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Visible;
        }



        // CÓDIGO DE ABERTURA DO MENU LATERAL
        private void menu_button_click(object sender, RoutedEventArgs e)
        {
            GridLengthConverter converter = new GridLengthConverter();
            GridLength width_close = (GridLength)converter.ConvertFromString("1");
            GridLength width_open = (GridLength)converter.ConvertFromString("60");

            if (menu_opened)
            {
                menu_column.Width = width_close;
                menu_opened = false;
            }
            else
            {
                menu_column.Width = width_open;
                menu_opened = true;
            }
        }

        // SAIR DO SISTEMA

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // ABRIR LANDING PAGE
        private void start_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Visible;
        }

        // ABRIR JANELA DE REGISTRO DE RESIDENCIA
        private void register_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Visible;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Collapsed;
        }

        // ABRIR JANELA DE EDIÇÃO DE CASAS
        private void edit_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Visible;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Collapsed;
        }

        // ABRIR JANELA DE REMOÇÃO DE CASAS
        private void remove_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Visible;
            landing_page.Visibility = Visibility.Collapsed;
        }
    }
}
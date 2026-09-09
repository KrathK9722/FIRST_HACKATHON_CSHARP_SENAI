using MySql.Data.MySqlClient;
using System.Data;
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

        public static string connectionString = "Server=localhost;Database=store;Uid=root;Pwd=;";
        public static MySqlConnection Connection { get; set; }

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



        // OPENING SIDE MENU
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

        // LOAD DATABASE

        public void viewDataBase()
        {
            if (GlobalFunctions.Verify_database() == true)
            {
                menu_button_register_first_house.Visibility = Visibility.Hidden;
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {

                        conn.Open();

                        string sql = @"SELECT usuario,id,email FROM usuarios";

                        using MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        using MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd);

                        DataTable tabela = new DataTable();

                        adapter.Fill(tabela);

                        landing_page_data.ItemsSource =
                            tabela.DefaultView;

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                menu_button_register_first_house.Visibility = Visibility.Visible;
            }
        }

        // EXIT BUTTON

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // OPEN LANDING SCREEN
        private void start_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Visible;
        }

        // OPEN HOUSE REGISTER SCREEN
        private void register_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Visible;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Collapsed;
        }

        // OPEN HOUSE EDIT SCREEN
        private void edit_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Visible;
            remove_screen.Visibility = Visibility.Collapsed;
            landing_page.Visibility = Visibility.Collapsed;
        }

        // OPEN HOUSE REMOVE SCREEN
        private void remove_click(object sender, RoutedEventArgs e)
        {
            register_screen.Visibility = Visibility.Collapsed;
            edit_screen.Visibility = Visibility.Collapsed;
            remove_screen.Visibility = Visibility.Visible;
            landing_page.Visibility = Visibility.Collapsed;
        }
    }
}
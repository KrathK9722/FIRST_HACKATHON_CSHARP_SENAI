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
    /// </summary>
    public static class GlobalFunctions 
    {
        public static string connectionString = "Server=localhost;Database=store;Uid=root;Pwd=;";

        // Conexão fica guardada aberta na memória do app
        public static MySqlConnection Connection { get; set; }

        public static void Open_database()
        {
            try
            {
                if (Connection == null || Connection.State != System.Data.ConnectionState.Open)
                {
                    Connection = new MySqlConnection(connectionString);
                    Connection.Open();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show("Erro ao conectar: " + ex.Message);
            }
        }

        public static bool Verify_database()
        {
            string query = "SELECT COUNT(*) FROM houses";
            using var viewData = new MySqlCommand(query, Connection);

            if (Convert.ToInt64(viewData.ExecuteScalar()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
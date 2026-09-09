/* 
  
TIPOS DE RETORNO:

3 = Retorno negativo
2 = Retorno positivo
1 or -1 = erro de tentativa
0 = tentativa concluida
100 = Email ja cadastrado no sistema
101 = Usuário ja cadastrado no sistema
102 = Usuário não cadastrado
103 = Email não cadastrado
104 = Senha incorreta

*/

using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CSHARP_APLICATIVO_WPF

public static class Global
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
}

using System;
using MySqlConnector; 

namespace ChatSimple
{
    class Conexion
    {
        
        private string cadena = "Server=localhost;Port=3306;Database=chat;Uid=Luis;Pwd=JoseLuis;";

        public void GuardarMensaje(string user, string msg)
        {
            try
            {
                MySqlConnection conectar = new MySqlConnection(cadena);
                conectar.Open();

             
                string sql = "INSERT INTO historico (usuario, mensaje) VALUES ('" + user + "', '" + msg + "')";

                MySqlCommand comando = new MySqlCommand(sql, conectar);
                comando.ExecuteNonQuery();

                conectar.Close();
            }
            catch (Exception)
            {
               
            }
        }
    }
}
using System;
using MySqlConnector; 

namespace ChatSimple
{
    class Conexion
    {
        
        private string cadena = "Server=localhost;Port=3308;Database=chat;Uid=Luis;Pwd=JoseLuis;";

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
        public string ObtenerHistorial()
        {
            string todoElChat = "";
            try
            {
                MySqlConnection conectar = new MySqlConnection(cadena);
                conectar.Open();

                
                string sql = "SELECT usuario, mensaje, timestamp FROM historico";

                MySqlCommand comando = new MySqlCommand(sql, conectar);
                MySqlDataReader lector = comando.ExecuteReader();

                while (lector.Read() == true)
                {
                    string usuario = lector["usuario"].ToString();
                    string mensaje = lector["mensaje"].ToString();

                   
                    string fecha = lector["timestamp"].ToString();

                   
                    todoElChat = todoElChat + "[" + fecha + "] " + usuario + ": " + mensaje + "\r\n";
                }

                lector.Close();
                conectar.Close();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            return todoElChat;
        }
    }
}
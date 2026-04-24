using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace ChatSimple
{
    class Conexion
    {
        string cadena = "server=localhost;user=Luis;pwd=JoseLuis;database=chat";

        MySqlConnection conexion;

        public static int Puerto = 0;

        private void conectar()
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión: " + ex.Message);
            }
        }

        private void desconectar()
        {
            try
            {
                if (conexion != null)
                    conexion.Close();
            }
            catch { }
        }

        // 🔵 SELECT
        public DataSet ejecutar(string sql)
        {
            try
            {
                conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                desconectar();
                return ds;
            }
            catch
            {
                desconectar();
                return null;
            }
        }

        
        public bool ejecutarcomando(string sql)
        {
            try
            {
                conectar();
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                desconectar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                desconectar();
                return false;
            }
        }

       
       
    }
}
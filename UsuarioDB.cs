using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Coralina.modelo;
using MySql.Data.MySqlClient;

namespace Coralina
{
    class UsuarioDB
    {
        public static MySqlConnection Conectar()
        {
            string cadenaConexion = "datasource=localhost;username=root;password=;database=coralina";
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Conexión \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void InsertarUsuario(Usuario usr)
        {
            string sql = "INSERT INTO usuario (cedula, nombre, username, contrasenna) VALUES (@Cedula, @Nombre, @Username, @Contrasenna)";
            MySqlConnection con = Conectar();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Cedula", MySqlDbType.Int32).Value= usr.Cedula;
            cmd.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = usr.Nombre;
            cmd.Parameters.Add("@Username", MySqlDbType.VarChar).Value = usr.UserName;
            cmd.Parameters.Add("@Contrasenna", MySqlDbType.VarChar).Value = Encrypt.GetSHA256(usr.Contrasenna);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Usuario registrado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static bool ValidarCedula(int cedula)
        {
            string sql = "SELECT * FROM usuario WHERE cedula = @Cedula";
            MySqlConnection con = Conectar();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Cedula", MySqlDbType.VarChar).Value = cedula;

            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ValidarUsername(string username)
        {
            string sql = "SELECT * FROM usuario WHERE username = @Username";
            MySqlConnection con = Conectar();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Username", MySqlDbType.VarChar).Value = username;

            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool IniciarSesion(string username, string contrasenna)
        {
            string sql = "SELECT * FROM usuario WHERE username = @Username AND contrasenna = @Contrasenna";
            MySqlConnection con = Conectar();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Username", MySqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@Contrasenna", MySqlDbType.VarChar).Value = Encrypt.GetSHA256(contrasenna);

            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        CacheUsuario.UserName = reader.GetString(2);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    } // Fin de la clase
}

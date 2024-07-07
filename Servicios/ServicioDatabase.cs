using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMApp.Clases;
using Microsoft.Data.Sqlite;

namespace DMApp.Servicios
{
    static class ServicioDatabase
    {

        static readonly SqliteConnection conexion = new SqliteConnection("Data Source=D:/pablo/Documents/Estudios/Programacion/C#/databases/dmapp.db");

        public static void ConnectDatabase()
        {
            conexion.Open();

            SqliteCommand command = conexion.CreateCommand();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS jugadores (
                                        nombre  TEXT    NOT NULL,
                                        vida    INTEGER NOT NULL,
                                        estados TEXT);";
            command.ExecuteNonQuery();

            //Comprobar que las tablas esten vacias y si lo estan insrertar datos de prueba
            command.CommandText = "SELECT COUNT(*) FROM jugadores";
            int resultado = Convert.ToInt32(command.ExecuteScalar());
            if (resultado <= 0) InsertarDatosPrueba();

            conexion.Close();
        }

        public static void InsertarJugador(Player player)
        {
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "insert into jugadores (nombre, vida, estados) VALUES(@nombre, @vida @estados);";
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@vida", SqliteType.Integer);
            comando.Parameters.Add("@estados", SqliteType.Text);

            comando.Parameters["@nombre"].Value = player.Nombre;
            comando.Parameters["@Vida"].Value = player.Vida;
            comando.Parameters["@estados"].Value = player.Estados;

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void EditarJugador(Player player)
        {
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "UPDATE jugadores" +
                                  "SET nombre = '" + player.Nombre + "'," +
                                       "vida = " + player.Vida + "," + 
                                       "estados = '" + player.Estados + "'" + 
                                  "WHERE nombre = '" + player.Nombre + "';";
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public static void EliminarJugador(Player player)
        {
            conexion.Open();
            try
            {
                SqliteCommand comando = conexion.CreateCommand();

                comando.CommandText = "DELETE FROM jugadores " +
                                      "WHERE nombre = '" + player.Nombre + "';";
                comando.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                //TODO hacer que mande un mensaje de error
            }
        }

        public static ObservableCollection<Player> GetJugadores()
        {
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM jugadores";
            SqliteDataReader lector = comando.ExecuteReader();
            ObservableCollection<Player> listaJugadores = new ObservableCollection<Player>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string nombre = lector.GetString(0);
                    int vida = lector.GetInt32(1);
                    string estados = lector.GetString(2);
                    listaJugadores.Add(new Player(nombre, vida, estados));
                }
            }
            lector.Close();
            conexion.Close();

            return listaJugadores;
        }

        public static void InsertarDatosPrueba()
        {
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "insert into jugadores (nombre, vida, estados) values ('Pablo', 20, 'Envenenado, Cegado');" +
                                  "insert into jugadores (nombre, vida, estados) values ('Manolo', 20, '');" +
                                  "insert into jugadores (nombre, vida, estados) values ('Pepe', 20, '');";
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}

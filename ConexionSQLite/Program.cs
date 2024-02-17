// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace CrudSqlite.Data
{
    public class Conexion
    {        
        //private static SqliteConnection _connection = new SqliteConnection("Data Source = PRUEBAS.db;");
        //private static SqliteBlob _blob;

        static void Main(string[] args)
        {
            string cadenaConexion1 = "Data Source = C:\\Users\\CRISTIAN.RUIZV\\source\\repos\\cursoNet\\net core sqlite\\ConexionSQLite\\ConexionSQLite\\SQLiteDataBase.db;";
            //string cadenaConexion2 = "Data Source =  ~/ConexionSQLite/SQLiteDataBase.db;";
            SqliteConnection _connection = new SqliteConnection(cadenaConexion1);
            SqliteDataReader sqliteDataReader = null;
            SqliteCommand cmd = null;

            try
            {
                _connection.Open();
                
                cmd = new SqliteCommand("SELECT * from Contacto;", _connection);
                sqliteDataReader = cmd.ExecuteReader();
                Console.WriteLine("Estado: " + _connection.State);
                //SqliteBlob _blob = new(_connection, "Contacto", "name", 1, true);                           
                if (sqliteDataReader.HasRows)
                {
                    for (int i = 0;i<sqliteDataReader.FieldCount;i++)
                    {
                        Console.WriteLine(sqliteDataReader.GetName(i)+"\t");
                    }
                    Console.WriteLine();
                    while (sqliteDataReader.Read())
                    {
                        for(int i = 0; i < sqliteDataReader.FieldCount; i++)
                        {
                            Console.WriteLine(sqliteDataReader[i] +"\t");
                        }
                        Console.WriteLine() ;   
                    }
                }
                else
                {
                    Console.WriteLine("No hay datos en la tabla");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción: "+e.Message);
            }
            
        }
    }
}

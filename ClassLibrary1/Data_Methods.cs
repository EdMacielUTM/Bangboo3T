using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL
{
    internal class Data_Methods
    {
        //metodo para ejecutar un dataset
        //utilizado para ejecutar una consulta SQL que devuelve un conjunto de datos
        //que puede contener una o varias tablas con filas y columnas de datos
        public static DataSet execute_DataSet(string sp, params object[] parameters)
        {
            //Instanciamos un DS => Objecto ADO
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexion desde la clase configuracion
            string connectionString = Configuration.ConnectionString;
            //crear una conexion => SqlConnection objeto de 400
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    con.Close();
                }
                else
                {
                    //comando para SQL => 
                    SqlCommand cmd = new SqlCommand(sp, con);
                    //define que el comando sera ejecutado como SP (stored procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los 
                    //si es diferente de null y su residuo es diferente de -
                    //parametros = {clave : valor}
                    if (parameters != null && parameters.Length % 2 == 1)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : valor)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parameters.Length; i = i + 2)
                        {
                            //sqlParameter => objeto de ADO
                            cmd.Parameters.Add(parameters[i].ToString(), parameters[i + 1].ToString());
                        }

                        //abrimos la conexion
                        con.Open();
                        //ejecutamos el comando
                        //sqlDataAdapter +> objeto de ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llamamos el ds
                        adapter.Fill(ds);
                        //cerramos la conexion
                        con.Close();
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    //ceramos la conexion
                    con.Close();
                }
            }
        }

        public static int execute_Scalar(string sp, params object[] parameters)
        {
            //variables para el control de resultado
            int id = 0;
            //DataSet ds = new DataSet();
            string connectionString = Configuration.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    if (parameters != null && parameters.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : value)");
                    }
                    else
                    {
                        for (int i = 0; i < parameters.Length; i = i + 2)
                        {
                            cmd.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1].ToString());
                        }

                        con.Open();
                        //Ejecuto el comando de forma que espero un escalar
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    con.Close();
                }
            }
        }

        //Metodo que ejecuta un NonQuery
        //utilizado para ejecutar consultas SQL que no devuelven un conjunto de resultados
        //como sentencias INSERT, UPDATE, o DELETE
        //Retorna un valor entero que representa el numero de filas afectadas por la operacion
        //(
        public static int execute_nonQuery(string sp, params object[] parameters)
        {
            //variables para el control de resultado
            int id = 0;
            //obtenemos la cadena de conexion desde la clase configuracion
            string connectionString = Configuration.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los parametros
                    //si es diferente de null y su residuo es diferente de 0
                    //(parametros = {clave: valor})

                    if (parameters != null && parameters.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (clave : value)");
                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parameters.Length; i = i + 2)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1].ToString());
                        }

                        //abrimos la conexion
                        con.Open();
                        //Ejecuto el comando de forma que espero un escalar
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //cerramos la conexion
                        con.Close();
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexion esta abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexion
                    con.Close();
                }
            }
        }

    }
}

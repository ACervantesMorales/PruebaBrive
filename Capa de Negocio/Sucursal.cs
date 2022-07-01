using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class Sucursal
    {
        public static Capa_de_Modelo.Auxiliar Add(Capa_de_Modelo.Sucursal sucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using(SqlConnection context = new SqlConnection(Capa_de_Datos.Conexion.GetConnectionString()))
                {
                    var query = "SucursalAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = sucursal.Nombre;

                        collection[1] = new SqlParameter("@Ubicacion", SqlDbType.VarChar);
                        collection[1].Value = sucursal.Ubicacion;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            auxiliar.Correct = true;
                        }
                        else
                        {
                            auxiliar.Correct = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct = false;
                auxiliar.ErrorMessage = ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }

        public static Capa_de_Modelo.Auxiliar Update(Capa_de_Modelo.Sucursal sucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (SqlConnection context = new SqlConnection(Capa_de_Datos.Conexion.GetConnectionString()))
                {
                    var query = "SucursalUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("@IdSucursal", SqlDbType.Int);
                        collection[0].Value = sucursal.IdSucursal;

                        collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[1].Value = sucursal.Nombre;

                        collection[2] = new SqlParameter("@Ubicacion", SqlDbType.VarChar);
                        collection[2].Value = sucursal.Ubicacion;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            auxiliar.Correct = true;
                        }
                        else
                        {
                            auxiliar.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct= false;
                auxiliar.ErrorMessage=ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }

        public static Capa_de_Modelo.Auxiliar Delete(int IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (SqlConnection context = new SqlConnection(Capa_de_Datos.Conexion.GetConnectionString()))
                {
                    var query = "SucursalDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdSucursal", SqlDbType.Int);
                        collection[0].Value = IdSucursal;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            auxiliar.Correct = true;
                        }
                        else
                        {
                            auxiliar.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct = false;
                auxiliar.ErrorMessage = ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }

        public static Capa_de_Modelo.Auxiliar GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (SqlConnection context = new SqlConnection(Capa_de_Datos.Conexion.GetConnectionString()))
                {
                    var query = "SucursalGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableSucursal = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableSucursal);

                        if (tableSucursal.Rows.Count > 0)
                        {
                            auxiliar.Objects = new List<object>();
                            foreach (DataRow row in tableSucursal.Rows)
                            {
                                Capa_de_Modelo.Sucursal sucursal = new Capa_de_Modelo.Sucursal();
                                sucursal.IdSucursal = int.Parse(row[0].ToString());
                                sucursal.Nombre = row[1].ToString();
                                sucursal.Ubicacion = row[2].ToString();
                            
                                auxiliar.Objects.Add(sucursal);
                            }
                            auxiliar.Correct = true;
                        }
                        else
                        {
                            auxiliar.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct = false;
                auxiliar.ErrorMessage = ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }

        public static Capa_de_Modelo.Auxiliar GetById(int IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (SqlConnection context = new SqlConnection(Capa_de_Datos.Conexion.GetConnectionString()))
                {
                    var query = "SucursalGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdSucursal", SqlDbType.Int);
                        collection[0].Value = IdSucursal;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableMateria);

                        if (tableMateria.Rows.Count > 0)
                        {
                            DataRow row = tableMateria.Rows[0];

                            Capa_de_Modelo.Sucursal sucursal = new Capa_de_Modelo.Sucursal();
                            sucursal.IdSucursal = int.Parse(row[0].ToString());
                            sucursal.Nombre = row[1].ToString();
                            sucursal.Ubicacion = row[2].ToString();

                            auxiliar.Object = sucursal;
                            auxiliar.Correct = true;
                        }
                        else
                        {
                            auxiliar.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct = false;
                auxiliar.ErrorMessage = ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }


    }
}

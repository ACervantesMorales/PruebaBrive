using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class Rol
    {
        public static Capa_de_Modelo.Auxiliar GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.RolGetAll().ToList();

                    if (query != null)
                    {
                        auxiliar.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Capa_de_Modelo.Rol rol = new Capa_de_Modelo.Rol();
                            rol.IdRol = obj.IdRol;
                            rol.Nombre = obj.Nombre;

                            auxiliar.Objects.Add(rol);
                        }
                        auxiliar.Correct = true;
                    }
                    else
                    {
                        auxiliar.Correct = false;
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

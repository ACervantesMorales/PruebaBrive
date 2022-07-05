using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class Usuario
    {

        public static Capa_de_Modelo.Auxiliar Add(Capa_de_Modelo.Usuario usuario)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password, usuario.Rol.IdRol);

                    if(query > 0)
                    {
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

        public static Capa_de_Modelo.Auxiliar GetByUserName(string UserName)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.UsuarioGetByUserName(UserName).FirstOrDefault();

                    if(query != null)
                    {
                        Capa_de_Modelo.Usuario usuario = new Capa_de_Modelo.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.UsuarioNombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Rol = new Capa_de_Modelo.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.Rol.Nombre = query.RolNombre;

                        auxiliar.Object = usuario;
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

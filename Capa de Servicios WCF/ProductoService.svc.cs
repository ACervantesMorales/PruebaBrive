

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Capa_de_Servicios_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductoService.svc or ProductoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductoService : IProductoService
    {
        public AuxiliarWCF Add(Capa_de_Modelo.Producto producto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.Add(producto);
            AuxiliarWCF auxiliarWCF = new AuxiliarWCF();
            auxiliarWCF.Correct = auxiliar.Correct;
            auxiliarWCF.ErrorMessage = auxiliar.ErrorMessage;
            auxiliarWCF.Object = auxiliar.Object;
            auxiliarWCF.Objects = auxiliar.Objects;
            auxiliarWCF.Ex = auxiliar.Ex;

            return auxiliarWCF;
        }

        public AuxiliarWCF Update(Capa_de_Modelo.Producto producto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.Update(producto);
            AuxiliarWCF auxiliarWCF = new AuxiliarWCF();
            auxiliarWCF.Correct = auxiliar.Correct;
            auxiliarWCF.ErrorMessage = auxiliar.ErrorMessage;
            auxiliarWCF.Object = auxiliar.Object;
            auxiliarWCF.Objects = auxiliar.Objects;
            auxiliarWCF.Ex = auxiliar.Ex;

            return auxiliarWCF;
        }
        public AuxiliarWCF Delete(int IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.Delete(IdProducto);
            AuxiliarWCF auxiliarWCF = new AuxiliarWCF();
            auxiliarWCF.Correct = auxiliar.Correct;
            auxiliarWCF.ErrorMessage = auxiliar.ErrorMessage;
            auxiliarWCF.Object = auxiliar.Object;
            auxiliarWCF.Objects = auxiliar.Objects;
            auxiliarWCF.Ex = auxiliar.Ex;

            return auxiliarWCF;
        }

        public AuxiliarWCF GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.GetAll();
            AuxiliarWCF auxiliarWCF = new AuxiliarWCF();
            auxiliarWCF.Correct = auxiliar.Correct;
            auxiliarWCF.ErrorMessage = auxiliar.ErrorMessage;
            auxiliarWCF.Object = auxiliar.Object;
            auxiliarWCF.Objects = auxiliar.Objects;
            auxiliarWCF.Ex = auxiliar.Ex;

            return auxiliarWCF;
        }

        public AuxiliarWCF GetById(int IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.GetById(IdProducto);
            AuxiliarWCF auxiliarWCF = new AuxiliarWCF();
            auxiliarWCF.Correct = auxiliar.Correct;
            auxiliarWCF.ErrorMessage = auxiliar.ErrorMessage;
            auxiliarWCF.Object = auxiliar.Object;
            auxiliarWCF.Objects = auxiliar.Objects;
            auxiliarWCF.Ex = auxiliar.Ex;

            return auxiliarWCF;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Capa_de_Servicios_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductoService" in both code and config file together.
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        AuxiliarWCF Add(Capa_de_Modelo.Producto producto);

        [OperationContract]
        AuxiliarWCF Update(Capa_de_Modelo.Producto producto);

        [OperationContract]
        AuxiliarWCF Delete(int IdProducto);

        [OperationContract]
        [ServiceKnownType(typeof(Capa_de_Modelo.Producto))]
        AuxiliarWCF GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(Capa_de_Modelo.Producto))]
        AuxiliarWCF GetById(int IdProducto);
    }
}



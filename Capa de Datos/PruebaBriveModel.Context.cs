﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa_de_Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PruebaBriveEntities : DbContext
    {
        public PruebaBriveEntities()
            : base("name=PruebaBriveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    
        public virtual int ProductoAdd(string nombre, Nullable<decimal> precio, string descripcion, Nullable<int> stock, string imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, precioParameter, descripcionParameter, stockParameter, imagenParameter);
        }
    
        public virtual int ProductoAddBySucursal(Nullable<int> idProducto, Nullable<int> idSucursal)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAddBySucursal", idProductoParameter, idSucursalParameter);
        }
    
        public virtual int ProductoDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", idProductoParameter);
        }
    
        public virtual ObjectResult<ProductoGetAll_Result> ProductoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetAll_Result>("ProductoGetAll");
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string nombre, Nullable<decimal> precio, Nullable<int> stock, string descripcion, string imagen)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, nombreParameter, precioParameter, stockParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual int SucursalAdd(string nombre, string ubicacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("Ubicacion", ubicacion) :
                new ObjectParameter("Ubicacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalAdd", nombreParameter, ubicacionParameter);
        }
    
        public virtual int SucursalDelete(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalDelete", idSucursalParameter);
        }
    
        public virtual ObjectResult<SucursalGetAll_Result> SucursalGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetAll_Result>("SucursalGetAll");
        }
    
        public virtual ObjectResult<SucursalGetById_Result> SucursalGetById(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetById_Result>("SucursalGetById", idSucursalParameter);
        }
    
        public virtual int SucursalUpdate(Nullable<int> idSucursal, string nombre, string ubicacion)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("Ubicacion", ubicacion) :
                new ObjectParameter("Ubicacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalUpdate", idSucursalParameter, nombreParameter, ubicacionParameter);
        }
    }
}

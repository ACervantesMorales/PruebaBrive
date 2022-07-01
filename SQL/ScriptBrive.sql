CREATE DATABASE PruebaBrive

CREATE TABLE Producto(
IdProducto INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL,
Precio DECIMAL (18,2) NOT NULL,
Descripcion VARCHAR(100),
Stock INT NOT NULL,
Imagen VARCHAR(MAX))

CREATE TABLE Sucursal(
IdSucursal INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL,
Ubicacion VARCHAR(100))

CREATE TABLE ProductoSucursal(
IdProductoSucursal INT IDENTITY(1,1) PRIMARY KEY,
IdProducto INT FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto) NOT NULL,
IdSucursal INT FOREIGN KEY(IdSucursal) REFERENCES Sucursal(IdSucursal) NOT NULL)

CREATE TABLE Venta(
IdVenta INT IDENTITY(1,1) PRIMARY KEY,
IdProducto INT FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto),
Cantidad INT,
Total DECIMAL(18,2))

CREATE PROCEDURE ProductoGetAll
AS
	SELECT 
		IdProducto,
		Nombre,
		Precio,
		Descripcion,
		Stock,
		Imagen
	FROM Producto 
	
CREATE PROCEDURE ProductoAdd
@Nombre VARCHAR(100), @Precio DECIMAL(18,2), @Descripcion VARCHAR(100), @Stock INT, @Imagen VARCHAR(MAX)
AS
	INSERT INTO Producto(Nombre, Precio, Descripcion, Stock, Imagen) 
	VALUES (@Nombre, @Precio, @Descripcion, @Stock, @Imagen)
		

CREATE PROCEDURE ProductoUpdate 
@IdProducto INT, @Nombre VARCHAR(100), @Precio DECIMAL(18,2), @Stock INT, @Descripcion VARCHAR(100), @Imagen VARCHAR(MAX)
AS
	UPDATE Producto 
	SET Nombre = @Nombre,
		Precio = @Nombre,
		Stock = @Stock,
		Descripcion = @Descripcion,
		Imagen = @Imagen
	WHERE IdProducto = @IdProducto

CREATE PROCEDURE ProductoDelete
@IdProducto INT 
AS
	DELETE 
	FROM Producto 
	WHERE IdProducto = @IdProducto


CREATE PROCEDURE ProductoGetById
@IdProducto INT
AS
	SELECT 
		IdProducto,
		Nombre,
		Precio,
		Descripcion, 
		Stock,
		Imagen
	FROM Producto 
	WHERE IdProducto = @IdProducto 

CREATE PROCEDURE SucursalGetAll
AS
	SELECT 
		IdSucursal,
		Nombre, 
		Ubicacion
	FROM Sucursal 


CREATE PROCEDURE SucursalAdd
@Nombre VARCHAR(100), @Ubicacion VARCHAR(100)
AS
	INSERT INTO Sucursal(Nombre, Ubicacion)
	VALUES(@Nombre, @Ubicacion)


CREATE PROCEDURE SucursalDelete
@IdSucursal INT
AS
	DELETE 
	FROM Sucursal 
	WHERE IdSucursal = @IdSucursal 

CREATE PROCEDURE SucursalUpdate 
@IdSucursal INT, @Nombre VARCHAR(100), @Ubicacion VARCHAR(100)
AS
	UPDATE Sucursal
	SET Nombre = @Nombre,
		Ubicacion = @Ubicacion 
	WHERE IdSucursal = @IdSucursal


CREATE PROCEDURE SucursalGetById
@IdSucursal INT 
AS
	SELECT 
		IdSucursal,
		Nombre, 
		Ubicacion 
	FROM Sucursal
	WHERE IdSucursal = @IdSucursal


CREATE PROCEDURE ProductoAddBySucursal 
@IdProducto INT, @IdSucursal INT 
AS
	INSERT INTO ProductoSucursal(IdProducto, IdSucursal)
	VALUES (@IdProducto, @IdSucursal)

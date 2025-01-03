Para este proyecto se utilizo Visual Studio y como base de datos SQLServe con el entorno de Management Studio.
Este proyecto quiere la creacion de una pagina web donde se podra gestionar diferentes productos con sus caracteristicas, entre esas se aplica la información con sus imagenes pertinentes.
En este proyecto se utiliza un modelo-vista-controlador con herramientas como Entity Framework y Scaffold.
En este proyecto se requiere la creacion de una base de datos con dos tablas especipicas, esta tabal se puede utilizar con los siguientes query.
Create database PruebaProductos
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    NOMBRE VARCHAR(40) NOT NULL,
    DESCRIPCION TEXT NULL,
    PRECIO DECIMAL(18, 0) NOT NULL,
    FECHACREACION DATETIME NOT NULL,
    ESTADO BIT NULL
);
CREATE TABLE Imagenesproductos (
    IdImagenesProductos INT PRIMARY KEY IDENTITY(1,1),
    NOMBRE VARCHAR(150) NULL,
    ESTADO BIT NULL,
    ImagenEXT VARBINARY(MAX) NULL,
    IdProducto INT NOT NULL,
    CONSTRAINT FK_Imagenesp_IdPro FOREIGN KEY (IdProducto)
    REFERENCES Producto (IdProducto)
);


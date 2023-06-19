-- Creación de la base de datos
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'TallerBD_facturacion')
  DROP DATABASE TallerBD_facturacion;

CREATE DATABASE TallerBD_facturacion;
GO

USE TallerBD_facturacion;
GO

-- Crear tabla cliente
IF OBJECT_ID('cliente', 'U') IS NOT NULL
  DROP TABLE cliente;
CREATE TABLE cliente (
    cliente_id INT PRIMARY KEY,
    nombre VARCHAR(50),
    direccion VARCHAR(100),
    telefono VARCHAR(50),
    email VARCHAR(50),
    estado BIT
);

-- Crear tabla tipo
IF OBJECT_ID('tipo', 'U') IS NOT NULL
  DROP TABLE tipo;
CREATE TABLE tipo (
    tipo_id INT PRIMARY KEY,
    descripcion VARCHAR(50),
    estado BIT
);

-- Crear tabla producto
IF OBJECT_ID('producto', 'U') IS NOT NULL
  DROP TABLE producto;
CREATE TABLE producto (
    producto_id INT PRIMARY KEY,
    nombre VARCHAR(255),
    precioCompra FLOAT,
    precioVenta FLOAT,
    cantidad INT,
    tipo_id INT,
    estado BIT,
    FOREIGN KEY (tipo_id) REFERENCES tipo(tipo_id)
);

-- Crear tabla factura_cabecera
IF OBJECT_ID('factura_cabecera', 'U') IS NOT NULL
  DROP TABLE factura_cabecera;
CREATE TABLE factura_cabecera (
    factura_cabecera_id INT PRIMARY KEY,
    fecha DATE,
    total FLOAT,
    cliente_id INT,
    estado BIT,
    FOREIGN KEY (cliente_id) REFERENCES cliente(cliente_id)
);

-- Crear tabla factura_detalle
IF OBJECT_ID('factura_detalle', 'U') IS NOT NULL
  DROP TABLE factura_detalle;
CREATE TABLE factura_detalle (
    factura_detalle_id INT PRIMARY KEY,
    cantidad INT,
    precioUnitario FLOAT,
    total FLOAT,
    producto_id INT,
    factura_cabecera_id INT,
    estado BIT,
    FOREIGN KEY (producto_id) REFERENCES producto(producto_id),
    FOREIGN KEY (factura_cabecera_id) REFERENCES factura_cabecera(factura_cabecera_id)
);


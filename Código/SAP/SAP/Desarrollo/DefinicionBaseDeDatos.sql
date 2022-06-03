###############################################################
#	REALSOFT												  #
#	Base de Datos SAP-Sistema de Administración de Papelería  #
#	Versión: 20181122										  #
###############################################################

DROP DATABASE IF EXISTS SAP;
CREATE DATABASE SAP;

USE SAP;

DROP TABLE IF EXISTS usuarios;
CREATE TABLE usuarios(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT  'ID Único',
    NOMBRE VARCHAR(50) COMMENT  'Nombre del usuario',
    APELLIDOS VARCHAR(100) COMMENT  'Apellidos de usuario',
    NOMBREUSUARIO VARCHAR(30) UNIQUE COMMENT  'Nombre de usuario para login',
    PASSWORD VARCHAR(30) COMMENT  'Contraseña',
    TIPO ENUM('A','C') COMMENT 'A=Administrador, C=Cajero'
);

DROP TABLE IF EXISTS productos;
CREATE TABLE productos(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT  'ID Único',
	CODIGOBARRAS VARCHAR(15) COMMENT 'Código de Barras',
    NOMBRE VARCHAR(100) COMMENT  'Nombre del producto',
    MARCA VARCHAR(100) COMMENT  'Marca del producto',
    DESCRIPCION VARCHAR(150) DEFAULT '' COMMENT  'Descripción',
    PRECIO FLOAT COMMENT 'Precio de Venta',
    CANTIDAD INT COMMENT  'Cantidad en inventario',
    ESTADO ENUM('A','E') DEFAULT 'A' COMMENT 'A=Activo, E=Eliminado'
);

DROP TABLE IF EXISTS compras;
CREATE TABLE compras(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ID Único',
    FOLIO VARCHAR(20) COMMENT 'Folio de compra',
    FECHA DATE COMMENT 'Fecha de compra',
    TOTAL FLOAT COMMENT 'Costo total de la compra',
    FECHACANCELACION DATE COMMENT 'Fecha de cancelación',
	ESTADO ENUM('A','C') COMMENT 'A=Activa, C=Cancelada'
);

DROP TABLE IF EXISTS comprasdetalles;
CREATE TABLE comprasdetalles(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ID Único',
	IDCOMPRA INT COMMENT 'Identificador de la compra',
    IDPRODUCTO INT COMMENT 'Producto de la compra',
    CANTIDAD INT COMMENT 'Cantidad comprada',
    COSTOUNIDAD FLOAT COMMENT 'Costo de la unidad',
    CONSTRAINT FOREIGN KEY (IDCOMPRA) REFERENCES compras(ID),
    CONSTRAINT FOREIGN KEY (IDPRODUCTO) REFERENCES productos(ID)
);

DROP TABLE IF EXISTS ventas;
CREATE TABLE ventas(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ID Único',
    FECHA DATE COMMENT 'Fecha de venta',
    TOTAL FLOAT COMMENT 'Total de la venta',
    FECHACANCELACION DATE COMMENT 'Fecha de cancelación',
	ESTADO ENUM('A','C') COMMENT 'A=Activa, C=Cancelada'
);

DROP TABLE IF EXISTS ventasdetalles;
CREATE TABLE ventasdetalles(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ID Único',
	IDVENTA INT COMMENT 'Identificador de la venta',
    IDPRODUCTO INT COMMENT 'Producto de la venta',
    CANTIDAD INT COMMENT 'Cantidad vendida',
    PRECIOUNIDAD FLOAT COMMENT 'Costo de la unidad',
	TOTAL FLOAT COMMENT 'Total del detalle de la venta',
    CONSTRAINT FOREIGN KEY (IDVENTA) REFERENCES ventas(ID),
    CONSTRAINT FOREIGN KEY (IDPRODUCTO) REFERENCES productos(ID)
);


DROP TABLE IF EXISTS facturas;
CREATE TABLE facturas(
	ID INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ID Único',
    IDVENTA INT COMMENT 'Id de venta',
	FECHA DATE COMMENT 'Fecha de facturación',
    ARCHIVOXML BLOB COMMENT 'Archivo XML', 
	ARCHIVOPDF BLOB COMMENT 'Archivo PDF', 
	ESTADO ENUM('A','C') COMMENT 'A=Activa, C=Cancelada'
);

################################
#	Registros base 			   #		 	
################################

INSERT INTO usuarios (NOMBRE, APELLIDOS, NOMBREUSUARIO, PASSWORD, TIPO) VALUES('Admin','Istrador','admin','123','A');
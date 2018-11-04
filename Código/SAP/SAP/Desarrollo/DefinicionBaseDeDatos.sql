###############################################################
#	REALSOFT												  #
#	Base de Datos SAP-Sistema de Administración de Papelería  #
#	Versión: 20181101										  #
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

################################
#	Registros base 			   #		 	
################################

INSERT INTO usuarios (NOMBRE, APELLIDOS, NOMBREUSUARIO, PASSWORD, TIPO) VALUES('Admin','Istrador','admin','123','A');
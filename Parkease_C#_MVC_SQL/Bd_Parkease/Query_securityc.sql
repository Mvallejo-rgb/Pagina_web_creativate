Create database software_segurityc;
use software_segurityc;
CREATE TABLE `rol` (
  `Id_Rol` INT(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Rol` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`Id_Rol`)
) ENGINE=INNODB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
CREATE TABLE `Usuario` (
   `Id_Usuario` INT(11) NOT NULL AUTO_INCREMENT,
   `Num_Documento` VARCHAR(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
   `Tipo_Documento` ENUM('C.C.', 'T.I.', 'C.E.', 'Pasaporte', 'PEPS', 'NIT') 
       NOT NULL DEFAULT 'C.C.',
   `Primer_Nombre` VARCHAR(15) NOT NULL,
   `Segundo_Nombre` VARCHAR(15) DEFAULT NULL,
   `Primer_Apellido` VARCHAR(15) NOT NULL,
   `Segundo_Apellido` VARCHAR(15) DEFAULT NULL,
   `Genero` ENUM('Masculino','Femenino','Otro') NOT NULL,
   `Fecha_De_Nacimiento` DATE NOT NULL,
   `Correo_Electronico` VARCHAR(50) NOT NULL,
   `Telefono` VARCHAR(15) NOT NULL,
   `Password` VARCHAR(255) NOT NULL,  -- Aumentamos longitud para seguridad
   `Nacionalidad` ENUM('Colombiana','Venezolana','Ecuatoriana','Peruana','Otra') 
       NOT NULL DEFAULT 'Colombiana',
   `Id_Rol` INT(11) NOT NULL,
   `RH` ENUM('O-','O+','A-','A+','B-','B+','AB-','AB+') DEFAULT NULL,
   `Estado` TINYINT(1) NOT NULL, -- Optimizamos el tipo de dato
   PRIMARY KEY (`Id_Usuario`),
   UNIQUE KEY `Num_Documento` (`Num_Documento`),
   KEY `Rol_Usuario` (`Id_Rol`),
   CONSTRAINT `Usuario_fk_Rol` FOREIGN KEY (`Id_Rol`) REFERENCES `rol` (`Id_Rol`)
) ENGINE=INNODB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
CREATE TABLE `minuta` (
  `Num_Minuta` INT(11) NOT NULL AUTO_INCREMENT,
  `Usuario_Id_Usuario` INT(11) NOT NULL,
  `Fecha_Inicial` DATETIME NOT NULL,
  `Fecha_Final` DATETIME NOT NULL,
  `Tipo_Minuta` ENUM('Personal','Vehiculo','Correspondencia','Mantenimiento','Robo','Riña','Herido','Horizontal','Captura','Positivo') CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `Observaciones` TEXT NOT NULL,
  `Soporte` BLOB DEFAULT NULL,
  PRIMARY KEY (`Num_Minuta`),
  KEY `Usuario_Id_Usuario` (`Usuario_Id_Usuario`),
  CONSTRAINT `Minuta_ibfk_4` FOREIGN KEY (`Usuario_Id_Usuario`) REFERENCES `Usuario` (`Id_Usuario`)
) ENGINE=INNODB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
INSERT INTO `Usuario` (
    `Num_Documento`, `Tipo_Documento`, `Primer_Nombre`, `Primer_Apellido`, 
    `Genero`, `Fecha_De_Nacimiento`, `Correo_Electronico`, `Telefono`, 
    `Password`, `Nacionalidad`, `RH`, `Estado`, `Id_Rol`
) 
VALUES 
(
    '123456789', 'C.C.', 'Henry', 'Racero', 'Masculino', '1993-03-10', 
    'henryr@gmail.com', '3052315512', 'Henryr', 'Colombiana', 'O+', 1, 1
);
INSERT INTO `rol`(`Id_Rol`, `Nombre_Rol`)
VALUES 
(1, 'Director'),
(2, 'Administrador'),
(3,'Cliente'),
(4,'Vigilante');
use software_segurityc;
ALTER TABLE `Usuario`
MODIFY COLUMN Genero VARCHAR(20),
MODIFY COLUMN Nacionalidad VARCHAR(20),
MODIFY COLUMN RH VARCHAR(5),
MODIFY COLUMN Estado VARCHAR(10);
CREATE TABLE Vigilante (
    Id_Vigilante INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Documento VARCHAR(15) NOT NULL UNIQUE,
    Correo VARCHAR(50) NOT NULL UNIQUE,
    Telefono VARCHAR(20) NOT NULL
);
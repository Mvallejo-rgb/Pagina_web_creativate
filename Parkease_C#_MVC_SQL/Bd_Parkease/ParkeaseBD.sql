-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: parkeasebd
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrador`
--

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrador` (
  `idAdministrador` int NOT NULL AUTO_INCREMENT,
  `primerNombre` varchar(45) NOT NULL,
  `primerApellido` varchar(45) NOT NULL,
  `correoAdmin` varchar(45) NOT NULL,
  `documentoAdmin` int NOT NULL,
  `telefonoAdmin` int NOT NULL,
  `direccion` varchar(45) NOT NULL,
  PRIMARY KEY (`idAdministrador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conductor`
--

DROP TABLE IF EXISTS `conductor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `conductor` (
  `idConductor` int NOT NULL AUTO_INCREMENT,
  `primerNombre` varchar(45) NOT NULL,
  `primerApellido` varchar(45) NOT NULL,
  `numDocu` int NOT NULL,
  `correo` varchar(45) NOT NULL,
  `edad` int NOT NULL,
  `placa` varchar(45) NOT NULL,
  `contrasena` varchar(45) NOT NULL,
  `confirmaContra` varchar(45) NOT NULL,
  PRIMARY KEY (`idConductor`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conductor`
--

LOCK TABLES `conductor` WRITE;
/*!40000 ALTER TABLE `conductor` DISABLE KEYS */;
INSERT INTO `conductor` VALUES (1,'Michael','Vallejo',123456789,'michael@gmail.com',23,'asd123','123456','123456'),(2,'Juan','Rodriguez',1001275654,'juan@gmail.com',25,'aws456','987654','987654'),(3,'marcos','diaz',28984562,'marco@gmail.com',33,'aws456','123456','123456'),(4,'Paola ','Meneses',25648984,'paola_meneses@gmail.com',45,'zxc123','qweasd','qweasd'),(5,'Andrea','Perez',28456712,'Perez_Andrea@gmail.com',32,'fgh756','123456','123456'),(6,'Mariana','Fernandez',1001256987,'fernandez_mariana@gmail.com',20,'qwe789','123456','123456'),(7,'Rafael','Orozco',28014056,'Orozco01@gmail.com',45,'mnj456','123456','123456'),(8,'pedro','pascal',23654987,'pppedropascal@gmail.com',56,'tyu890','987654','987654'),(9,'Juan','Tellez',1001271369,'th67_juan@gmail.com',21,'lki789','456789','456789'),(10,'Maria','Castillo',564987,'mariacastillo@gmail.com',25,'lño789','123456','123456'),(11,'Fernando ','Diaz',3216545,'diazfer_01@gmail.com',66,'ñpo987','123456','123456'),(12,'Diego','Velez',1001654987,'dieve_123@gmail.com',36,'ñpo654','123456','123456'),(13,'Luis','Mendoza',1002365987,'luimendo123@gmail.com',23,'cvb564','123456','123456'),(14,'Valentina','Perez',1001212365,'valentina_lahermoxita@gmail.com',23,'mnb897','123456','123456');
/*!40000 ALTER TABLE `conductor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `idFactura` int NOT NULL AUTO_INCREMENT,
  `fechaFactura` datetime NOT NULL,
  `horaInicio` datetime NOT NULL,
  `horaFin` datetime NOT NULL,
  `metodoPago` int NOT NULL,
  `descuentoPago` int NOT NULL,
  `iva` int NOT NULL,
  `valorTotal` int NOT NULL,
  PRIMARY KEY (`idFactura`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parqueadero`
--

DROP TABLE IF EXISTS `parqueadero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `parqueadero` (
  `idParqueadero` int NOT NULL AUTO_INCREMENT,
  `nombreParq` varchar(45) NOT NULL,
  `direccionParq` varchar(45) NOT NULL,
  `telefonoParq` int NOT NULL,
  `precioParq` int NOT NULL,
  PRIMARY KEY (`idParqueadero`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parqueadero`
--

LOCK TABLES `parqueadero` WRITE;
/*!40000 ALTER TABLE `parqueadero` DISABLE KEYS */;
/*!40000 ALTER TABLE `parqueadero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `idReserva` int NOT NULL AUTO_INCREMENT,
  `fechaReserva` date NOT NULL,
  `horaInicio` time NOT NULL,
  `horaFin` time NOT NULL,
  `tipoVeh` varchar(30) NOT NULL,
  `estadoReserva` enum('Confirmada','Cancelado') NOT NULL,
  `idConductor` int NOT NULL,
  PRIMARY KEY (`idReserva`),
  KEY `fk_reserva_conductor` (`idConductor`),
  CONSTRAINT `fk_reserva_conductor` FOREIGN KEY (`idConductor`) REFERENCES `conductor` (`idConductor`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehiculo`
--

DROP TABLE IF EXISTS `vehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehiculo` (
  `idVehiculo` int NOT NULL AUTO_INCREMENT,
  `colorVeh` varchar(15) NOT NULL,
  `tipoVeh` varchar(45) NOT NULL,
  `placaVeh` varchar(10) NOT NULL,
  `modeloVeh` varchar(15) NOT NULL,
  `marcaVeh` varchar(30) NOT NULL,
  `imagenReserva` varchar(255) DEFAULT NULL,
  `idConductor` int NOT NULL,
  PRIMARY KEY (`idVehiculo`),
  KEY `fk_vehiculo_conductor` (`idConductor`),
  CONSTRAINT `fk_vehiculo_conductor` FOREIGN KEY (`idConductor`) REFERENCES `conductor` (`idConductor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiculo`
--

LOCK TABLES `vehiculo` WRITE;
/*!40000 ALTER TABLE `vehiculo` DISABLE KEYS */;
/*!40000 ALTER TABLE `vehiculo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-25 17:06:53

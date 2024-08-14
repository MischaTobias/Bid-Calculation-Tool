-- MySQL dump 10.13  Distrib 8.0.27, for macos11 (arm64)
--
-- Host: 127.0.0.1    Database: progi_bid_calculation
-- ------------------------------------------------------
-- Server version	9.0.1

CREATE DATABASE IF NOT EXISTS `progi_bid_calculation`;
USE `progi_bid_calculation`;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AdditionalCost`
--

DROP TABLE IF EXISTS `AdditionalCost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AdditionalCost` (
  `id` int NOT NULL AUTO_INCREMENT,
  `criteria` varchar(255) NOT NULL,
  `lowerLimit` int NOT NULL,
  `upperLimit` int NOT NULL,
  `value` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AdditionalCost`
--

LOCK TABLES `AdditionalCost` WRITE;
/*!40000 ALTER TABLE `AdditionalCost` DISABLE KEYS */;
INSERT INTO `AdditionalCost` VALUES (1,'Association',1,500,5.00),(2,'Association',501,1000,10.00),(3,'Association',1001,3000,15.00),(4,'Association',501,0,20.00);
/*!40000 ALTER TABLE `AdditionalCost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Fee`
--

DROP TABLE IF EXISTS `Fee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Fee` (
  `id` int NOT NULL AUTO_INCREMENT,
  `feeTypeId` int NOT NULL,
  `vehicleTypeId` int DEFAULT NULL,
  `value` decimal(10,2) NOT NULL,
  `minimum` decimal(10,2) NOT NULL,
  `maximum` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `feeTypeId` (`feeTypeId`),
  KEY `vehicleTypeId` (`vehicleTypeId`),
  CONSTRAINT `fee_ibfk_1` FOREIGN KEY (`feeTypeId`) REFERENCES `FeeType` (`id`),
  CONSTRAINT `fee_ibfk_2` FOREIGN KEY (`vehicleTypeId`) REFERENCES `VehicleType` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Fee`
--

LOCK TABLES `Fee` WRITE;
/*!40000 ALTER TABLE `Fee` DISABLE KEYS */;
INSERT INTO `Fee` VALUES (1,1,1,0.10,10.00,50.00),(2,1,2,0.10,25.00,200.00),(3,2,1,0.02,0.00,0.00),(4,2,2,0.04,0.00,0.00),(5,3,NULL,100.00,0.00,0.00);
/*!40000 ALTER TABLE `Fee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FeeType`
--

DROP TABLE IF EXISTS `FeeType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FeeType` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FeeType`
--

LOCK TABLES `FeeType` WRITE;
/*!40000 ALTER TABLE `FeeType` DISABLE KEYS */;
INSERT INTO `FeeType` VALUES (1,'Basic Buyer'),(2,'Seller Special'),(3,'Fixed Storage');
/*!40000 ALTER TABLE `FeeType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `VehicleType`
--

DROP TABLE IF EXISTS `VehicleType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `VehicleType` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `VehicleType`
--

LOCK TABLES `VehicleType` WRITE;
/*!40000 ALTER TABLE `VehicleType` DISABLE KEYS */;
INSERT INTO `VehicleType` VALUES (1,'Common'),(2,'Luxury');
/*!40000 ALTER TABLE `VehicleType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'progi_bid_calculation'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-14 13:04:41

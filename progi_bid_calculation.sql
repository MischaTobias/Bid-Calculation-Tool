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
-- Table structure for table `AssociationFeeRange`
--


DROP TABLE IF EXISTS `AssociationFeeRange`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AssociationFeeRange` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `lower_limit` decimal(10,2) NOT NULL,
  `upper_limit` decimal(10,2) DEFAULT NULL,
  `value` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AssociationFeeRange`
--

LOCK TABLES `AssociationFeeRange` WRITE;
/*!40000 ALTER TABLE `AssociationFeeRange` DISABLE KEYS */;
INSERT INTO `AssociationFeeRange` VALUES (1,'Range 1',1.00,500.00,5.00),(2,'Range 2',501.00,1000.00,10.00),(3,'Range 3',1001.00,3000.00,15.00),(4,'Range 4',3001.00,NULL,20.00);
/*!40000 ALTER TABLE `AssociationFeeRange` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuyerType`
--

DROP TABLE IF EXISTS `BuyerType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `BuyerType` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuyerType`
--

LOCK TABLES `BuyerType` WRITE;
/*!40000 ALTER TABLE `BuyerType` DISABLE KEYS */;
INSERT INTO `BuyerType` VALUES (1,'Basic Buyer'),(2,'Seller');
/*!40000 ALTER TABLE `BuyerType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Fees`
--

DROP TABLE IF EXISTS `Fees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Fees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `vehicle_type_id` int DEFAULT NULL,
  `buyer_type_id` int DEFAULT NULL,
  `value` decimal(10,2) NOT NULL,
  `minimum` decimal(10,2) DEFAULT NULL,
  `maximum` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `vehicle_type_id` (`vehicle_type_id`,`buyer_type_id`),
  KEY `buyer_type_id` (`buyer_type_id`),
  CONSTRAINT `fees_ibfk_1` FOREIGN KEY (`vehicle_type_id`) REFERENCES `VehicleType` (`id`),
  CONSTRAINT `fees_ibfk_2` FOREIGN KEY (`buyer_type_id`) REFERENCES `BuyerType` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Fees`
--

LOCK TABLES `Fees` WRITE;
/*!40000 ALTER TABLE `Fees` DISABLE KEYS */;
INSERT INTO `Fees` VALUES (1,1,1,10.00,10.00,50.00),(2,1,2,2.00,NULL,NULL),(3,2,1,10.00,25.00,200.00),(4,2,2,4.00,NULL,NULL);
/*!40000 ALTER TABLE `Fees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SpecialFees`
--

DROP TABLE IF EXISTS `SpecialFees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SpecialFees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `value` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SpecialFees`
--

LOCK TABLES `SpecialFees` WRITE;
/*!40000 ALTER TABLE `SpecialFees` DISABLE KEYS */;
INSERT INTO `SpecialFees` VALUES (1,'Fixed Storage Fee',100.00);
/*!40000 ALTER TABLE `SpecialFees` ENABLE KEYS */;
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
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
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

-- Dump completed on 2024-08-12 18:52:26

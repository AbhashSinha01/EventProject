-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: event
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `events`
--

DROP TABLE IF EXISTS `events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `events` (
  `EventId` int NOT NULL AUTO_INCREMENT,
  `EventTitle` longtext,
  `StartDate` datetime(6) NOT NULL,
  `EndDate` datetime(6) NOT NULL,
  `EventDescription` longtext,
  `TimeZoneId` int NOT NULL,
  `UserId` int NOT NULL,
  PRIMARY KEY (`EventId`),
  KEY `IX_Events_TimeZoneId` (`TimeZoneId`),
  CONSTRAINT `FK_Events_TimeZoneDatas_TimeZoneId` FOREIGN KEY (`TimeZoneId`) REFERENCES `timezonedatas` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events`
--

LOCK TABLES `events` WRITE;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` VALUES (1,'Test Demo','2023-08-09 09:25:25.196000','2023-08-09 09:25:25.196000','Test Descreption',1,0),(2,'Test Demo2','2023-08-09 11:18:43.340000','2023-08-09 11:18:43.340000','Test Description2',2,1),(5,'Test Demo2','2023-08-09 11:18:43.340000','2023-08-09 11:18:43.340000','Test Description2',3,0),(6,'Test Demo3','2023-08-09 11:18:43.340000','2023-08-09 11:18:43.340000','Test Description2',4,2),(7,'string','2023-08-10 05:33:22.202000','2023-08-10 05:33:22.202000','string',5,2),(8,'string','2023-08-10 05:53:09.571000','2023-08-10 05:53:09.571000','string',6,0),(9,'string','2023-08-10 06:25:25.981000','2023-08-10 06:25:25.981000','string',7,2),(10,'string','2023-08-10 06:25:25.981000','2023-08-10 06:25:25.981000','string',8,2),(11,'string','2023-08-10 05:53:09.571000','2023-08-10 05:53:09.571000','string',9,1),(12,'string','2023-08-10 05:53:09.571000','2023-08-10 05:53:09.571000','string',10,17),(13,'string','2023-08-10 05:53:09.571000','2023-08-10 05:53:09.571000','string',11,19),(14,'string','2023-08-10 06:25:25.981000','2023-08-10 06:25:25.981000','string',12,45);
/*!40000 ALTER TABLE `events` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-14 13:37:06

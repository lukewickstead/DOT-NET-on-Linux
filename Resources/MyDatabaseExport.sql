-- MySQL dump 10.13  Distrib 5.5.31, for debian-linux-gnu (i686)
--
-- Host: localhost    Database: MyDatabase
-- ------------------------------------------------------
-- Server version	5.5.31-1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AnotherTable`
--

DROP TABLE IF EXISTS `AnotherTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AnotherTable` (
  `idAnotherTable` int(11) NOT NULL AUTO_INCREMENT,
  `StringField` varchar(45) DEFAULT NULL,
  `IntField` int(11) DEFAULT NULL,
  `DecimalField` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idAnotherTable`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AnotherTable`
--

LOCK TABLES `AnotherTable` WRITE;
/*!40000 ALTER TABLE `AnotherTable` DISABLE KEYS */;
INSERT INTO `AnotherTable` VALUES (4,'A',1,1.11),(5,'B',2,2.22);
/*!40000 ALTER TABLE `AnotherTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MyTable`
--

DROP TABLE IF EXISTS `MyTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `MyTable` (
  `idMyTable` int(11) NOT NULL AUTO_INCREMENT,
  `FieldA` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idMyTable`)
) ENGINE=InnoDB AUTO_INCREMENT=284 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MyTable`
--

LOCK TABLES `MyTable` WRITE;
/*!40000 ALTER TABLE `MyTable` DISABLE KEYS */;
INSERT INTO `MyTable` VALUES (123,'30/12/2013 16:28:31'),(124,'Value'),(125,'Hello'),(126,'28/12/2013 11:42:38'),(127,'28/12/2013 11:42:38'),(128,'Value'),(129,'Hello'),(130,'28/12/2013 11:43:31'),(131,'28/12/2013 11:43:31'),(132,'Value'),(133,'Hello'),(134,'28/12/2013 11:43:44'),(135,'28/12/2013 11:43:44'),(136,'Value'),(137,'Hello'),(138,'28/12/2013 11:44:08'),(139,'28/12/2013 11:44:09'),(140,'Value'),(141,'Hello'),(142,'28/12/2013 11:45:06'),(143,'28/12/2013 11:45:06'),(144,'Value'),(145,'Hello'),(146,'28/12/2013 11:54:19'),(147,'28/12/2013 11:54:19'),(148,'Value'),(149,'Hello'),(150,'28/12/2013 11:54:41'),(151,'28/12/2013 11:54:42'),(152,'Value'),(153,'Hello'),(154,'28/12/2013 11:56:10'),(155,'28/12/2013 11:56:10'),(156,'Value'),(157,'Hello'),(158,'28/12/2013 11:57:06'),(159,'28/12/2013 11:57:07'),(160,'Value'),(161,'Hello'),(162,'28/12/2013 12:05:04'),(163,'28/12/2013 12:05:04'),(164,'Value'),(165,'Hello'),(166,'28/12/2013 12:08:17'),(167,'28/12/2013 12:08:18'),(168,'Value'),(169,'Hello'),(170,'28/12/2013 12:09:06'),(171,'28/12/2013 12:09:06'),(172,'Value'),(173,'Hello'),(174,'28/12/2013 12:09:16'),(175,'28/12/2013 12:09:16'),(176,'Value'),(177,'Hello'),(178,'28/12/2013 12:09:30'),(179,'28/12/2013 12:09:30'),(180,'Value'),(181,'Hello'),(182,'29/12/2013 20:54:44'),(183,'29/12/2013 20:54:44'),(184,'Value'),(185,'Hello'),(186,'29/12/2013 21:06:47'),(187,'29/12/2013 21:06:47'),(188,'Value'),(189,'Hello'),(190,'29/12/2013 20:35:20'),(191,'29/12/2013 20:35:21'),(192,'Value'),(193,'Hello'),(194,'29/12/2013 20:40:30'),(195,'29/12/2013 20:40:31'),(196,'Value'),(197,'Hello'),(198,'29/12/2013 21:04:44'),(199,'29/12/2013 21:04:44'),(200,'Value'),(201,'Hello'),(202,'29/12/2013 21:05:38'),(203,'29/12/2013 21:05:39'),(204,'Value'),(205,'Hello'),(206,'29/12/2013 21:05:55'),(207,'29/12/2013 21:05:56'),(208,'Value'),(209,'Hello'),(210,'29/12/2013 21:13:51'),(211,'29/12/2013 21:13:51'),(212,'Value'),(213,'Hello'),(214,'29/12/2013 21:27:48'),(215,'29/12/2013 21:27:49'),(216,'Value'),(217,'Hello'),(218,'29/12/2013 21:28:33'),(219,'29/12/2013 21:28:33'),(220,'Value'),(221,'Hello'),(222,'29/12/2013 21:43:33'),(223,'29/12/2013 21:43:33'),(224,'Value'),(225,'Hello'),(226,'29/12/2013 21:46:46'),(227,'29/12/2013 21:46:46'),(228,'Value'),(229,'Hello'),(230,'29/12/2013 21:46:59'),(231,'29/12/2013 21:46:59'),(232,'Value'),(233,'Hello'),(234,'29/12/2013 21:50:19'),(235,'29/12/2013 21:50:20'),(236,'Value'),(237,'Hello'),(238,'29/12/2013 21:50:50'),(239,'29/12/2013 21:50:50'),(240,'Value'),(241,'Hello'),(242,'30/12/2013 09:10:36'),(243,'30/12/2013 09:10:36'),(244,'Value'),(245,'Hello'),(246,'30/12/2013 09:44:02'),(247,'30/12/2013 09:44:03'),(248,'Value'),(249,'Hello'),(250,'30/12/2013 10:10:43'),(251,'30/12/2013 10:10:44'),(252,'Value'),(253,'Hello'),(254,'30/12/2013 10:21:36'),(255,'30/12/2013 10:21:36'),(256,'Value'),(257,'Hello'),(258,'30/12/2013 16:01:47'),(259,'30/12/2013 16:01:47'),(260,'Value'),(261,'Hello'),(262,'30/12/2013 16:25:09'),(263,'30/12/2013 16:25:09'),(264,'Value'),(265,'Hello'),(266,'30/12/2013 16:25:22'),(267,'30/12/2013 16:25:22'),(268,'Value'),(269,'Hello'),(270,'30/12/2013 16:27:38'),(271,'30/12/2013 16:27:39'),(272,'Value'),(273,'Hello'),(274,'30/12/2013 16:27:49'),(275,'30/12/2013 16:27:50'),(276,'Value'),(277,'Hello'),(278,'30/12/2013 16:28:01'),(279,'30/12/2013 16:28:02'),(280,'Value'),(281,'Hello'),(282,'30/12/2013 16:28:31'),(283,'30/12/2013 16:28:31');
/*!40000 ALTER TABLE `MyTable` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-12-31 10:11:00

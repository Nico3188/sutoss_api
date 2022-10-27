Create database petcare;
use petcare;

-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: petcare
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `bundles`
--

DROP TABLE IF EXISTS `bundles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bundles` (
  `bundle_id` int NOT NULL AUTO_INCREMENT,
  `service_id` int NOT NULL,
  `service_item_id` int NOT NULL,
  PRIMARY KEY (`bundle_id`),
  KEY `fk_service_008_idx` (`service_id`),
  KEY `fk_service_item_008_idx` (`service_item_id`),
  CONSTRAINT `fk_service_008` FOREIGN KEY (`service_id`) REFERENCES `services` (`service_id`),
  CONSTRAINT `fk_service_item_008` FOREIGN KEY (`service_item_id`) REFERENCES `service_items` (`service_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bundles`
--

LOCK TABLES `bundles` WRITE;
/*!40000 ALTER TABLE `bundles` DISABLE KEYS */;
/*!40000 ALTER TABLE `bundles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healtcare_visit_document_types`
--

DROP TABLE IF EXISTS `healtcare_visit_document_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `healtcare_visit_document_types` (
  `deleted` tinyint(1) NOT NULL,
  `healtcare_visit_document_type_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`healtcare_visit_document_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healtcare_visit_document_types`
--

LOCK TABLES `healtcare_visit_document_types` WRITE;
/*!40000 ALTER TABLE `healtcare_visit_document_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `healtcare_visit_document_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healtcare_visit_documents`
--

DROP TABLE IF EXISTS `healtcare_visit_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `healtcare_visit_documents` (
  `healtcare_visit_document_id` int NOT NULL AUTO_INCREMENT,
  `mime_type` varchar(45) NOT NULL,
  `name` varchar(100) NOT NULL,
  `healtcare_visit_document_type_id` int NOT NULL,
  PRIMARY KEY (`healtcare_visit_document_id`),
  KEY `fk_healtcare_visit_document_type_006_idx` (`healtcare_visit_document_type_id`),
  CONSTRAINT `fk_healtcare_visit_document_type_006` FOREIGN KEY (`healtcare_visit_document_type_id`) REFERENCES `healtcare_visit_document_types` (`healtcare_visit_document_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healtcare_visit_documents`
--

LOCK TABLES `healtcare_visit_documents` WRITE;
/*!40000 ALTER TABLE `healtcare_visit_documents` DISABLE KEYS */;
/*!40000 ALTER TABLE `healtcare_visit_documents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healtcare_visit_progresses`
--

DROP TABLE IF EXISTS `healtcare_visit_progresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `healtcare_visit_progresses` (
  `healtcare_visit_progress_id` int NOT NULL AUTO_INCREMENT,
  `healtcare_visit_id` int NOT NULL,
  `healtcare_visit_type_id` int NOT NULL,
  PRIMARY KEY (`healtcare_visit_progress_id`),
  KEY `fk_healtcare_visit_005_idx` (`healtcare_visit_id`),
  KEY `fk_healtcare_visit_type_005_idx` (`healtcare_visit_type_id`),
  CONSTRAINT `fk_healtcare_visit_005` FOREIGN KEY (`healtcare_visit_id`) REFERENCES `healtcare_visits` (`healtcare_visit_id`),
  CONSTRAINT `fk_healtcare_visit_type_005` FOREIGN KEY (`healtcare_visit_type_id`) REFERENCES `healtcare_visit_types` (`healtcare_visit_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healtcare_visit_progresses`
--

LOCK TABLES `healtcare_visit_progresses` WRITE;
/*!40000 ALTER TABLE `healtcare_visit_progresses` DISABLE KEYS */;
/*!40000 ALTER TABLE `healtcare_visit_progresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healtcare_visit_types`
--

DROP TABLE IF EXISTS `healtcare_visit_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `healtcare_visit_types` (
  `deleted` tinyint(1) NOT NULL,
  `healtcare_visit_type_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`healtcare_visit_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healtcare_visit_types`
--

LOCK TABLES `healtcare_visit_types` WRITE;
/*!40000 ALTER TABLE `healtcare_visit_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `healtcare_visit_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `healtcare_visits`
--

DROP TABLE IF EXISTS `healtcare_visits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `healtcare_visits` (
  `deleted` tinyint(1) NOT NULL,
  `healtcare_visit_id` int NOT NULL AUTO_INCREMENT,
  `visit_day` datetime NOT NULL,
  `stamp` datetime NOT NULL,
  `description` varchar(120) NOT NULL,
  `pet_id` int NOT NULL,
  PRIMARY KEY (`healtcare_visit_id`),
  KEY `fk_pet_004_idx` (`pet_id`),
  CONSTRAINT `fk_pet_004` FOREIGN KEY (`pet_id`) REFERENCES `pets` (`pet_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `healtcare_visits`
--

LOCK TABLES `healtcare_visits` WRITE;
/*!40000 ALTER TABLE `healtcare_visits` DISABLE KEYS */;
/*!40000 ALTER TABLE `healtcare_visits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `owners`
--

DROP TABLE IF EXISTS `owners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `owners` (
  `deleted` tinyint(1) NOT NULL,
  `owner_id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `cbu` varchar(22) DEFAULT NULL,
  `birthdate` datetime DEFAULT NULL,
  PRIMARY KEY (`owner_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `owners`
--

LOCK TABLES `owners` WRITE;
/*!40000 ALTER TABLE `owners` DISABLE KEYS */;
INSERT INTO `owners` VALUES (0,1,'Aaron','Soria','22222','1995-12-28 00:00:00'),(0,4,'John','Smith',NULL,NULL),(0,5,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `owners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `deleted` int NOT NULL,
  `payment_id` int NOT NULL,
  `stamp` datetime NOT NULL,
  `amount` double NOT NULL,
  `out_of_term` tinyint(1) NOT NULL,
  `payment_date` datetime NOT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pet_services`
--

DROP TABLE IF EXISTS `pet_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pet_services` (
  `pet_service_id` int NOT NULL AUTO_INCREMENT,
  `pet_id` int NOT NULL,
  `service_id` int NOT NULL,
  `stamp` datetime NOT NULL,
  `expiration_day` int NOT NULL DEFAULT '10',
  PRIMARY KEY (`pet_service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pet_services`
--

LOCK TABLES `pet_services` WRITE;
/*!40000 ALTER TABLE `pet_services` DISABLE KEYS */;
/*!40000 ALTER TABLE `pet_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pet_types`
--

DROP TABLE IF EXISTS `pet_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pet_types` (
  `deleted` tinyint(1) NOT NULL,
  `pet_type_id` int NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`pet_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pet_types`
--

LOCK TABLES `pet_types` WRITE;
/*!40000 ALTER TABLE `pet_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `pet_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pets`
--

DROP TABLE IF EXISTS `pets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pets` (
  `deleted` tinyint(1) NOT NULL,
  `pet_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `owner_id` int NOT NULL,
  `pet_type_id` int NOT NULL,
  PRIMARY KEY (`pet_id`),
  KEY `fk_owner_id_001_idx` (`owner_id`),
  KEY `fk_pet_type_001_idx` (`pet_type_id`),
  CONSTRAINT `fk_owner_001` FOREIGN KEY (`owner_id`) REFERENCES `owners` (`owner_id`),
  CONSTRAINT `fk_pet_type_001` FOREIGN KEY (`pet_type_id`) REFERENCES `pet_types` (`pet_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pets`
--

LOCK TABLES `pets` WRITE;
/*!40000 ALTER TABLE `pets` DISABLE KEYS */;
/*!40000 ALTER TABLE `pets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refunds`
--

DROP TABLE IF EXISTS `refunds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refunds` (
  `deleted` tinyint(1) NOT NULL,
  `refund_id` int NOT NULL AUTO_INCREMENT,
  `amount` double NOT NULL,
  `stamp` datetime NOT NULL,
  `healtcare_visit_id` int NOT NULL,
  PRIMARY KEY (`refund_id`),
  KEY `fk_healtcare_visit_007_idx` (`healtcare_visit_id`),
  CONSTRAINT `fk_healtcare_visit_007` FOREIGN KEY (`healtcare_visit_id`) REFERENCES `healtcare_visits` (`healtcare_visit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refunds`
--

LOCK TABLES `refunds` WRITE;
/*!40000 ALTER TABLE `refunds` DISABLE KEYS */;
/*!40000 ALTER TABLE `refunds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `deleted` tinyint(1) NOT NULL,
  `role_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service_items`
--

DROP TABLE IF EXISTS `service_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service_items` (
  `deleted` tinyint(1) NOT NULL,
  `service_item_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` double NOT NULL,
  PRIMARY KEY (`service_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service_items`
--

LOCK TABLES `service_items` WRITE;
/*!40000 ALTER TABLE `service_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `service_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `deleted` tinyint(1) NOT NULL,
  `service_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_roles` (
  `user_role_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `role_id` int NOT NULL,
  PRIMARY KEY (`user_role_id`),
  KEY `fk_role_003_idx` (`role_id`),
  KEY `fk_user_003_idx` (`user_id`),
  CONSTRAINT `fk_role_003` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`),
  CONSTRAINT `fk_user_003` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_roles`
--

LOCK TABLES `user_roles` WRITE;
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `deleted` tinyint(1) NOT NULL,
  `user_id` int NOT NULL AUTO_INCREMENT,
  `stamp` datetime NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `owner_id` int DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `fk_owner_002_idx` (`owner_id`),
  CONSTRAINT `fk_owner_002` FOREIGN KEY (`owner_id`) REFERENCES `owners` (`owner_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (0,3,'0001-01-01 00:00:00','j+smith@example.com',4);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-13 20:25:56

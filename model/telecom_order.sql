-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: telecom
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `acc_id` int(11) NOT NULL,
  `plan_id` int(11) NOT NULL,
  `model_id` int(11) NOT NULL,
  `line_num` varchar(20) NOT NULL,
  `balance` int(11) NOT NULL,
  `orderdate` varchar(20) NOT NULL,
  `enddate` varchar(20) NOT NULL,
  `buyprice` int(11) NOT NULL,
  `rebatetype` varchar(20) NOT NULL,
  `bondmonth` varchar(20) NOT NULL,
  `ordertype` varchar(20) NOT NULL,
  `terminate` tinyint(4) NOT NULL,
  PRIMARY KEY (`order_id`),
  UNIQUE KEY `line_num_UNIQUE` (`line_num`),
  KEY `fk_order_account_idx` (`acc_id`),
  KEY `fk_order_model_idx` (`model_id`),
  KEY `fk_order_plan_idx` (`plan_id`),
  CONSTRAINT `fk_order_account` FOREIGN KEY (`acc_id`) REFERENCES `account` (`acc_id`),
  CONSTRAINT `fk_order_model` FOREIGN KEY (`model_id`) REFERENCES `model` (`model_id`),
  CONSTRAINT `fk_order_plan` FOREIGN KEY (`plan_id`) REFERENCES `plan` (`plan_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,1,1,1,'010-2305-5287',0,'2018-02-01','2020-01-31',990000,'24개월 요금할인','24개월','기기변경',0),(4,2,1,58,'010-8643-0081',0,'2019-06-13','2021-06-12',1375000,'24개월 요금할인','24개월','번호이동',0),(5,3,8,78,'010-9899-2934',0,'2019-07-14','2021-07-13',990000,'24개월 요금할인','24개월','기기변경',0),(6,4,10,15,'010-7812-0424',0,'2019-03-28','2021-03-27',1281500,'24개월 요금할인','24개월','번호이동',0),(7,5,15,3,'010-0280-0554',0,'2019-03-26','2021-03-25',2398000,'24개월 요금할인','24개월','기기변경',0),(8,6,17,72,'010-5367-2572',0,'2019-01-19','2021-01-18',1056000,'24개월 요금할인','24개월','번호이동',0),(9,7,14,39,'010-7616-3085',0,'2019-03-07','2021-03-06',1991000,'24개월 요금할인','24개월','기기변경',0),(10,8,1,70,'010-3758-7878',0,'2019-07-25','2021-07-24',1056000,'24개월 요금할인','24개월','번호이동',0),(11,9,9,49,'010-2437-0647',0,'2019-08-24','2021-08-23',1529000,'24개월 요금할인','24개월','기기변경',0),(12,10,15,54,'010-9517-2799',0,'2019-08-29','2021-08-28',1584000,'24개월 요금할인','24개월','번호이동',0),(13,11,2,55,'010-9760-1369',0,'2019-10-16','2021-10-15',1584000,'24개월 요금할인','24개월','기기변경',0),(14,12,14,21,'010-5694-9376',0,'2019-01-16','2021-01-15',1155000,'24개월 요금할인','24개월','번호이동',0),(15,13,9,49,'010-4013-0758',0,'2019-12-27','2021-12-26',1529000,'24개월 요금할인','24개월','기기변경',0),(16,14,5,57,'010-3793-6797',0,'2019-12-28','2021-12-27',1584000,'24개월 요금할인','24개월','번호이동',0),(17,15,14,41,'010-3485-9443',0,'2019-08-28','2021-08-27',1991000,'24개월 요금할인','24개월','기기변경',0),(18,16,12,45,'010-8102-6149',0,'2019-09-04','2021-09-03',1738000,'24개월 요금할인','24개월','번호이동',0),(19,17,16,9,'010-2502-8712',0,'2019-10-27','2021-10-26',1397000,'24개월 요금할인','24개월','기기변경',0),(20,18,18,38,'010-9218-5561',0,'2019-01-25','2021-01-24',1991000,'24개월 요금할인','24개월','번호이동',0),(21,19,13,20,'010-1585-4067',0,'2019-02-23','2021-02-22',1155000,'24개월 요금할인','24개월','기기변경',0),(22,20,9,43,'010-7269-4106',0,'2019-04-14','2021-04-13',1738000,'24개월 요금할인','24개월','번호이동',0),(23,8,2,7,'010-7844-7413',0,'2019-12-02','2019-12-02',1029000,'단말할인','일시불','신규가입',1);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-02 12:20:16

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
-- Table structure for table `plan`
--

DROP TABLE IF EXISTS `plan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plan` (
  `plan_id` int(11) NOT NULL AUTO_INCREMENT,
  `telecom` varchar(10) NOT NULL,
  `network` varchar(10) NOT NULL,
  `class` varchar(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `price` int(11) NOT NULL,
  `call_text` varchar(30) DEFAULT NULL,
  `data` varchar(30) DEFAULT NULL,
  `min_speed` varchar(30) DEFAULT NULL,
  `feature` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`plan_id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plan`
--

LOCK TABLES `plan` WRITE;
/*!40000 ALTER TABLE `plan` DISABLE KEYS */;
INSERT INTO `plan` VALUES (1,'SKT','4G','0플랜','라지',69000,'무제한','100GB','5Mbps','만 24세 이하에 한해 가입 가능, 가족간 데이터 공유 최대 20GB, 기본 혜택 : FLO 300곡 무료 스트리밍 / 클라우드베리 36GB 제공, 추가 혜택 : 멤버십 VIP / oksusu 12,000포인트 매달 제공 / FLO 무제한 스트리밍 중 택1, oksusu 월정액 무료'),(2,'SKT','5G','5GX','플래티넘',125000,'무제한','무제한','속도제한 없음','가족간 데이터 공유 최대 50GB, 멤버십 VIP, T All케어 100 제공(단독형) 100% 할인, 콘텐츠 : FLO 앤 데이터 플러스 무료, POOQ 콘텐츠 팩(플러스) 제공, 스마트기기 2회선 무료'),(3,'SKT','5G','5GX','프라임',89000,'무제한','무제한','속도제한 없음','가족간 데이터 공유 최대 30GB, 멤버십 VIP, T All케어 100 제공(단독형) 100% 할인, 콘텐츠 : FLO 앤 데이터 무료 / POOQ 콘텐츠 팩 중 택1, 스마트기기 1회선 무료'),(4,'SKT','5G','5GX','스탠다드',75000,'무제한','200GB','5Mbps','멤버십 VIP / T All케어 파손(단독형) 100% 할인 중 택1'),(5,'SKT','4G','0플랜','미디엄',50000,'무제한','6GB','1Mbps','만 24세 이하에 한해 가입 가능, 가족간 데이터 공유 받기만 가능, 밤지킴이 데이터 4배 : 0시~7시 데이터 할인 75%, 기본 혜택 : FLO 300곡 무료 스트리밍 / 클라우드베리 36GB 제공, 추가 혜택 : 토,일요일 각 2GB + 3Mbps / 매일 0~7시 데이터 무료 / 매일 지정 3시간 동안 2GB + 3Mbps 중 택1, oksusu 월정액 무료'),(6,'SKT','4G','0플랜','스몰',33000,'무제한','2GB','400Kbps','만 24세 이하에 한해 가입 가능, 가족간 데이터 공유 받기만 가능, 밤지킴이 데이터 4배 : 0시~7시 데이터 할인 75%, 기본 혜택 : FLO 300곡 무료 스트리밍 / 클라우드베리 36GB 제공, 추가 혜택 : 토,일요일 각 2GB + 3Mbps / 매일 0~7시 데이터 무료 / 매일 지정 3시간 동안 2GB + 3Mbps 중 택1'),(7,'KT','5G','슈퍼플랜','프리미엄',130000,'무제한','무제한','속도제한 없음','데이터 나눠쓰기 100GB, 데이터 나눠쓰기 속도제한 200Kbps, 로밍시 속도제한 3Mbps, VVIP 멤버십, 휴대폰 보험, 스마트 기기 월정액 무료(1회선), 가족결합 할인 가입 가능'),(8,'KT','5G','슈퍼플랜','스페셜',100000,'무제한','무제한','속도제한 없음','데이터 나눠쓰기 50GB, 데이터 나눠쓰기 속도제한 200Kbps, 로밍시 속도제한 100Kbps, VVIP 멤버십, 휴대폰 보험, 스마트 기기 월정액 무료(1회선), 가족결합 할인 가입 가능'),(9,'KT','5G','슈퍼플랜','베이직',80000,'무제한','무제한','속도제한 없음','데이터 나눠쓰기 20GB, 데이터 나눠쓰기 속도제한 200Kbps, 로밍시 속도제한 100Kbps, VIP 멤버십, 가족결합 할인 가입 가능'),(10,'KT','4G','Y24 ON','프리미엄',89000,'무제한','무제한','속도제한 없음','만 24세 이하에 한해 가입 가능, VIP 멤버십, 휴대폰 보험, 스마트 기기 요금 지원, 미디어팩 무료, 프라임무비팩 반값'),(11,'KT','4G','Y24 ON','비디오',69000,'무제한','100GB','5Mbps','만 24세 이하에 한해 가입 가능, VIP 멤버십, 휴대폰 보험, 스마트 기기 요금 지원, 미디어팩 무료, 프라임무비팩 반값'),(12,'KT','4G','Y24 ON','톡',49000,'무제한','6GB','1Mbps','만 24세 이하에 한해 가입 가능, 올레 tv 모바일 데일리팩 무료, 미디어팩/프라임무비팩 반값'),(13,'LG U+','5G','U+ 5G','프리미엄',95000,'무제한','무제한','속도제한 없음','데이터 나눠쓰기 100GB, U+모바일TV 기본 월정액 무료, 지니뮤직 스트리밍 무제한, 2nd 디바이스 1회선 무료'),(14,'LG U+','5G','U+ 5G','스페셜',85000,'무제한','무제한','속도제한 없음','데이터 나눠쓰기 50GB, U+모바일TV 기본 월정액 무료'),(15,'LG U+','5G','U+ 5G','스탠다드',75000,'무제한','150GB','5Mbps','데이터 나눠쓰기 10GB, U+모바일TV 기본 월정액 무료'),(16,'LG U+','4G','추걱데 청소년','59',59000,'무제한','9GB','1Mbps','데이터 나눠쓰기 불가, U+ 비디오포털 기본 월정액 서비스 무료'),(17,'LG U+','4G','추걱데 청소년','49',49000,'무제한','6GB','1Mbps','데이터 나눠쓰기 불가, U+ 비디오포털 기본 월정액 서비스 무료'),(18,'LG U+','4G','추걱데 청소년','39',39000,'무제한','2GB','400Kbps','데이터 나눠쓰기 불가');
/*!40000 ALTER TABLE `plan` ENABLE KEYS */;
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

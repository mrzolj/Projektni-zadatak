/*
Navicat MySQL Data Transfer

Source Server         : MySQL
Source Server Version : 50018
Source Host           : localhost:3306
Source Database       : projektni zadatak ppj

Target Server Type    : MYSQL
Target Server Version : 50018
File Encoding         : 65001

Date: 2022-04-09 18:57:58
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `artikal`
-- ----------------------------
DROP TABLE IF EXISTS `artikal`;
CREATE TABLE `artikal` (
  `artikal_id` int(11) NOT NULL auto_increment,
  `naziv_artikla` varchar(50) default NULL,
  `vrsta_artikla` varchar(50) default NULL,
  `cijena` double default NULL,
  PRIMARY KEY  (`artikal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of artikal
-- ----------------------------
INSERT INTO `artikal` VALUES ('1', 'iPhone 13 mini', 'Phone', '1300');
INSERT INTO `artikal` VALUES ('2', 'iPhone 13 128GB', 'Phone', '1800');
INSERT INTO `artikal` VALUES ('3', 'iPhone 13 Pro 256GB', 'Phone', '2800');
INSERT INTO `artikal` VALUES ('4', 'MacBook Pro 16` 1TB', 'Laptop', '5100');
INSERT INTO `artikal` VALUES ('12', 'iPhone 13 Pro Max 512GB', 'Phone', '3200');
INSERT INTO `artikal` VALUES ('26', 'AirPods Pro', 'Headphones', '350');

-- ----------------------------
-- Table structure for `kupac`
-- ----------------------------
DROP TABLE IF EXISTS `kupac`;
CREATE TABLE `kupac` (
  `kupac_id` int(11) NOT NULL auto_increment,
  `ime` varchar(50) default NULL,
  `prezime` varchar(50) default NULL,
  `grad` varchar(50) default NULL,
  `adresa` varchar(50) default NULL,
  `telefon` varchar(50) default NULL,
  `user` varchar(50) default NULL,
  `pass` varchar(50) default NULL,
  PRIMARY KEY  (`kupac_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of kupac
-- ----------------------------
INSERT INTO `kupac` VALUES ('1', 'Admin', 'Admin', null, null, null, 'admin', 'admin');
INSERT INTO `kupac` VALUES ('2', 'Steven', 'King', 'Sarajevo', 'Safeta Zajke 2', '222222', 'steven.k', '2steven.k');
INSERT INTO `kupac` VALUES ('7', 'Bruce', 'Ernst', 'Tuzla', 'Trg Alije Izetbegovica', '1234356', 'bruce.e', '7bruce.e');
INSERT INTO `kupac` VALUES ('8', 'David', 'Austin', 'Mostar', 'Bulevar Mese Selimovica', '654321', 'david.a', '8david.a');

-- ----------------------------
-- Table structure for `narudzbenica`
-- ----------------------------
DROP TABLE IF EXISTS `narudzbenica`;
CREATE TABLE `narudzbenica` (
  `narudzbenica_id` int(11) NOT NULL auto_increment,
  `kupac_id` int(11) default NULL,
  `datum_narudzbe` date default NULL,
  PRIMARY KEY  (`narudzbenica_id`),
  KEY `kupac_id` (`kupac_id`),
  CONSTRAINT `narudzbenica_ibfk_1` FOREIGN KEY (`kupac_id`) REFERENCES `kupac` (`kupac_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of narudzbenica
-- ----------------------------

-- ----------------------------
-- Table structure for `skladiste`
-- ----------------------------
DROP TABLE IF EXISTS `skladiste`;
CREATE TABLE `skladiste` (
  `id` int(11) NOT NULL auto_increment,
  `artikal_id` int(11) default NULL,
  `kolicina_stanje` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of skladiste
-- ----------------------------
INSERT INTO `skladiste` VALUES ('1', '1', '17');
INSERT INTO `skladiste` VALUES ('2', '2', '10');
INSERT INTO `skladiste` VALUES ('3', '3', '15');
INSERT INTO `skladiste` VALUES ('4', '4', '20');
INSERT INTO `skladiste` VALUES ('12', '25', '50');
INSERT INTO `skladiste` VALUES ('13', '26', '15');

-- ----------------------------
-- Table structure for `stavka_narudzbenice`
-- ----------------------------
DROP TABLE IF EXISTS `stavka_narudzbenice`;
CREATE TABLE `stavka_narudzbenice` (
  `stavka_id` int(11) NOT NULL auto_increment,
  `narudzbenica_id` int(11) default NULL,
  `artikal_id` int(11) default NULL,
  `kolicina` int(11) default NULL,
  PRIMARY KEY  (`stavka_id`),
  KEY `narudzbenica_id` (`narudzbenica_id`),
  KEY `artikal_id` (`artikal_id`),
  CONSTRAINT `stavka_narudzbenice_ibfk_1` FOREIGN KEY (`narudzbenica_id`) REFERENCES `narudzbenica` (`narudzbenica_id`),
  CONSTRAINT `stavka_narudzbenice_ibfk_2` FOREIGN KEY (`artikal_id`) REFERENCES `artikal` (`artikal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of stavka_narudzbenice
-- ----------------------------

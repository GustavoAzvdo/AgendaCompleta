-- MySQL Script generated by MySQL Workbench
-- Mon Sep 19 23:49:29 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema AgendaCompleta
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema AgendaCompleta
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AgendaCompleta` DEFAULT CHARACTER SET utf8 ;
USE `AgendaCompleta` ;

-- -----------------------------------------------------
-- Table `AgendaCompleta`.`Endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AgendaCompleta`.`Endereco` (
  `idEndereco` INT NOT NULL AUTO_INCREMENT,
  `logradouro` VARCHAR(150) NOT NULL,
  `bairro` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `CEP` DECIMAL(8) NOT NULL,
  `estadoUF` VARCHAR(2) NOT NULL,
  PRIMARY KEY (`idEndereco`)
);
 
-- -----------------------------------------------------
-- Table `AgendaCompleta`.`Pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AgendaCompleta`.`Pessoa` (
  `idPessoa` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(200) NOT NULL,
  `CPF` DECIMAL(11) NOT NULL,
  `dataNascimento` DATE NOT NULL,
  `email` VARCHAR(200) NOT NULL,
  `sexo` VARCHAR(45) NOT NULL,
  `numeroCasa` VARCHAR(45) NOT NULL,
  `complemento` VARCHAR(45) NOT NULL,
  `fkEndereco` INT NOT NULL,
  PRIMARY KEY (`idPessoa`), 
  FOREIGN KEY (`fkEndereco`) REFERENCES `AgendaCompleta`.`Endereco` (`idEndereco`)
);


-- -----------------------------------------------------
-- Table `AgendaCompleta`.`Telefone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AgendaCompleta`.`Telefone` (
  `idTelefone` INT NOT NULL AUTO_INCREMENT,
  `fkPessoa` INT NOT NULL,
  `operadora` VARCHAR(45) NOT NULL,
  `DDD` DECIMAL(2) NOT NULL,
  `numero` DECIMAL(9) NOT NULL,
  PRIMARY KEY (`idTelefone`),
  FOREIGN KEY (`fkPessoa`) REFERENCES `AgendaCompleta`.`Pessoa` (`idPessoa`)
);


-- -----------------------------------------------------
-- Table `AgendaCompleta`.`Agenda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `AgendaCompleta`.`Agenda` (
  `idAgenda` INT NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(45) NOT NULL,
  `data` DATE NOT NULL,
  `hora` TIME NOT NULL,
  `descricao` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`idAgenda`)
);



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
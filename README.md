# Desafio_CRUD

Trabalho feito por Fernando e Arthur Henrique Kochan





Usar porta 3306
MySQL

CREATE DATABASE store;

USE store;

CREATE TABLE `store`.`houses` (`id` INT NOT NULL AUTO_INCREMENT ,
`location` VARCHAR(255) NOT NULL ,
`area` VARCHAR(255) NOT NULL , 
`price` DOUBLE NOT NULL DEFAULT 0,
`floors` INT NOT NULL ,
`bedrooms` INT NOT NULL DEFAULT 1,
`bathrooms` INT NOT NULL DEFAULT 1,
`furnished` TINYINT(1) NOT NULL DEFAULT 0,
PRIMARY KEY (`id`))
ENGINE = InnoDB;

SELECT * FROM houses; #Mostrar  o banco de dados

TRUNCATE TABLE houses; #Limpa a tabela de usuários

    

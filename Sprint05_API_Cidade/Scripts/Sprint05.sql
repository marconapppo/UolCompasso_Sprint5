USE [SPRINT05_CIDADES_CLIENTES]

CREATE TABLE [CIDADE](
	[Id] [uniqueidentifier] NOT NULL,
    NOME VARCHAR(30) NOT NULL,
    ESTADO varchar(30) NOT NULL
);

CREATE TABLE CLIENTE(
	[Id] [uniqueidentifier] NOT NULL,
    NOME VARCHAR(30) NOT NULL,
    DATA_NASC date NOT NULL,
    CIDADE_ID [uniqueidentifier] NOT NULL,
    CEP VARCHAR(15),
    LOGRADOURO VARCHAR(30),
    BAIRRO VARCHAR(30)
);
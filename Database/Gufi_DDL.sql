CREATE DATABASE Gufi
GO

USE Gufi

CREATE TABLE tipoUsuario(
	idTipoUsuario		INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario	VARCHAR(100) NOT NULL UNIQUE
)
GO

CREATE TABLE usuario(
	idUsuario			INT PRIMARY KEY IDENTITY,
	idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario			VARCHAR(100) NOT NULL,
	email				VARCHAR(500) NOT NULL UNIQUE,
	senha				VARCHAR(100) NOT NULL
)
GO

CREATE TABLE tipoEvento(
	idTipoEvento		INT PRIMARY KEY IDENTITY,
	tituloTipoEvento	VARCHAR(100)
)
GO

CREATE TABLE instituicao(
	idInstituicao		INT PRIMARY KEY IDENTITY,
	cnpj				CHAR(18) NOT NULL UNIQUE,
	nomeFantasia		VARCHAR(100) NOT NULL,
	endereco			VARCHAR(200) NOT NULL UNIQUE
)
GO

CREATE TABLE evento(
	idEvento			INT PRIMArY KEY IDENTITY,
	idTipoEvento		INT FOREIGN KEY REFERENCES tipoEvento(idTipoEvento),
	idInstituicao		INT FOREIGN KEY REFERENCES instituicao(idInstituicao),
	nomeEvento			VARCHAR(100) NOT NULL,
	descricao			VARCHAR(200) NOT NULL,
	dataEvento			DATE NOT NULL,
	acessoLivre			BIT DEFAULT(1)
)
GO

CREATE TABLE situacao(
	idSituacao			INT PRIMARY KEY IDENTITY,
	descricao			VARCHAR(100)
)
GO

CREATE TABLE presenca(
	idPresenca			INT PRIMARY KEY IDENTITY,
	idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idEvento			INT FOREIGN KEY REFERENCES evento(idEvento),
	idSituacao			INT FOREIGN KEY REFERENCES situacao(idSituacao)
)
GO
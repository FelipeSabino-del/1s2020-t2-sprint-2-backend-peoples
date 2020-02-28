--CRIAR DB
CREATE DATABASE T_Peoples

--UTILIZAR O DB CRIADO
USE T_Peoples;

--CRIAÇÃO DE TABELAS
CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (255) NOT NULL,
	Sobrenome VARCHAR (255) NOT NULL,
	DataNascimento DATE
);

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Senha VARCHAR (255) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome LIKE '% @pesquisa %' ORDER BY Nome DESC;

ALTER TABLE Funcionarios
ADD IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario);

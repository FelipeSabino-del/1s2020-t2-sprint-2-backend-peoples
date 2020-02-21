--CRIAR DB
CREATE DATABASE T_Peoples

--UTILIZAR O DB CRIADO
USE T_Peoples;

--CRIA��O DE TABELAS
CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (255) NOT NULL,
	Sobrenome VARCHAR (255) NOT NULL,
	DataNascimento DATE
);

SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome LIKE '% @pesquisa %' ORDER BY Nome DESC;

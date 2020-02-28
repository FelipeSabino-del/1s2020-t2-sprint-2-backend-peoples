--ACESSAR O DB
USE T_Peoples;

--INSERÇÃO DE DADOS NO DB
INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento, IdUsuario)
VALUES ('Catarina','Strada','10/03/2000','1'),('Tadeu','Vitelli','14/06/1993','2');

TRUNCATE TABLE Funcionarios;

INSERT INTO TipoUsuario (Titulo)
VALUES ('administrador'),('comum');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES ('catarina@email.com','123','2'), ('tadeu@email.com','123','2'), ('felipe@email.com','123','2'), ('admin@email.com','123','1')
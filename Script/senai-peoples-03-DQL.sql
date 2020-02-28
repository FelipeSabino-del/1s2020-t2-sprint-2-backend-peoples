--ACESSAR O DB
USE T_Peoples;

--MOSTRAR TODOS FUNCIONARIOS CADASTRADOS
SELECT * FROM Funcionarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

SELECT IdUsuario, Email, Senha, TipoUsuario.Titulo FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario;
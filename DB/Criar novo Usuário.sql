---------------
-- PREENCHER --
---------------
DECLARE @LOGIN VARCHAR(30) = ''
DECLARE @SENHA VARCHAR(30) = ''

INSERT INTO TbBDG_UsuarioSistema VALUES (@LOGIN, CONVERT(varbinary(500), pwdEncrypt(@SENHA)), 1)

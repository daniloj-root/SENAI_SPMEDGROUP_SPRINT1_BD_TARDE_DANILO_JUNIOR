SELECT Situacao.Descricao as Situa��o
	  ,Usuario.NomeUsuario as Nome
	  ,CASE
		WHEN Usuario.IdTipoUsuario = 1 THEN Usuario.NomeUsuario
		ELSE 'N/A'
	   END AS 'Paciente'
	  ,CASE
		 WHEN Usuario.IdTipoUsuario = 2 THEN Usuario.NomeUsuario
			ELSE 'N/A'
		END AS 'M�dico'
	  ,Medico.CRM
	  ,Area.Descricao as �rea
      ,Usuario.Email 
	  ,Prontuario.RG
	  ,Prontuario.Endereco as Endere�o
	  ,Prontuario.Nascimento as 'Data de nascimento'
	  ,DATEDIFF(YY, Prontuario.Nascimento, GETDATE()) -
		CASE
			WHEN DATEADD(YY, DATEDIFF(YY,Prontuario.Nascimento,GETDATE()),Prontuario.Nascimento) 
			> GETDATE() THEN 1
			ELSE 0
		END AS Idade
	  ,Consulta.DataConsulta as 'Data da Consulta'
FROM
Consulta
INNER JOIN
Situacao ON Situa��o.IdSituacao = Consulta.IdSituacao
INNER JOIN
Medico ON Medico.IdMedico = Consulta.IdSituacao 
INNER JOIN
Prontuario ON Prontu�rio.IdProntuario = Consulta.IdProntuario
INNER JOIN
Usuario ON Usu�rio.IdUsuario = Prontu�rio.IdUsuario AND Usu�rio.IdUsuario = M�dico.IdUsuario
INNER JOIN
Area ON M�dico.IdArea = �rea.IdArea
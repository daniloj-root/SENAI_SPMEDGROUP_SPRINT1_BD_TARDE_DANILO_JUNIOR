SELECT Situacao.Descricao as Situação
	  ,Usuario.NomeUsuario as Nome
	  ,CASE
		WHEN Usuario.IdTipoUsuario = 1 THEN Usuario.NomeUsuario
		ELSE 'N/A'
	   END AS 'Paciente'
	  ,CASE
		 WHEN Usuario.IdTipoUsuario = 2 THEN Usuario.NomeUsuario
			ELSE 'N/A'
		END AS 'Médico'
	  ,Medico.CRM
	  ,Area.Descricao as Área
      ,Usuario.Email 
	  ,Prontuario.RG
	  ,Prontuario.Endereco as Endereço
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
Situacao ON Situação.IdSituacao = Consulta.IdSituacao
INNER JOIN
Medico ON Medico.IdMedico = Consulta.IdSituacao 
INNER JOIN
Prontuario ON Prontuário.IdProntuario = Consulta.IdProntuario
INNER JOIN
Usuario ON Usuário.IdUsuario = Prontuário.IdUsuario AND Usuário.IdUsuario = Médico.IdUsuario
INNER JOIN
Area ON Médico.IdArea = Área.IdArea
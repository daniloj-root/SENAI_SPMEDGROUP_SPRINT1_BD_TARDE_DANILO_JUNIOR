INSERT INTO Clinica (
					  NomeFantasia
				     ,RazaoSocial 
					 ,Telefone
				     ,Endereco
				     ,HoraInicio
				     ,HoraFim
				    )
VALUES
	  ('Clínica Possarle', 'SP Medical Group', '(11) 96022-8765', 'Av. Barão Limeira, 532, São Paulo, SP', '06h00', '18h30')

INSERT INTO Area (
			      Descricao
				 )
VALUES 
		('Cirurgia Pediátrica')
	   ,('Cirurgia Plástica')
	   ,('Cirurgia Torácica')
	   ,('Cirurgia Vascular')
	   ,('Dermatologia')
	   ,('Radioterapia')
	   ,('Urologia')
	   ,('Pediatria')
	   ,('Psiquiatria')
	   ,('Anestesiologista')

INSERT INTO TiposUsuario (
						   Descricao
						 )
VALUES 
		('Paciente')
	   ,('Médico')
	   ,('Admin')
	
INSERT INTO Usuario (
					  NomeUsuario
					 ,Email
					 ,Senha
					 ,IdTipoUsuario
                    )
VALUES 
	   ('Grande Senhor Deus', 'deus@deus.com', 'deus', 3)
	  ,('Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo', 2)
	  ,('Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', 'plebeu', 2)
	  ,('Helena', 'helena.souza@spmedicalgroup.com.br', 'helena', 2)
	  ,('Ligia', 'ligia@gmail.com', 'ligia', 2)
	  ,('Alexandre', 'alexandre@gmail.com', 'alex', 1)
	  ,('Fernando', 'fernando@gmail.com', 'fefe', 1)
	  ,('Henrique', 'henrique@gmail.com', 'henriqqq', 1)
	  ,('João', 'henrique@gmail.com', 'jonas', 1)
	  ,('Bruno', 'bruno@gmail.com', 'brunao', 1)
	  ,('Mariana', 'mariana@outlook.com', 'mari', 1)

INSERT INTO Medico (
				   	 IdClinica
				    ,IdUsuario
				    ,IdArea
				    ,CRM
				    ,Telefone
				    ,Endereco
				   )
VALUES 
	  (1, 2, 10, '54356SP', '(11)96784-54 67', 'Rua Colagendah, 38')
	 ,(1, 3, 8, '53452SP', '(11)96784-54 67', 'Rua Colagendah, 38')
	 ,(1, 4, 9, '65463SP', '(11)96784-54 67', 'Rua Colagendah, 38')

INSERT INTO Prontuario (
					     RG
					    ,CPF
						,Telefone
					    ,Nascimento
					    ,Endereco
					    ,IdUsuario
					   )
VALUES
	   ('435225435', '94839859000', '11 93456-7654', '1983-10-13', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', 5)
      ,('326543457', '73556944057', '11 98765-6543', '2001-07-23', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200	', 6)
	  ,('546365253', '16839338002', '11 3456-7654', '1978-10-10', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', 7)
	  ,('543663625', '14332654765', '11 97208-4453', '1985-10-13', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', 8)
	  ,('t32544441', '91305348010', '11 7656-6377', '1975-08-27', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', 9)
	  ,('545662667', '79799299004', '11 95436-8769', '1972-03-21', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-381', 10)
	  ,('545662668', '13771913039', NULL, '2018-03-05', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-382', 11)

INSERT INTO Situacao (
					   Descricao
					)
VALUES 
		('Agendada')
	   ,('Realizada')
	   ,('Cancelada')

INSERT INTO Consulta (
					   IdMedico
					  ,IdClinica
					  ,IdProntuario
					  ,DataConsulta
					  ,IdSituacao
					)

VALUES
	  (1, 1, 7, '2020-20-01 15:00:00', 2)
	 ,(2, 1, 2, '2020-06-01 10:00:00', 3)
	 ,(2, 1, 3, '2020-07-02 11:00:00', 2)
	 ,(2, 1, 2, '2018-06-02 10:00:00', 2)
	 ,(1, 1, 4, '2019-07-02 11:00:00', 3)
	 ,(3, 1, 7, '2020-08-03 15:00:00', 1)
	 ,(1, 1, 4, '2020-09-03 11:00:45', 1)
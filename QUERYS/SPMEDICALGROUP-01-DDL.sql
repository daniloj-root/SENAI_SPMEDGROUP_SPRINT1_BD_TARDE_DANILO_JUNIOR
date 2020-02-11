CREATE DATABASE SPMedGroupTarde
GO
USE SPMedGroupTarde
GO

CREATE TABLE Clinica (
				      IdClinica INT PRIMARY KEY IDENTITY
					 ,NomeFantasia VARCHAR(100) NOT NULL
					 ,RazaoSocial VARCHAR (100) NOT NULL
					 ,Telefone VARCHAR(14) NOT NULL 
					 ,Endereco VARCHAR(100) NOT NULL
					 ,Horario VARCHAR(9) NOT NULL
				 );

CREATE TABLE Area (
					IdArea INT PRIMARY KEY IDENTITY
				   ,Descricao VARCHAR(100) NOT NULL
			   );

CREATE TABLE TipoUsuario (
						  IdTipoUsuario INT PRIMARY KEY IDENTITY
						 ,Descricao VARCHAR(100) NOT NULL
				    );

CREATE TABLE Usuario (
					  IdUsuario INT PRIMARY KEY IDENTITY
					 ,NomeUsuario VARCHAR(100) NOT NULL
					 ,Email VARCHAR(100) NOT NULL 
					 ,Senha VARCHAR(200) NOT NULL
					 ,IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL
				);

CREATE TABLE Medico (
					 IdMedico INT PRIMARY KEY IDENTITY
					,CRM VARCHAR (7) NOT NULL
					,Telefone VARCHAR(14) NOT NULL 
					,Endereco VARCHAR(100) NOT NULL
					,IdClinica INT FOREIGN KEY REFERENCES Clínica(IdClinica) NOT NULL
					,IdArea INT FOREIGN KEY REFERENCES Área(IdArea) NOT NULL
					,IdUsuario INT FOREIGN KEY REFERENCES Usuário(IdUsuario) NOT NULL
				);

CREATE TABLE Prontuario (
						 IdProntuario INT PRIMARY KEY IDENTITY
						,RG VARCHAR(9) NOT NULL
						,CPF VARCHAR(11) NOT NULL
						,Nascimento DATE NOT NULL
						,Endereco VARCHAR(100) NOT NULL
						,IdUsuario INT FOREIGN KEY REFERENCES Usuário(IdUsuario) NOT NULL
					);

CREATE TABLE Situacao (
						IdSituacao INT PRIMARY KEY IDENTITY
					   ,Descricao VARCHAR(100) NOT NULL
					);

CREATE TABLE Consulta (
						IdConsulta INT PRIMARY KEY IDENTITY
					   ,DataConsulta DATETIME NOT NULL
					   ,IdSituacao INT FOREIGN KEY REFERENCES Situação(IdSituacao) NOT NULL
					   ,IdClinica INT FOREIGN KEY REFERENCES Clínica(IdClinica) NOT NULL
					   ,IdMedico INT FOREIGN KEY REFERENCES Médico(IdMedico) NOT NULL
					   ,IdProntuario INT FOREIGN KEY REFERENCES Prontuário(IdProntuario) NOT NULL
					);


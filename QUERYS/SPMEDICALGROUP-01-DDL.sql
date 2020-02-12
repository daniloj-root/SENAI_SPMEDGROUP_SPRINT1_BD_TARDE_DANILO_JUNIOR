CREATE DATABASE SPMedGroupTarde
GO
USE SPMedGroupTarde
GO

CREATE TABLE Clinica (
				      IdClinica INT PRIMARY KEY IDENTITY
					 ,NomeFantasia VARCHAR(100) NOT NULL
					 ,RazaoSocial VARCHAR (100) NOT NULL
					 ,Telefone VARCHAR(15) NOT NULL 
					 ,Endereco VARCHAR(100) NOT NULL
					 ,HoraInicio VARCHAR(9) NOT NULL
					 ,HoraFim VARCHAR(9) NOT NULL
				 );

CREATE TABLE Area (
					IdArea INT PRIMARY KEY IDENTITY
				   ,Descricao VARCHAR(100) NOT NULL
			   );

CREATE TABLE TiposUsuario (
						  IdTipoUsuario INT PRIMARY KEY IDENTITY
						 ,Descricao VARCHAR(100) NOT NULL
				    );

CREATE TABLE Usuario (
					  IdUsuario INT PRIMARY KEY IDENTITY
					 ,NomeUsuario VARCHAR(100) NOT NULL
					 ,Email VARCHAR(100) NOT NULL 
					 ,Senha VARCHAR(200) NOT NULL
					 ,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario) NOT NULL
				);

CREATE TABLE Medico (
					 IdMedico INT PRIMARY KEY IDENTITY
					,CRM VARCHAR (7) NOT NULL
					,Telefone VARCHAR(15) NOT NULL 
					,Endereco VARCHAR(100) NOT NULL
					,IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL
					,IdArea INT FOREIGN KEY REFERENCES Area(IdArea) NOT NULL
					,IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL
				);

CREATE TABLE Prontuario (
						 IdProntuario INT PRIMARY KEY IDENTITY
						,RG VARCHAR(9) NOT NULL
						,CPF VARCHAR(11) NOT NULL
						,Telefone VARCHAR(15)
						,Nascimento DATE NOT NULL
						,Endereco VARCHAR(100) NOT NULL
						,IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL
					);

CREATE TABLE Situacao (
						IdSituacao INT PRIMARY KEY IDENTITY
					   ,Descricao VARCHAR(100) NOT NULL
					);

CREATE TABLE Consulta (
						IdConsulta INT PRIMARY KEY IDENTITY
					   ,DataConsulta DATETIME NOT NULL
					   ,IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao) DEFAULT (1)
					   ,IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL
					   ,IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL
					   ,IdProntuario INT FOREIGN KEY REFERENCES Prontuario(IdProntuario) NOT NULL
					);


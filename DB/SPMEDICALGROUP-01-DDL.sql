CREATE DATABASE SPMedGroup_Tarde
GO
USE SPMedGroup_Tarde
GO

CREATE TABLE Endereco (
						IdEndereco INT PRIMARY KEY IDENTITY
					   ,Descricao VARCHAR(200)
				);

CREATE TABLE Telefone (
						IdTelefone INT PRIMARY KEY IDENTITY,
						Descricao VARCHAR(200)
					);

CREATE TABLE Clinica (
				      IdClinica INT PRIMARY KEY IDENTITY
					 ,NomeFantasia VARCHAR(100) NOT NULL
					 ,RazaoSocial VARCHAR (100) NOT NULL
					 ,Telefone VARCHAR(15) NOT NULL 
					 ,IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco)
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
					,CRM VARCHAR (7) UNIQUE NOT NULL
					,IdTelefone INT FOREIGN KEY REFERENCES Telefone(IdTelefone)
					,IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco)
					,IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL
					,IdArea INT FOREIGN KEY REFERENCES Area(IdArea) NOT NULL
					,IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL
				);

CREATE TABLE Prontuario (
						 IdProntuario INT PRIMARY KEY IDENTITY
						,RG VARCHAR(9) UNIQUE NOT NULL
						,CPF VARCHAR(11) UNIQUE NOT NULL
						,Nascimento DATE NOT NULL
						,IdTelefone INT FOREIGN KEY REFERENCES Telefone(IdTelefone)
						,IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco)
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

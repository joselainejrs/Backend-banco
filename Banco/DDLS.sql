/*DDLS*/
CREATE DATABASE fastrade;
DROP DATABASE fastrade;

USE fastrade;


CREATE TABLE Tipo_Usuario(
Id_Tipo_Usuario INT IDENTITY PRIMARY KEY NOT NULL,
Tipo VARCHAR(255) 
);

CREATE TABLE Endereco(
Id_Endereco INT IDENTITY PRIMARY KEY NOT NULL,
NomeEndereco VARCHAR(255) NOT NULL,
Numero INT NOT NULL,
Complemento VARCHAR(255) NOT NULL,
CEP VARCHAR(9) NOT NULL,
Bairro VARCHAR(255) NOT NULL,
Estado CHAR(2) NOT NULL
);

CREATE TABLE Cat_Produto(
Id_Cat_Produto INT IDENTITY PRIMARY KEY NOT NULL,
Tipo VARCHAR(255) UNIQUE,
);

CREATE TABLE Produto(
Id_Produto INT IDENTITY PRIMARY KEY NOT NULL,
Id_Cat_Produto INT FOREIGN KEY REFERENCES Cat_Produto(Id_Cat_Produto),
);

CREATE TABLE Receita(
Id_Receita INT IDENTITY PRIMARY KEY NOT NULL,
Nome_Receita VARCHAR(255)
);


CREATE TABLE Produto_Receita(
Id_Produto_Receita INT IDENTITY PRIMARY KEY NOT NULL,
Id_Produto INT FOREIGN KEY REFERENCES Produto(Id_Produto),
Id_Receita INT FOREIGN KEY REFERENCES Receita(Id_Receita)
);


CREATE TABLE Usuario(
Id_Usuario INT IDENTITY PRIMARY KEY NOT NULL,
Id_Endereco     INT FOREIGN KEY REFERENCES Endereco(Id_Endereco),
Id_Tipo_Usuario INT FOREIGN KEY REFERENCES Tipo_Usuario(Id_Tipo_Usuario),
Nome_Razao_Social VARCHAR (255) NOT NULL,
CPF_CNPJ VARCHAR(14) NOT NULL,
Email VARCHAR(255) NOT NULL,
Senha VARCHAR(255) NOT NULL,
Celular_Telefone VARCHAR (255) NOT NULL,
Foto_Url_Usuario TEXT
);

CREATE TABLE Pedido(
Id_Pedido INT IDENTITY PRIMARY KEY NOT NULL,
Id_Produto     INT FOREIGN KEY REFERENCES Produto(Id_Produto),
Id_Usuario     INT FOREIGN KEY REFERENCES Usuario(Id_Usuario),
Quantidade INT NOT NULL
);


CREATE TABLE Oferta(
Id_Oferta INT IDENTITY PRIMARY KEY NOT NULL,
Id_Produto     INT FOREIGN KEY REFERENCES Produto(Id_Produto),
Id_Usuario     INT FOREIGN KEY REFERENCES Usuario(Id_Usuario),
NomeProduto VARCHAR (255) NOT NULL,
Quantidade VARCHAR (255) NOT NULL,
Preco MONEY NOT NULL,
Descricao_do_Produto VARCHAR (255) NOT NULL,
Validade DATETIME NOT NULL,
Foto_Url_Oferta TEXT NOT NULL
);




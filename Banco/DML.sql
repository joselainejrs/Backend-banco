/*DML*/

USE fastrade

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Consumidor')

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Fornecedor')

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Adm')

INSERT INTO Endereco (Rua_AV, Numero, Complemento,  CEP, Bairro,  Estado  ) VALUES ('Jardim Madalena', 67,  23, '12345678', 'Alfredo dos Andes', 'SP'  )

INSERT INTO Cat_Produto(Tipo) VALUES ('Conserva')

INSERT INTO Cat_Produto(Tipo) VALUES ('Bebida')

INSERT INTO Cat_Produto(Tipo) VALUES ('Graos')

INSERT INTO Cat_Produto(Tipo) VALUES ('Frios')

INSERT INTO Cat_Produto(Tipo) VALUES ('Fruta')

INSERT INTO Cat_Produto(Tipo) VALUES ('Verdura')

INSERT INTO Cat_Produto(Tipo) VALUES ('Legumes')

<<<<<<< HEAD
INSERT INTO Produto (NomeProduto, Descricao_do_Produto, Id_Cat_Produto) VALUES ('Feijão', 'Feijão de 1kg - Camilo', 1 )
=======
INSERT INTO Produto (NomeProduto, Quantidade, Preco, Descricao_do_Produto, Validade, Id_Cat_Produto) VALUES ('Feijão', 20, 10.00, 'Feijão de 1kg', 22/12/22, 1 )
>>>>>>> 6900c30e5a12c9378e77dc2455ca5a2a6777b608

INSERT INTO Receita(Nome) VALUES ('Limão')

INSERT INTO Receita(Nome) VALUES ('Casca De Laranja')

INSERT INTO Produto_Receita(Id_Produto, Id_Receita) VALUES (1, 2)

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, Email, Senha, Celular_Telefone, CPF_CNPJ,Foto_Url_Usuario) VALUES (1, 1, 'Consumidor Do Chiquinho', 'Consumidor@Live.com', '******', '(11)9777-6666', '12345678912345', 'foto')

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, Email, Senha, Celular_Telefone, CPF_CNPJ,Foto_Url_Usuario) VALUES (1, 2, 'Fornecedor Do Chiquinho', 'Fornecedor@Live.com', '******', '(11)9777-6666', '12345678912345', 'foto')

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, Email, Senha, Celular_Telefone, CPF_CNPJ,Foto_Url_Usuario) VALUES (1, 3, 'Adm Do Chiquinho', 'Adm@Live.com', '******', '(11)9777-6666', '12345678912345', 'foto')

INSERT INTO Pedido(Id_Produto, Id_Usuario, Quantidade) VALUES (1, 1, 20)

INSERT INTO Oferta(Quantidade, Preco, Validade, Id_Produto, Id_Usuario,  Foto_Url_Oferta ) VALUES (5, 10.00, 22/11/2022, 1, 2, 'Url_Imagens_Texto')

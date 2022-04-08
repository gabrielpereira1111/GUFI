USE Gufi

INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES				   ('Admin'),
					   ('Comum')

INSERT INTO usuario(nomeUsuario, email, senha, idTipoUsuario)
VALUES			   ('Gabriel', 'gabriel@email.com', 'gabriel123', 1),
				   ('Comum', 'comum@email.com', 'comum123', 2)

INSERT INTO tipoEvento(tituloTipoEvento)
VALUES				  ('C#'),
					  ('ReactJS'),
					  ('SQL')

INSERT INTO instituicao(cnpj, nomeFantasia, endereco)
VALUES				   ('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539')

INSERT INTO evento(idTipoEvento, idInstituicao, nomeEvento, descricao, dataEvento, acessoLivre)
VALUES			  (1, 1, 'Orientação a Objetos', 'Conceitos sobre os pilares da programação orientada a objetos', '10/04/2022', 1),
				  (2, 1, 'Ciclo de Vida', 'Como utilizar os ciclos de vida com a biblioteca ReactJs', '20/04/2022', 0)

INSERT INTO situacao(descricao)
VALUES				('Aprovada'),
					('Recusada'),
					('Aguardando')

INSERT INTO presenca(idUsuario, idEvento, idSituacao)
VALUES				(1, 2, 3),
					(2, 3, 1)
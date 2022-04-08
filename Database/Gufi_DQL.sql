USE Gufi

SELECT * FROM tipoUsuario
SELECT * FROM usuario
SELECT * FROM tipoEvento
SELECT * FROM instituicao
SELECT * FROM evento
SELECT * FROM presenca
SELECT * FROM situacao

SELECT U.nomeUsuario as 'Usuário', TU.tituloTipoUsuario as 'Tipo de Usuário' FROM usuario AS U
INNER JOIN tipoUsuario AS TU
ON U.idTipoUsuario = TU.idTipoUsuario

SELECT E.nomeEvento as 'Evento', TE.tituloTipoEvento as 'Tipo Evento', I.nomeFantasia as 'Instituição' FROM evento AS E
INNER JOIN tipoEvento AS TE
ON E.idEvento = TE.idTipoEvento
INNER JOIN instituicao AS I
ON E.idInstituicao = I.idInstituicao

SELECT E.nomeEvento, S.descricao FROM presenca AS P
INNER JOIN evento AS E
ON P.idEvento = E.idEvento
INNER JOIN situacao AS S
ON P.idSituacao = S.idSituacao
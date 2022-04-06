Create Database PruebaEncuesta;
GO
USE PruebaEncuesta

CREATE TABLE Encuesta
(
EncuestaId BIGINT IDENTITY Primary Key,
EncuestaNombre VARCHAR(100),
EncuestaDescripcion VARCHAR(100)
)


CREATE TABLE CamposEncuesta
(
CampoEncuestaId BIGINT IDENTITY Primary Key,
NombreCampo VARCHAR(100),
TituloCampo VARCHAR(100),
EsRequerido BIT,
TipoCampo VARCHAR(100),
fk_EncuestaId BIGINT NOT NULL,
foreign key (fk_EncuestaId) REFERENCES Encuesta(EncuestaId)
)


CREATE TABLE Respuesta
(
   RespuestaId BIGINT IDENTITY Primary Key,
   NombrePersona VARCHAR(100),
   FechaRespuesta DateTime NOT NULL,
   fk_EncuestaId BIGINT NOT NULL
)

CREATE TABLE RespuestaxCampo
(
   IdRespuestaxCampo BIGINT IDENTITY Primary Key,
   fk_RespuestaId BIGINT,
   fk_CampoEncuestaId BIGINT,
   Respuesta VARCHAR(MAX),
   foreign key (fk_RespuestaId) REFERENCES Respuesta(RespuestaId)
)
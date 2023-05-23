Create database Clientes

-- Crear la tabla Categoria
CREATE TABLE Categoria (
  Id INT PRIMARY KEY,
  Nombre VARCHAR(50)
);

-- Crear la tabla Cliente
CREATE TABLE Cliente (
  Id INT PRIMARY KEY,
  Nombre VARCHAR(50),
  Apellido VARCHAR(50),
  Telefono VARCHAR(20),
  CorreoElectronico VARCHAR(100),
   Cedula VARCHAR(11),
  Empresa VARCHAR(100),
  CategoriaId INT,
  FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
);

-- Crear la tabla Direccion
CREATE TABLE Direccion (
  Id INT PRIMARY KEY,
  Calle VARCHAR(100),
  Ciudad VARCHAR(50),
  CodigoPostal VARCHAR(10),
  Pais VARCHAR(50),
  ClienteId INT,
  FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);


SELECT c.Id AS ClienteId, c.Nombre, c.Apellido, c.Telefono, c.CorreoElectronico,
       d.Id AS DireccionId, d.Calle, d.Ciudad, d.CodigoPostal, d.Pais,
       cat.Id AS CategoriaId, cat.Nombre AS CategoriaNombre
FROM Cliente c
JOIN Direccion d ON c.Id = d.ClienteId
JOIN Categoria cat ON c.CategoriaId = cat.Id;


-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Id, Nombre)
VALUES (1, 'Categoría 1');

-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Id, Nombre, Apellido, Telefono, CorreoElectronico, Cedula, Empresa, CategoriaId)
VALUES (1, 'Juan', 'Pérez', '1234567890', 'juan@example.com', '12345678901', 'Empresa 1', 1);

-- Insertar datos en la tabla Direccion
INSERT INTO Direccion (Id, Calle, Ciudad, CodigoPostal, Pais, ClienteId)
VALUES (1, 'Calle 123', 'Ciudad 1', '12345', 'País 1', 1);


-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Id, Nombre)
VALUES (2, 'Categoría 1');

-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Id, Nombre, Apellido, Telefono, CorreoElectronico, Cedula, Empresa, CategoriaId)
VALUES (2, 'MIGUEL', 'Pérez', '1234567890', 'juan@example.com', '12345678901', 'Empresa 2', 2);

-- Insertar datos en la tabla Direccion
INSERT INTO Direccion (Id, Calle, Ciudad, CodigoPostal, Pais, ClienteId)
VALUES (2, 'Calle NACIONAL SANTO DOMINGO', 'SANTO DOMINGO 1', '12345', 'País 1', 1);


-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Id, Nombre)
VALUES (3, 'Categoría 2');

-- Insertar datos en la tabla Cliente
INSERT INTO Cliente (Id, Nombre, Apellido, Telefono, CorreoElectronico, Cedula, Empresa, CategoriaId)
VALUES (3, 'María', 'Gómez', '9876543210', 'maria@example.com', '98765432109', 'Empresa 2', 2);

-- Insertar datos en la tabla Direccion
INSERT INTO Direccion (Id, Calle, Ciudad, CodigoPostal, Pais, ClienteId)
VALUES (3, 'Calle 456', 'Ciudad 2', '54321', 'País 2', 2);





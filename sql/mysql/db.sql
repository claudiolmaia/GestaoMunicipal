CREATE DATABASE IF NOT EXISTS PPGM;

USE PPGM;

SET character_set_client = utf8;
SET character_set_connection = utf8;
SET character_set_results = utf8;
SET collation_connection = utf8_general_ci;

CREATE TABLE consulta (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    cpf VARCHAR(11) NOT NULL,
    medico varchar(100),
    unidade varchar(100),
    consultorio INT,
    data_consulta DATETIME NOT NULL
);

CREATE TABLE iptu (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    cpf VARCHAR(11) NOT NULL,
    logradouro VARCHAR(255),
    numero VARCHAR(10),
    bairro VARCHAR(255),
    cidade VARCHAR(255),
    uf CHAR(2),
    cep VARCHAR(9),
    exercicio CHAR(4),
    valor DECIMAL(10,2),
    is_pago BOOLEAN NOT NULL DEFAULT 0,
    data_vencimento DATETIME NOT NULL    
);

INSERT INTO iptu 
    (cpf,logradouro,numero,bairro, cidade, uf, cep, exercicio, valor,is_pago, data_vencimento)
VALUES 
    ('00489949100', 'Rua Pedro Aguia', 20, 'Centro', 'Bom Sucesso','MG', '37220000', '2021', 650, 0, '2021-02-10'),
    ('88701482033', 'Rua Santos Dumont', 20, 'Centro','Bom Sucesso', 'MG', '37220000', '2021', 450, 0, '2021-02-10'),
    ('03248638028', 'Rua Omar Soares', 20, 'Centro','Bom Sucesso', 'MG', '37220000', '2021', 650, 0, '2021-02-10'),
    ('00489949100', 'Rua José Mourão', 20, 'Centro','Bom Sucesso', 'MG', '37220000', '2021', 550, 0, '2021-02-10'),
    ('59050257038', 'Rua Oito de Setembro', 20,'Bom Sucesso', 'Centro', 'MG', '37220000', '2021', 650, 0, '2021-02-10'),
    ('22019399008', 'Rua João Tomé', 20, 'Centro','Bom Sucesso', 'MG', '37220000', '2021', 450, 0, '2021-02-10');


INSERT INTO consulta
    (cpf, medico, unidade, consultorio, data_consulta)
VALUES
    ('00489949100', 'Dr. Fulano', 'PSF Unidade Centro', 23, '2021-03-15 09:00:00'),
    ('00489949100', 'Dra. Beltrana', 'PSF Faquines', 32, '2021-04-30 09:00:00'),
    ('88701482033', 'Dr. Jhon Doe', 'PSF Unidade Centro', 15, '2021-03-15 09:00:00'),
    ('22019399008', 'Dr. Fulano', 'PSF Chácara da Rosas', 3, '2021-03-15 09:00:00'),
    ('59050257038', 'Dra. Maria', 'PSF Unidade Centro', 10, '2021-03-15 09:00:00');
    


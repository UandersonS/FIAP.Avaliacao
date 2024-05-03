CREATE TABLE turma (
    id INT PRIMARY KEY IDENTITY,
    curso_id INT,
    turma VARCHAR(45),
    ano INT,
    data_cadastro DATE
);
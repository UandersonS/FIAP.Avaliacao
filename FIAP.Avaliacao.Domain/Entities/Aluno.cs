﻿namespace FIAP.Avaliacao.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Usuario { get; set;}  
        public string Senha { get; set; }
    }
}

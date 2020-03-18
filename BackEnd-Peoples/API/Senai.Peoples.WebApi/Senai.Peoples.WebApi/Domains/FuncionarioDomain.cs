using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Classe que representa a tabela funcionarios
/// </summary>
namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario {get;set;}

        public string Nome {get;set;}

        public string Sobrenome { get; set; }
    }
}

//1º DOMAIN;
//2º REPOSITORY Lista o metodo;
//3º INTERFACE fala oque o metodo vai fazer;
//4º CONTROLLER responsável pelos endpoints referentes aos generos;
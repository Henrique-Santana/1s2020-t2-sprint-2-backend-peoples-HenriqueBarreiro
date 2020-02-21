using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId(int id);

        void Cadastrar(FuncionarioDomain funcionario);

        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        void Deletar(int id);

    }
}

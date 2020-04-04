using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    interface IGeneralRepository<T>
    {
        IEnumerable<T> Listar();
        T BuscarPorId(int id);
        void Cadastrar(T novoItem);
        void Atualizar(T itemAtualizado);
        void Deletar(T itemSelecionado);
    }
}

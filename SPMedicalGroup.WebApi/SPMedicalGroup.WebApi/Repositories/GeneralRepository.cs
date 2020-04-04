using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class GeneralRepository<TEntity> : RepositoryBase, IGeneralRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Listar()
        {
            return dbo.Set<TEntity>();
        }

        public TEntity BuscarPorId(int id)
        {
            Type tipoItem = typeof(TEntity);
            PropertyInfo idItem = tipoItem.GetProperty($"Id{tipoItem.Name}");
    
            return dbo.Set<TEntity>().First(x => idItem.GetValue(x).Equals(id));
        }

        public void Cadastrar(TEntity novoItem)
        {
            dbo.Set<TEntity>().Add(novoItem);
            dbo.SaveChanges();
        }

        public void Atualizar(TEntity itemAtualizado)
        {
            dbo.Set<TEntity>().Update(itemAtualizado);
            dbo.SaveChanges();
        }

        public void Deletar(TEntity itemSelecionado)
        {
            dbo.Set<TEntity>().Remove(itemSelecionado);
            dbo.SaveChanges();
        }
    }
}

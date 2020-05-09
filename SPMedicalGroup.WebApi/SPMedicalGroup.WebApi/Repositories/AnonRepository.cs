using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class AnonRepository<TEntity> : RepositoryBase, IAnonRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> ListAll()
        {
            return Dbo.Set<TEntity>();
        }

        public TEntity SearchById(int id)
        {
            var itemType = typeof(TEntity);
            var propertyId = itemType.GetProperty($"Id{itemType.Name}");
    
            return Dbo.Set<TEntity>().First(x => propertyId.GetValue(x).Equals(id));
        }

        public void SignUp(TEntity newItem)
        {
            Dbo.Set<TEntity>().Add(newItem);
            Dbo.SaveChanges();
        }

        public void Update(TEntity updatedItem)
        {
            Dbo.Set<TEntity>().Update(updatedItem);
            Dbo.SaveChanges();
        }

        public void Delete(TEntity selectedItem)
        {
            Dbo.Set<TEntity>().Remove(selectedItem);
            Dbo.SaveChanges();
        }
    }
}
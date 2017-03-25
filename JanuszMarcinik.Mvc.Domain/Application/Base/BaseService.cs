using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Base
{
    public abstract class BaseService<TModel> where TModel : class, IApplicationEntity, new()
    {
        #region GetById()
        public virtual TModel GetById(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<TModel>().Find(id);
            }
        }
        #endregion

        #region GetList
        public virtual List<TModel> GetList()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<TModel>().ToList();
            }
        }
        #endregion

        #region Create()
        public virtual TModel Create(TModel entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<TModel>().Add(entity);
                context.SaveChanges();
                return entity;
            }
        }
        #endregion

        #region Update()
        public virtual void Update(TModel entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete()
        public virtual void Delete(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Set<TModel>().Find(id);
                context.Set<TModel>().Remove(entity);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dino;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IObjectContextProvider ContextProvider;

        protected RepositoryBase(IObjectContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        protected IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return ContextProvider.GetContext<LunchContext>().Query<T>().Where(predicate);
        }


        protected IQueryable<T> FindAll<T>() where T : class
        {
            return ContextProvider.GetContext<LunchContext>().Query<T>();
        }

        protected T FindSingleOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return ContextProvider.GetContext<LunchContext>().Query<T>().Where(predicate).SingleOrDefault();
        }

        protected void DeleteMultiFromContext<T>(IEnumerable<T> collection) where T : class
        {
            foreach (var item in collection.ToList())
            {
                ContextProvider.GetContext<LunchContext>().Delete(item);
            }
        }
    }
}

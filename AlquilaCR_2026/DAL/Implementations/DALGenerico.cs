using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenerico<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {
        private AlquilaCrContext _alquilaCrContext;

        public DALGenerico(AlquilaCrContext alquilaCrContext)
        {
            _alquilaCrContext = alquilaCrContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _alquilaCrContext.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TEntity Get(int id)
        {
            return _alquilaCrContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _alquilaCrContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _alquilaCrContext.Set<TEntity>().Attach(entity);
                _alquilaCrContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _alquilaCrContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

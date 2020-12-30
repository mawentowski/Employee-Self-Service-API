using System;
using System.Collections.Generic;
using EmployeeSelfService.Models;
using EmployeeSelfService.Services.Exceptions;

namespace EmployeeSelfService.Services.Implementations
{
    public abstract class EntityService<T> where T: Entity
    {
        private static int IdCounter = 0;
        protected readonly List<T> entities;

        public EntityService()
        {
            entities = new List<T>();
        }

        public T AddEntity(T entity)
        {
            entity.Id = ++IdCounter;
            entity.CreateDate = DateTime.Now;
            entities.Add(entity);
            return entity;
        }

        public void DeleteEntity(int id)
        {
            T entity = GetById(id);
            entities.Remove(entity);
        }

        public IEnumerable<T> GetEntities()
        {
            return entities;
        }

        public T GetById(int id)
        {
            T entity = entities.Find(entity => entity.Id == id);
            if (entity == null)
            {
                throw new NotFoundException($"Entity with id {id} not found.");
            }
            return entity;
        }

        public void UpdateEntity(T updatedEntity)
        {
            T currentEntity = GetById(updatedEntity.Id);
            updatedEntity.CreateDate = currentEntity.CreateDate;
            updatedEntity.UpdateDate = DateTime.Now;
            entities[entities.IndexOf(currentEntity)] = updatedEntity;
        }
    }
}

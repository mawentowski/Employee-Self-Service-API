using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeSelfService.Models;
using EmployeeSelfService.Services.Contracts;

namespace EmployeeSelfService.Services.Implementations
{
    public abstract class EntityService
    {
        private static int IdCounter = 0;
        protected readonly List<Entity> entities;

        public EntityService()
        {
            entities = new List<Entity>();
        }

        public Entity AddEntity(Entity entity)
        {
            entity.Id = IdCounter++;
            entity.CreateDate = new DateTime();
            entities.Add(entity);
            return entity;
        }

        public void DeleteEntity(int id)
        {
            Entity entity = GetById(id);
            entities.Remove(entity);
        }

        public IEnumerable<Entity> GetEntities()
        {
            return entities;
        }

        public Entity GetById(int id)
        {
            Entity entity = entities.Find(entity => entity.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with id {id} not found.");
            }
            return entity;
        }

        public void UpdateEntity(Entity updatedEntity)
        {
            Entity currentEntity = GetById(updatedEntity.Id);
            updatedEntity.UpdateDate = new DateTime();
            entities[entities.IndexOf(currentEntity)] = updatedEntity;
        }
    }
}

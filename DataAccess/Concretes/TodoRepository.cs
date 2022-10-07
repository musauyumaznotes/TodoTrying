using DataAccess.Abstracts;
using DataAccess.Concretes.Contexts;
using Dtos.Concrete;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDBContext _todoDBContext;

        public TodoRepository(TodoDBContext todoDBContext)
        {
            _todoDBContext = todoDBContext;
        }

        public async Task<Todo> Delete(int id)
        {
            var any = await _todoDBContext.Todos.AnyAsync(x=>x.Id == id);

            if (any)
            {
                var entity = await _todoDBContext.Todos.FirstOrDefaultAsync(x=>x.Id == id);
                var deletedEntity = _todoDBContext.Todos.Remove(entity);
                await _todoDBContext.SaveChangesAsync();

                return deletedEntity.Entity;
            }
            return null;
            
        }

        public async Task<IList<Todo>> GetAll()
        {
            var count = await _todoDBContext.Todos.CountAsync();
            if (count > 0)
                return await _todoDBContext.Todos.ToListAsync();
            return null;
        }

        public async Task<Todo> GetById(int id)
        {
            var any = await _todoDBContext.Todos.AnyAsync(x=>x.Id == id);
            if (any)
                return await _todoDBContext.Todos.FirstOrDefaultAsync(x=>x.Id == id);
            return null;
        }

        public async Task<Todo> Insert(InsertTodoDto insertTodoDto)
        {
            var entity = new Todo
            {
                Title = insertTodoDto.Title,
                Content = insertTodoDto.Content,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var insertedEntity = await _todoDBContext.AddAsync(entity);
            await _todoDBContext.SaveChangesAsync();
            return insertedEntity.Entity;
        }


        public async Task<Todo> Update(UpdateTodoDto updateTodoDto)
        {
            var any = await _todoDBContext.Todos.AnyAsync(x => x.Id == updateTodoDto.Id);

            if (any)
            {
                var entity = await _todoDBContext.Todos.FirstOrDefaultAsync(x => x.Id == updateTodoDto.Id);

                entity.Title = updateTodoDto.Title;
                entity.Content = updateTodoDto.Content;
                entity.UpdatedDate = DateTime.Now;

                var updatedEntity = _todoDBContext.Todos.Update(entity);
                await _todoDBContext.SaveChangesAsync();

                return updatedEntity.Entity;
            }
            return null;
        }
    }
}

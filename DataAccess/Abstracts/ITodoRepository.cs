using Dtos.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ITodoRepository
    {
        Task<IList<Todo>> GetAll();
        Task<Todo> GetById(int id);
        Task<Todo> Insert(InsertTodoDto insertTodoDto);
        Task<Todo> Update(UpdateTodoDto updateTodoDto);
        Task<Todo> Delete(int id);
        
    }
}

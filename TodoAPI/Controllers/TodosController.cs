using DataAccess.Abstracts;
using Dtos.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _todoRepository.GetAll();
            if(result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _todoRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(InsertTodoDto insertTodoDto)
        {
            var result = await _todoRepository.Insert(insertTodoDto);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoDto updateTodoDto)
        {
            var result = await _todoRepository.Update(updateTodoDto);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoRepository.Delete(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Topla(int id)
        {
            return Ok();
        }
    }
}

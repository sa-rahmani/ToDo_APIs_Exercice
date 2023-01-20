using Microsoft.AspNetCore.Mvc;
using ToDoExercice.Models;
using ToDoExercice.repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIday1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoContext _db;


        public ToDoController(TodoContext db)
        {
            _db = db;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public ActionResult<List<ToDo>> GetAllToDos()
        {
            ToDoRepos toDoRepos = new ToDoRepos(_db);

            return Ok(toDoRepos.GetAllRecords());
        }



        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDo> GetToDo(int id)
        {
            ToDoRepos toDoRepos = new ToDoRepos(_db);
            ToDo toDo = toDoRepos.GetRecord(id);
            if (toDo == null)
            {
                return NotFound("Id " +id+" not found");

            }
            return Ok(toDo);

        }

        // POST api/<ToDoController>
        [HttpPost]
        public ActionResult<List<ToDo>> AddToDo(ToDo toDo)
        {
            ToDoRepos toDoRepos = new ToDoRepos(_db);
            if (toDo == null)
            {
                return BadRequest(toDo);
            }
            else
            {
                return Ok(toDoRepos.CreateRecord(toDo));
            }
        }


        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ActionResult<List<ToDo>> Put(int id, [FromBody] ToDo toDo)
        {
            ToDoRepos toDoRepos = new ToDoRepos(_db);
            ToDo newToDo = toDoRepos.UpdateRecord(id,toDo);
            if (newToDo == null)
            {
                return NotFound("Id " + id + " not found");

            }
            else {
                
                return Ok(toDoRepos.GetAllRecords());
            }
        }

        //// DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public ActionResult<List<ToDo>> DeleteTodo(int id)
        {
            ToDoRepos toDoRepos = new ToDoRepos(_db);
            ToDo toDo = toDoRepos.DeleteRecord(id);

            if (toDo == null)
            {
                return NotFound("Id " + id + " not found");

            }
            else
            {
                return Ok(toDoRepos.GetAllRecords());

            }
        }

    }
}
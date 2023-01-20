using ToDoExercice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;

namespace ToDoExercice.repositories
{
    public class ToDoRepos
    {
        private readonly TodoContext _db;


        public ToDoRepos(TodoContext db)
        {
            _db = db;
        }
        public List<ToDo> GetAllRecords()
        {
            var query = (from d in _db.ToDos
                         select d).ToList();

            return query;
        }
        public List<ToDo> CreateRecord(ToDo toDo)
        {

            _db.Add(toDo);
            _db.SaveChanges();
            List <ToDo> toDos= GetAllRecords();

            return toDos;

        }
        public ToDo GetRecord(int id)
        {
            var toDo = _db.ToDos.Where(p => p.Id == id).FirstOrDefault();
            
            return toDo;

        }
        public ToDo DeleteRecord(int id)
        {

            ToDo toDo = GetRecord(id);

            if (toDo != null)
            {
                _db.Remove(toDo);
                _db.SaveChanges();
            }

            return toDo;

        }
        public ToDo UpdateRecord(int id,ToDo toDo)
        {
            var item = GetRecord(id);
            if (item != null)
            {
                item.Priority = toDo.Priority;
                item.Description = toDo.Description;
                item.IsComplete = toDo.IsComplete;
                _db.SaveChanges();
            }
            return item;
        }
    }
}

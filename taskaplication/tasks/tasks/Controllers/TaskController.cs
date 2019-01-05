using System.Collections.Generic;
using System.Linq;
using data;
using Microsoft.AspNetCore.Mvc;

namespace tasks.Controllers
{
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private ITaskServices _taskServices;
        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        //GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<UserTask>> GetAll()
        {
            return _taskServices.GetAll().ToList();
        }

        //GET api/tasks/1
        [HttpGet("{id}")]
        public ActionResult<UserTask> GetById(int id)
        {
            var item =  _taskServices.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        //POST api/tasks
        [HttpPost]
        public ActionResult<UserTask> Add([FromBody] UserTask item)
        {
            return _taskServices.Add(item);
        }

        //PUT api/tasks/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UserTask item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            
            _taskServices.Update(item);

            return NoContent();
        }

        //DELETE: api/tasks/1
        [HttpDelete("{id}")]
        public ActionResult<UserTask> Delete(int id)
        {
            if (_taskServices.GetById(id) == null)
            {
                return NotFound();
            }
            
            return _taskServices.Delete(id);
        }
    }
}
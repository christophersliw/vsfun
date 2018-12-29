using System.Collections.Generic;
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

        [HttpGet]
        public IList<UserTask> GetAll()
        {
            return _taskServices.GetAll();
        }
    }
}
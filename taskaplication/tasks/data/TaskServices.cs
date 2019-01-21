using System;
using System.Collections.Generic;
using System.Linq;

namespace data
{
    public class TaskServices : ITaskServices
    {
        private static IList<UserTask> _fakeList = new List<UserTask>()
        {
            new UserTask()
            {
                title = "t1", 
                Description = "d1",
                Id = 1
            },
            new UserTask()
            {
                title = "t2", 
                Description = "d2",
                Id = 2
            },
            new UserTask()
            {
                title = "t3", 
                Description = "d3",
                Id = 3
            }
        };
        
        
        public IEnumerable<UserTask> GetAll()
        {
            return _fakeList;
        }

        public UserTask GetById(int id)
        {
            return _fakeList.FirstOrDefault(e => e.Id == id);
        }

        public void Update(UserTask element)
        {
            var elementToUpdate = _fakeList.FirstOrDefault(e => e.Id == element.Id);

            elementToUpdate.title = element.title;
            elementToUpdate.Description = element.Description;
        }

        public UserTask Add(UserTask element)
        {
            int newId = _fakeList.Max(e => e.Id) + 1;

            element.Id = newId;
            
            _fakeList.Add(element);
            
            return element;
        }

        public UserTask Delete(int id)
        {
            var elementToDelete = _fakeList.FirstOrDefault(e => e.Id == id);

            _fakeList.ToList().Remove(elementToDelete);

            return elementToDelete;
        }
    }
}
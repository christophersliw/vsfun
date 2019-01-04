using System;
using System.Collections.Generic;

namespace data
{
    public class TaskServices : ITaskServices
    {
        private static IList<UserTask> _fakeList = new List<UserTask>()
        {
            new UserTask()
            {
                Title = "t1", 
                Description = "d1",
                Id = 1
            },
            new UserTask()
            {
                Title = "t2", 
                Description = "d2",
                Id = 2
            },
            new UserTask()
            {
                Title = "t3", 
                Description = "d3",
                Id = 3
            }
        };
        
        
        public IList<UserTask> GetAll()
        {
            return _fakeList;
        }      
    }
}
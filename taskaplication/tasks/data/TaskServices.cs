using System;
using System.Collections.Generic;

namespace data
{
    public class TaskServices : ITaskServices
    {
        public IList<UserTask> GetAll()
        {
            return new List<UserTask>();
        }
        
    }
}
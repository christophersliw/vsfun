using System.Collections.Generic;

namespace data
{
    public interface ITaskServices
    {
        IList<UserTask> GetAll();
    }
}
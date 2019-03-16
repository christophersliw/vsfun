using System.Collections.Generic;

namespace data
{
    public interface ITaskServices
    {
        IEnumerable<UserTask> GetAll();
        UserTask GetById(int id);

        void Update(UserTask element);

        UserTask Add(UserTask element);

        UserTask Delete(int id);
    }
}
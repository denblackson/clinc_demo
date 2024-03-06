using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic_demo.Domain.Entity;
using clinic_demo.Domain.Responce;

namespace clinic_demo.BLL.Implementations
{
    public interface IAppointmentService
    {
        Task<IBaseResponce<UserEntity>> Create(CreateTaskViewModel model);
        Task<IBaseResponce<IEnumerable<TaskViewModel>>> GetTasks(TaskFilter filter);
        Task<IBaseResponce<bool>> EndTask(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Services
{
    public interface NotificationService
    {
        Task SendMenssage(string email, string menssage);
    }
}

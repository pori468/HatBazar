using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatBazar.Models;

namespace HatBazar.Interface
{
    interface ICarrier
    {
        List<Job_Application> Index();
        Job_Application Details(string id );
          string Create(JobApplication Mydata);
        Job_Application GetEdit(string id );
        string PostEdit(Job_Application job);
        Job_Application GetDelete(string job);
        string PostDelete(string id);
    }
}

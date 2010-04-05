using System.Collections.Generic;
using Mavis.Core;

namespace MyDemo.Core.DataInterfaces
{
    public interface IEmployeeRepository: INHibernateRepository<Employee>
    {
    }
}
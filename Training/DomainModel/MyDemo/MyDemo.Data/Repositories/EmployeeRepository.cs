using System;
using System.Collections.Generic;
using Mavis.DataAccess;
using MyDemo.Core;
using MyDemo.Core.DataInterfaces;

namespace MyDemo.Data.Repositories
{
    public class EmployeeRepository : NHibernateRepository<Employee>, IEmployeeRepository
    {
        
    }
}
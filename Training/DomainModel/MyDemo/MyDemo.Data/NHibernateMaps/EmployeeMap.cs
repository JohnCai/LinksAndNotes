using FluentNHibernate.Mapping;
using MyDemo.Core;

namespace MyDemo.Data.NHibernateMaps
{
    public class EmployeeMap: ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(e => e.ID);
            Map(e => e.Name).CustomSqlType("varchar(50)");
            Map(e => e.EmployeeCode).CustomSqlType("varchar(50)");
            Map(e => e.EmployeeType).CustomType(typeof (EmployeeType));
            References(e => e.PaySystem);
        }
    }
}
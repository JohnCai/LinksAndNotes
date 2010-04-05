using FluentNHibernate.Mapping;
using MyDemo.Core;

namespace MyDemo.Data.NHibernateMaps
{
    public class PaySystemMap: ClassMap<PaySystem>
    {
        public PaySystemMap()
        {
            Id(p => p.ID);
            Map(p => p.PaySystemCode).CustomSqlType("varchar(50)");
            Map(p => p.Name).CustomSqlType("varchar(50)");
        }
    }
}
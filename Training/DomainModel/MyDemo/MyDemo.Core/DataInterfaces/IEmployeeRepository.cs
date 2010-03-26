namespace MyDemo.Core.DataInterfaces
{
    public interface IEmployeeRepository
    {

        object SaveOrUpdate(Employee employee);
    }
}
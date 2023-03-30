using Nptk.Learning.Entities;
using Nptk.Learning.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nptk.Learning.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);

        void DeleteEmployee(Employee employee);

        public Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);



    }
}

using Microsoft.EntityFrameworkCore;
using Nptk.Learning.Contracts;
using Nptk.Learning.Entities;
using Nptk.Learning.Repository.Extensions;
using Nptk.Learning.Shared.RequestFeatures;

namespace Nptk.Learning.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
        FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),
        trackChanges)
        .SingleOrDefault();


        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
        FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        .OrderBy(e => e.Name).ToList();

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId) , trackChanges)
                                           .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
                                           .Search(employeeParameters.SearchTerm)
                                           .Sort(employeeParameters.OrderBy)
                                           .OrderBy(e => e.Name)
                                           .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                                           .Take(employeeParameters.PageSize)
                                           .ToListAsync();
            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

            return new PagedList<Employee>(employees, count,employeeParameters.PageNumber, employeeParameters.PageSize);
        }

    }
}

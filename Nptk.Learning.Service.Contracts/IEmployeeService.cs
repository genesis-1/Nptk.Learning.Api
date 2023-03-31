﻿using Nptk.Learning.Entities;
using Nptk.Learning.Shared.DataTransferObjects;
using Nptk.Learning.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nptk.Learning.Service.Contracts
{
    public interface IEmployeeService
    {
       
        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto
        employeeForCreation, bool trackChanges);
        void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);

        void UpdateEmployeeForCompany(Guid companyId, Guid id,
        EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool
        empTrackChanges);

        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(
Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee
        employeeEntity);

        Task<(IEnumerable<Entity> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId,
EmployeeParameters employeeParameters, bool trackChanges);


    }
}

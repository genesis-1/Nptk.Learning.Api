using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nptk.Learning.Shared.DataTransferObjects
{
    public record CompanyForCreationDto(string Name, string Address, string Country,
 IEnumerable<EmployeeForCreationDto> Employees);


}

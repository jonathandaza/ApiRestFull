using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.DTO;
using Domain;

namespace app
{
	public interface IApp
	{
		Employee Add(EmployeeDTO employeeDto);
	}
}

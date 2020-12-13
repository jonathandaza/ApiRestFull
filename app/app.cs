using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.DTO;
using AutoMapper;
using Domain;

namespace app
{
    public class App : IApp
    {
	    public Employee Add(EmployeeDTO employeeDto)
	    {

		    Mapper.CreateMap<EmployeeDTO, Employee>().AfterMap((scr, dest) => dest.Id = 10);
		    var employe = Mapper.Map<Employee>(employeeDto);

		    return employe;
	    }
    }
}

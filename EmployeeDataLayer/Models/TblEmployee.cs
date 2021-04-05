using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDataLayer.Models
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual TblDepartment Department { get; set; }
    }
}

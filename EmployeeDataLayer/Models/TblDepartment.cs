using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDataLayer.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<TblEmployee> TblEmployees { get; set; }
    }
}

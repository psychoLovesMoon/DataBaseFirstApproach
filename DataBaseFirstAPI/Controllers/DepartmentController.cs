using EmployeeDataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly PracticeContext _practiceContext;

        public DepartmentController(PracticeContext practiceContext)
        {
            _practiceContext = practiceContext;
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {            
            return Ok(await _practiceContext.TblDepartments.ToListAsync());
        }

        
        [HttpGet("GetDepartment/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _practiceContext.TblDepartments.FindAsync(id);

            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        
        [HttpPost("PostDepartment")]
        public async Task<IActionResult> AddDepartment(TblDepartment department)
        {
            await _practiceContext.TblDepartments.AddAsync(department);
            await _practiceContext.SaveChangesAsync();

            return Ok(department);
        }


        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, TblDepartment department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _practiceContext.Entry(department).State = EntityState.Modified;
            await _practiceContext.SaveChangesAsync();
            return Ok();
        }

        
        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _practiceContext.TblDepartments.FindAsync(id);
            if (id != department.Id)
            {
                return BadRequest();
            }
            _practiceContext.TblDepartments.Remove(department);
            await _practiceContext.SaveChangesAsync();

            return Ok();
        }
    }
}

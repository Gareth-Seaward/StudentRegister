using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRegisterApi.Models;
using StudentRegisterApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentSevice _studentService;

        public StudentsController(ILogger<StudentsController> logger, StudentSevice studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            await _studentService.CreateAsync(student);
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(string id, Student updatedStudent)
        {
            var queriedStudent = await _studentService.GetByIdAsync(id);
            if (queriedStudent == null)
            {
                return NotFound();
            }
            await _studentService.UpdateAsync(id, updatedStudent);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return NoContent();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Interfaces;
using Core.StudentModule.Models;
using Core.StudentModule.Services;
using Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentService;
        private readonly IRepository<Student> _repository;

        public StudentController(IStudentRepository studentService, IRepository<Student> repository)
        {
            _studentService = studentService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {            
            var res = await _repository.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _repository.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Student obj)
        {
            _repository.Insert(obj);
            await _repository.Save();
            return Ok(obj);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student obj)
        {
            _repository.Update(obj);
            await _repository.Save();
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Delete(id);
            await _repository.Save();
            return Ok();
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<Student> students)
        {
            var ret = await _studentService.upload(students);
            return Ok(ret);
        }
    }
}

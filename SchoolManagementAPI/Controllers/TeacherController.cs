using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Interfaces;
using Core.StudentModule.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {        
        private readonly IRepository<Teacher> _repository;

        public TeacherController(IRepository<Teacher> repository)
        {            
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
        public async Task<IActionResult> Insert(Teacher obj)
        {
            _repository.Insert(obj);
            await _repository.Save();
            return Ok(obj);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Teacher obj)
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
    }
}

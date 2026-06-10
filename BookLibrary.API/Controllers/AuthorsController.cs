using BookLibrary.Application.DTOs;
using BookLibrary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _service.GetByIdAsync(id);
            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAuthorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

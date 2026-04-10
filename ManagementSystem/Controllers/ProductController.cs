using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Application;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        => Ok(await _service.GetAll(page, pageSize));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
        => Ok(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto dto)
    {
        await _service.Create(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ProductDto dto)
    {
        await _service.Update(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return Ok();
    }
}
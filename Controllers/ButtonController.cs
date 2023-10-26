using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ButtonController : ControllerBase
{
    private readonly IButtonService _buttonService;

    public ButtonController(IButtonService buttonService)
    {
        _buttonService = buttonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var buttons = await _buttonService.GetAllButtonsAsync();
        return Ok(buttons);
    }

    [HttpPost]
    public async Task<IActionResult> CreateButton()
    {
        var button = await _buttonService.CreateButtonAsync();
        return Ok(button);
    }

    [HttpPut("{buttonId}")]
    public async Task<IActionResult> IncrementCount(int buttonId)
    {
        var result = await _buttonService.IncrementButtonCountAsync(buttonId);
        if (result)
            return Ok();
        else
            return NotFound();
    }

    [HttpDelete("{buttonId}")]
    public async Task<IActionResult> DeleteButton(int buttonId)
    {
        var result = await _buttonService.DeleteButtonAsync(buttonId);
        if (result)
            return Ok();
        else
            return NotFound();
    }
}

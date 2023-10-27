using challenge_total.Data.Entities;
using challenge_total.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        try
        {
            var buttons = await _buttonService.GetAllButtonsAsync();
            if (buttons == null || !buttons.Any())
                return NotFound(new ApiResponse(404, null, new string[] { "No se encontraron botones." }, null));

            return Ok(new ApiResponse(200, "Botones obtenidos con éxito", null, buttons));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse(500, null, new string[] { "Ocurrió un error al obtener los botones.", ex.Message }, null));
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateButton()
    {
        try
        {
            var button = await _buttonService.CreateButtonAsync();
            return Ok(new ApiResponse(200, "Boton creado con éxito", null, button));
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, new ApiResponse(500, null, new string[] { "Ocurrió un error relacionado con la base de datos al crear el botón.", dbEx.Message }, null));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse(500, null, new string[] { "Ocurrió un error inesperado al crear el botón.", ex.Message }, null));
        }
    }

    [HttpPut("{buttonId}")]
    public async Task<IActionResult> IncrementCount(int buttonId)
    {
        var result = await _buttonService.IncrementButtonCountAsync(buttonId);
        if (result)
            return Ok(new ApiResponse(200, "Click incrementado con éxito", null, null));
        else
            return NotFound(new ApiResponse(404, null, new string[] { $"No se encontró el botón con ID {buttonId}." }, null));
    }

    [HttpDelete("{buttonId}")]
    public async Task<IActionResult> DeleteButton(int buttonId)
    {
        var result = await _buttonService.DeleteButtonAsync(buttonId);
        if (result)
            return Ok(new ApiResponse(200, "Boton eliminado con éxito", null, null));
        else
            return NotFound(new ApiResponse(404, null, new string[] { $"No se encontró el botón con ID {buttonId} para eliminar." }, null));
    }
}

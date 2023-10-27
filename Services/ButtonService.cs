using challenge_total.Data;
using challenge_total.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IButtonService
{
    Task<IEnumerable<Button>> GetAllButtonsAsync();
    Task<Button> CreateButtonAsync();
    Task<bool> IncrementButtonCountAsync(int buttonId);
    Task<bool> DeleteButtonAsync(int buttonId);
}

public class ButtonService : IButtonService
{
    private readonly AppDbContext _context;

    public ButtonService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Button>> GetAllButtonsAsync()
    {
        return await _context.Buttons.ToListAsync();
    }

    public async Task<Button> CreateButtonAsync()
    {
        var button = new Button();
        _context.Buttons.Add(button);
        await _context.SaveChangesAsync();
        return button;
    }

    public async Task<bool> IncrementButtonCountAsync(int buttonId)
    {
        var button = await _context.Buttons.FindAsync(buttonId);
        if (button == null)
            return false;

        button.ClickCount++;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteButtonAsync(int buttonId)
    {
        var button = await _context.Buttons.FindAsync(buttonId);
        if (button == null)
            return false;

        _context.Buttons.Remove(button);
        await _context.SaveChangesAsync();
        return true;
    }

}

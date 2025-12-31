namespace Blazor.Client.Services;

using Microsoft.JSInterop;

public class ThemeService
{
    private readonly IJSRuntime _js;
    private string _currentTheme = "light"; 
    public event Action? OnChange;

    public ThemeService(IJSRuntime js)
    {
        _js = js;
    }

    public string CurrentTheme => _currentTheme;
    public bool IsDarkMode => _currentTheme == "dark";

    public async Task InitializeAsync()
    {
        _currentTheme = await _js.InvokeAsync<string>("themeManager.getTheme");
        await _js.InvokeVoidAsync("themeManager.setTheme", _currentTheme);
        NotifyStateChanged();
    }

    public async Task ToggleTheme()
    {
        _currentTheme = _currentTheme == "light" ? "dark" : "light";

        await _js.InvokeVoidAsync("themeManager.setTheme", _currentTheme);

        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}

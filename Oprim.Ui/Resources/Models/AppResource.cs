using Microsoft.Extensions.Localization;

namespace Oprim.Ui.Resources.Models;

public class AppResource
{
    private readonly IStringLocalizer<AppResource> _localizer;

    public AppResource(IStringLocalizer<AppResource> localizer)
    {
        _localizer = localizer;
    }

    public string Hello => _localizer["Hello"];
    public string Welcome => _localizer["Welcome"];
    public string Wel1come => _localizer["Welcome"];
}
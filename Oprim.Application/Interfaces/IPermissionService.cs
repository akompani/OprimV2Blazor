namespace Oprim.Application.Interfaces;

public interface IPermissionService
{
    Task<bool> HasPermissionForPage(string path);
}
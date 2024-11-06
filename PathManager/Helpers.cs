using System.Runtime.Versioning;
using System.Security.Principal;

namespace PathManager
{
    internal static class Helpers
    {
        [SupportedOSPlatform("windows")]
        public static bool IsAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

using TaskManagementAPI.Debugging;

namespace TaskManagementAPI;

public class TaskManagementAPIConsts
{
    public const string LocalizationSourceName = "TaskManagementAPI";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b29627acee81407f83d6911e4ef04b11";
}

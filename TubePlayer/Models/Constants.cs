using LocalAuthentication;

namespace TubePlayer.Models;

public class Constants
{
    public static string ApplicationName = "";
    public static string EmailAddress = @"tubeplayer@letoinc.kg";
    public static string ApplicationId = "LetoInc.TubePlayer.App";
    public static string ApiServiceURL = @"https://youtube.googleapis.com/youtube/v3/";
    public static string ApiKey = @"AIzaSyAjU634VZNzGhDlD4YX6mNn3jL5OtycHTs";

    public static uint MicroDuration { get; set; } = 100;
    public static uint SmallDuration { get; set; } = 300;
    public static uint MediumDuration { get; set; } = 600;
    public static uint LongDuration { get; set; } = 1200;
    public static uint ExtraLongDuration { get; set; } = 1800;
}

namespace TubePlayer.Services;

public class YoutubeService : RestServiceBase, IApiService
{
    public YoutubeService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {

    }
}

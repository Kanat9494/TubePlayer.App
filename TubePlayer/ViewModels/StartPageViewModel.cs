using Maui.Apps.Framework.Extensions;

namespace TubePlayer.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
{
    private string nextToken = string.Empty;
    private string searchTerm = "iPhone 14";
    [ObservableProperty]
    ObservableCollection<YoutubeVideo> youtubeVideos;
    public StartPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Tube Player";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        Search();
    }

    private async void Search()
    {
        SetDataLoadingIndicators(true);

        LoadingText = "Подождите, идет загрузка...";

        YoutubeVideos = new();

        try
        {
            await GetYoutubeVideo();
            this.DataLoaded = true;
        }
        catch (InternetConnectionException iex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Медленное интернет-соединение." + Environment.NewLine + "Пожалуйста проверьте включен ли интернет на вашем телефоне. После этого попробуйте еще раз.";
            ErrorImage = "nointernet.png";
        }
        catch (Exception ex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"Что-то пошло не так. Если проблема не решена, то пожалуйста свяжитесь с нами по почте: {Constants.EmailAddress} по поводу ошибки подключения: " + Environment.NewLine + ex.Message;
            ErrorImage = "error.png";
        }
        finally
        {
            SetDataLoadingIndicators(false);
        }
    }

    private async Task GetYoutubeVideo()
    {
        var videoSearchResult = await _appApiSerive.SearchVideos(searchTerm, nextToken);
        nextToken = videoSearchResult.NextPageToken;

        YoutubeVideos.AddRange(videoSearchResult.Items);
    }

    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Настройки", "Имплементация настроек не предусмотрена в этом проекте", "Ок");
    }
}

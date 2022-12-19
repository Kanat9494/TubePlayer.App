namespace TubePlayer.ViewModels;

public class StartPageViewModel : AppViewModelBase
{
    public StartPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Tube Player";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        SetDataLoadingIndicators(true);

        LoadingText = "Подождите, идет загрузка...";

        try
        {
            await Task.Delay(3000);
        }
        catch (Exception ex) 
        {
            
        }
        finally
        {
            SetDataLoadingIndicators(false);
        }
    }
}

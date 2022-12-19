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
            await Task.Delay(5000);
            throw new InternetConnectionException();

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
}

namespace TubePlayer.ViewModels.Base;

public partial class AppViewModelBase : ViewModelBase
{
    public INavigation NavigationService { get; set; }
    public Page PageSerive { get; set; }    

    protected IApiService _appApiSerive { get; set; }

    public AppViewModelBase(IApiService appApiSerive) : base()
    {
        this._appApiSerive = appApiSerive;
    }

    [RelayCommand]
    private async Task NavigateBack() =>
        await NavigationService.PopAsync();

    [RelayCommand]
    private async Task CloseModal() =>
        await NavigationService.PopModalAsync();
}

namespace TubePlayer.Views.Base;

public class ViewBase<TViewModel> : PageBase where TViewModel : AppViewModelBase
{
    protected bool _isLoaded = false;
    protected TViewModel ViewModel { get; set; }
    protected object ViewModelParameters { get; set; }

    protected event EventHandler ViewModelInitialized;

    public ViewBase() : base()
    {

    }

    public ViewBase(object initParameters) : base() =>
        ViewModelParameters = initParameters;

    protected override void OnAppearing()
    {
        if (!_isLoaded)
        {
            base.OnAppearing();

            BindingContext = ViewModel = ServiceHelper.GetService<TViewModel>();

            ViewModel.NavigationService = this.Navigation;
            ViewModel.PageService = this;

            ViewModelInitialized?.Invoke(this, new EventArgs());

            ViewModel.OnNavigatedTo(ViewModelParameters);

            _isLoaded = true;
        }
    }
}

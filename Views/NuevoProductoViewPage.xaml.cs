using MVVMProy.ViewModels;

namespace MVVMProy.Views;

public partial class NuevoProductoViewPage : ContentPage
{
	public NuevoProductoViewPage()
	{
		InitializeComponent();
		BindingContext = new NuevoProductoViewModel();
	}
}
using MVVMProy.Models;
using MVVMProy.ViewModels;

namespace MVVMProy.Views;

public partial class ProductoPage : ContentPage
{
	
	public ProductoPage()
	{
		InitializeComponent();
		BindingContext = new ProductoViewModel();
	}
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {


        ProductoDto productoDto = e.SelectedItem as ProductoDto;
        Producto producto = new()
        {
            IdProducto = productoDto.IdProducto,
            Nombre = productoDto.Nombre,
            Descripcion = productoDto.Descripcion,
            Cantidad = productoDto.Cantidad,
        };
        await App.Current.MainPage.Navigation.PushAsync(new DetalleProducto()
        {

            BindingContext = new DetalleProductoViewModel(producto),
        });
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMProy.Models;
using MVVMProy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProy.ViewModels
{
    public partial class DetalleProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        public int idProducto;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string descripcion;
        [ObservableProperty]
        public int cantidad;
        public DetalleProductoViewModel(Producto producto)
        {
            nombre = producto.Nombre;
            idProducto = producto.IdProducto;
            descripcion = producto.Descripcion;
            cantidad = producto.Cantidad;

        }
        [RelayCommand]
        public async Task EliminarProducto()
        {
            App.productoRepository.Delete(IdProducto);
            MessagingCenter.Send(this, "ProductoEliminado");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task EditarProducto()
        {
            Producto producto = new()
            {
                IdProducto = IdProducto,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Cantidad = Cantidad,

            };
            await App.Current.MainPage.Navigation.PopAsync();
            await App.Current.MainPage.Navigation.PushAsync(new EditarProductoViewPage()
            {
                BindingContext = new EditarProductoViewModel(producto)
            });
            
        }
    }
}

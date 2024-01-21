using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMProy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProy.ViewModels
{
    public partial class EditarProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        public int idProducto;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string descripcion;
        [ObservableProperty]
        public int cantidad;
        public EditarProductoViewModel(Producto producto)
        {
            idProducto = producto.IdProducto;
            nombre = producto.Nombre;
            descripcion = producto.Descripcion;
            cantidad = producto.Cantidad;
        }
        [RelayCommand]
        public async Task EditarProducto()
        {
            Producto producto = new()
            {
                IdProducto = IdProducto,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Cantidad = Cantidad
            };
            App.productoRepository.Update(producto);
            MessagingCenter.Send(this, "ProductoEditado");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

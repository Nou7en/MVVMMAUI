using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMProy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProy.ViewModels
{
    

    public partial class NuevoProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string descripcion;
        [ObservableProperty]
        public int cantidad;


        [RelayCommand]
        public async Task GuardarProducto()
        {
            Producto producto = new Producto
            {
                Nombre = Nombre,
                Descripcion = Descripcion,
                Cantidad = Cantidad
            };
            App.productoRepository.Add(producto);
            MessagingCenter.Send(this, "ProductoCreado");
            await App.Current.MainPage.Navigation.PopAsync();

            
        }
        /*public ICommand GuardarProducto =>
            new Command(async () =>
            {
                Producto producto = new Producto
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Cantidad = Cantidad
                };
                App.productoRepository.Add(producto);
                await App.Current.MainPage.Navigation.PopAsync();
            });*/
    }
}

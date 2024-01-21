using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMProy.Models;
using MVVMProy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProy.ViewModels
{
    public partial class ProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<ProductoDto> listaProductosDto = new ObservableCollection<ProductoDto>();

        public ProductoViewModel()
        {
            MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerLista()));

            MessagingCenter.Subscribe<NuevoProductoViewModel>(this, "ProductoCreado", async (sender) =>
            {
                await ObtenerLista();
            });

            MessagingCenter.Subscribe<DetalleProductoViewModel>(this, "ProductoEliminado", async (sender) =>
            {
                await ObtenerLista();
            });
            MessagingCenter.Subscribe<EditarProductoViewModel>(this, "ProductoEditado", async (sender) =>
            {
                await ObtenerLista();
            });
        }
        public async Task ObtenerLista()
        {
            if (listaProductosDto.Any())
            {
                listaProductosDto.Clear();
            }
            var listaProductos = App.productoRepository.GetAll();
            if (listaProductos.Any())
            {
                foreach (var item in listaProductos)
                {
                    ListaProductosDto.Add(new ProductoDto
                    {
                        IdProducto = item.IdProducto,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Cantidad = item.Cantidad,
                    });
                }
            }
        }
        [RelayCommand]
        public static async Task CrearProductoNuevo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoViewPage());
        }
        [RelayCommand]
        public static async Task DetalleProducto()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetalleProducto());
        }
        
        /* public ICommand CrearProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoViewPage());
            });*/
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProy.Models
{
    public partial class ProductoDto: ObservableObject
    {
        [ObservableProperty]
        public int idProducto;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string descripcion;
        [ObservableProperty]
        public int cantidad;
    }
}

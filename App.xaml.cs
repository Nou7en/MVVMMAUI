using MVVMProy.Service;
using MVVMProy.Views;

namespace MVVMProy
{
    public partial class App : Application
    {
        public static ProductoRepository productoRepository;
        public App()
        {
            InitializeComponent();
            productoRepository = new ProductoRepository();
            MainPage = new NavigationPage(new ProductoPage());
        }
    }
}
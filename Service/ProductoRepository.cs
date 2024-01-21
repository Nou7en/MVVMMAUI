using MVVMProy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProy.Service
{
    public  class ProductoRepository
    {
        SQLiteConnection connection;
        public ProductoRepository()
        {
            connection = new SQLiteConnection(Utils.Util.DataBasePath, Utils.Util.Flags);
            connection.CreateTable<Producto>();
        }

        public List<Producto> GetAll()
        {
            List<Producto> ListaProductos = new List<Producto>();
            try
            {
                ListaProductos = connection.Table<Producto>().ToList();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaProductos;
        }
        public void Add(Producto producto)
        {
            int result = 0;
            try
            {
                result = connection.Insert(producto);
                Console.WriteLine("Se agrego un producto");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se agrego un producto " + ex.Message);
            }
        }
        public Producto Get(int IdProducto)
        {

            try
            {
                if (IdProducto != 0)
                {
                    return connection.Table<Producto>()
                         .FirstOrDefault(x => x.IdProducto == IdProducto);
                }
                Console.WriteLine("Se agrego un producto");

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se agrego un producto " + ex.Message);
            }
            return null;
            
        }
        public void Update(Producto producto)
        {
            int result = 0;
            try
            {
                if (producto.IdProducto != 0)
                {
                    result = connection.Update(producto);
                }
                Console.WriteLine("Se agrego un producto");

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se agrego un producto " + ex.Message);
            }

        }
        public void Delete(int IdProducto)
        {

            try
            {
                if (IdProducto != 0)
                {
                    Producto result = Get(IdProducto);
                    connection.Delete(result);
                }
                Console.WriteLine("Se agrego un producto");

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se agrego un producto " + ex.Message);
            }

        }
    }
}

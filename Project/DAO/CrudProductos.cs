using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class CrudProductos
    {
        public void AgregarProducto(Producto ParametroProducto)
        {
            using(AlmacenContext db = new AlmacenContext())
            {
                Producto Pro = new Producto();

                Pro.Nombre = ParametroProducto.Nombre;
                Pro.Descripcion = ParametroProducto.Descripcion;
                Pro.Precio = ParametroProducto.Precio;
                Pro.Stock = ParametroProducto.Stock;
                db.Add(Pro);
                db.SaveChanges();
            }
        }

        public Producto ProductIndivi(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = db.Productos.FirstOrDefault(x=>x.Id==id);
                return buscar;
            }
        }

        public void ActualizarProduct(Producto ParametroProduct, int Lector)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductIndivi(ParametroProduct.Id);

                if (buscar == null)
                {
                    Console.Write("El id no existe");
                }
                else
                {
                    switch (Lector)
                    {
                        case 1:
                            buscar.Nombre = ParametroProduct.Nombre;
                            break;

                        case 2:
                            buscar.Descripcion = ParametroProduct.Descripcion;
                            break;

                        case 3:
                            buscar.Precio = ParametroProduct.Precio;
                            break;

                        case 4:
                            buscar.Stock = ParametroProduct.Stock;
                            break;
                    }
                    db.Update(buscar);
                    db.SaveChanges();
                }
            }
        }

        public String EliminarProduct(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductIndivi(id);

                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";
                }
            }
        }

        public List<Producto> ListarProduct()
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                return db.Productos.ToList();
            }
        }
    }
}
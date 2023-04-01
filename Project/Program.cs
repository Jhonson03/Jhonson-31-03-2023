using Project.DAO;
using Project.Models;

CrudProductos CrudProductos = new CrudProductos();
Producto Pro = new Producto();

bool Continuar = true;

while (Continuar)
{



    Console.Write(@"Menu
Pulse 1 Para Insertar un nuevo Producto
Pulse 2 Para Actualizar un Producto
Pulse 3 Para Eliminar un Producto
Pulse 4 Para Mostrar un Listado de Productos
Pulse 5 Para Salir
-> ");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 1:
            bool bucle = true;
            while (bucle == true)
            {
                Console.Write("Ingrese el nombre del producto -> ");
                Pro.Nombre = Console.ReadLine();
                Console.Write("\nIngrese una breve descripcion del producto -> ");
                Pro.Descripcion = Console.ReadLine();
                Console.Write("\nIngrese el precio del producto -> $");
                Pro.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.Write("\nIngrese la cantidad de productos existentes");
                Pro.Stock = Convert.ToInt32(Console.ReadLine());

                CrudProductos.AgregarProducto(Pro);

                Console.Write(@"
El Producto se ingreso correctamente

Pulsa 1 para seguir insertando Productos
Pulsa 2 para salir
-> ");

                var Menu2 = Convert.ToInt32(Console.ReadLine());

                switch (Menu2)
                {
                    case 1:
                        bucle = true;
                        break;

                    case 2:
                        Console.Write("Gracias por utilizar el programa");
                        bucle = false;
                        break;

                    default:
                        Console.Write("Ingrese una opcion del menu");
                        break;
                }
            }
            break;

        case 2:
            Console.Write("Actualizar Productos");
            Console.Write("\nIngrese el Id del producto a actualizar -> ");

            var BuscarProductIndiviU = CrudProductos.ProductIndivi(Convert.ToInt32(Console.ReadLine()));

            if (BuscarProductIndiviU == null)
            {
                Console.Write("El producto no existe");
            }
            else
            {
                Console.Write($"\nId: {BuscarProductIndiviU.Id}, Nombre: {BuscarProductIndiviU.Nombre}, Descripcion: {BuscarProductIndiviU.Descripcion}, Precio: {BuscarProductIndiviU.Precio}, Stock: {BuscarProductIndiviU.Stock}");
                Console.Write(@"
Ingrese 1 para actualizar el Nombre
Ingrese 2 para actualizar la Descripcion
Ingrese 3 para actualizar el Precio
Ingrese 4 para actualizar el Stock
-> ");

                var Lector = Convert.ToInt32(Console.ReadLine());

                switch (Lector)
                {
                    case 1:
                        Console.Write("Ingrese el nombre -> ");
                        BuscarProductIndiviU.Nombre = Console.ReadLine();
                        break;

                    case 2:
                        Console.Write("Ingrese la descripcion -> ");
                        BuscarProductIndiviU.Descripcion = Console.ReadLine();
                        break;

                    case 3:
                        Console.Write("Ingrese el precio -> ");
                        BuscarProductIndiviU.Precio = Convert.ToDecimal(Console.ReadLine());
                        break;

                    case 4:
                        Console.Write("Ingrese el stock -> ");
                        BuscarProductIndiviU.Stock = Convert.ToInt32(Console.ReadLine());
                        break;

                    default:
                        Console.Write("No se encuentra esta opcion en el panel de menu");
                        break;
                }

                CrudProductos.ActualizarProduct(BuscarProductIndiviU, Lector);
                Console.Write("Actualizacion completa");
            }

            break;

        case 3:
            Console.Write("\nIngrese el Id del producto a Eliminar");

            var ProductIndiviD = CrudProductos.ProductIndivi(Convert.ToInt32(Console.ReadLine()));

            if (ProductIndiviD == null)
            {
                Console.Write("Este producto no existe");
            }
            else
            {
                Console.Write("Eliminar Producto");
                Console.Write($"\nId: {ProductIndiviD.Id}, Nombre: {ProductIndiviD.Nombre}, Descripcion: {ProductIndiviD.Descripcion}, Precio: {ProductIndiviD.Precio}, Stock: {ProductIndiviD.Stock}");

                Console.Write("El producto encontrado es el correcto ingrese 1 -> ");
                var Lector = Convert.ToInt32(Console.ReadLine());

                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write(CrudProductos.EliminarProduct(Id));
                }
                else
                {
                    Console.Write("Inicia nuevamente");
                }
            }
            break;

        case 4:
            Console.Write("Lista de Productos");

            var ListaProductos = CrudProductos.ListarProduct();

            foreach (var i in ListaProductos)
            {
                Console.Write($"\nId: {i.Id}, Nombre: {i.Nombre}, Descripcion{i.Descripcion}, Precio: {i.Precio}, Stock: {i.Stock}");
            }
            break;

        case 5:
            Console.Write("Gracias por usar el programa, vuelva pronto");
            Continuar = false;
            break;

        default:
            Console.Write("La opcion no se encuentra disponible");
            break;
    }

    Console.Write(@"
Desea continuar?

Ingrese Si para continuar usando el programa
Ingrese No para salir
-> ");

    var cont = Console.ReadLine();

    if (cont.Equals("No"))
    {
        Continuar = false;
    }
    else if (cont.Equals("Si"))
    {
        Continuar = true;
    }
}

Console.Write("Gracias por usar el programa, vuelva pronto");
// Producto.cs
using System.Drawing;

namespace Veterinaria
{
    public abstract class Producto
    {
        public string Nombre { get; protected set; }
        public int Precio { get; protected set; }
        public Image Sprite { get; protected set; } // Imagen visual del producto

        public Producto(string nombre, int precio, Image sprite)
        {
            Nombre = nombre;
            Precio = precio;
            Sprite = sprite;
        }

        // Método abstracto para definir si es un objeto mejorable o un animal desbloqueable
        public abstract string Comprar();
    }
}

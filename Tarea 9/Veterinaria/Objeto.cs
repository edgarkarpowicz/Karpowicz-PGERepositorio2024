// Objeto.cs
using System.Drawing;

namespace Veterinaria
{
    public class Objeto : Producto
    {
        public int Nivel { get; private set; }
        public string Efecto { get; private set; }  // Efecto que tiene en el juego
        public Objeto(string nombre, int precio, Image sprite, string efecto) : base(nombre, precio, sprite)
        {
            Nivel = 1;
            Efecto = efecto;
        }

        public override string Comprar()
        {
            Nivel++;
            return $"Has mejorado el {Nombre} al nivel {Nivel}.";
        }

        // Método para aplicar el efecto del objeto en la partida
        public void Usar(FormVeterinaria partida)
        {
            if (Efecto == "vida" && Nombre == "Comida Premium")
            {
                partida.AumentarVida(1);
            }
            else if(Efecto == "vida" && Nombre == "Juguete")
            {
                partida.AumentarVida(2);
            }
            // Aquí puedes agregar más efectos según el objeto
        }
    }
}

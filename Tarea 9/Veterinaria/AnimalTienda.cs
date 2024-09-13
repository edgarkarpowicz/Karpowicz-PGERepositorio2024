// Animal.cs
using System.Collections.Generic;
using System.Drawing;
using Veterinaria;

namespace Veterinaria
{
    public class AnimalTienda : Producto
    {
        public bool Desbloqueado { get; private set; }
        public bool auxDesloqueado { get; private set; }


        public AnimalTienda(string nombre, int precio, Image sprite) : base(nombre, precio, sprite)
        {
            Desbloqueado = false;
        }

        public override string Comprar()
        {
            
            if (Desbloqueado)
            {
                auxDesloqueado = true;
                return $"{Nombre} ya ha sido desbloqueado.";
            }
            Desbloqueado = true;
      
            return $"Has desbloqueado a {Nombre}!";
        }

        // Método para agregar el animal a la pool de posibilidades
        public void AgregarALaPool(List<Animal> animalesPool)
        {
            if (Desbloqueado)
            {
                // Añadimos el nuevo animal desbloqueado a la pool
                if (Nombre == "Gato Persa")
                {
                    animalesPool.Add(new GatoPersa());  // Suponiendo que GatoPersa es una clase derivada de Animal
                }
                else if (Nombre == "Perro Labrador")
                {
                    animalesPool.Add(new PerroLabrador());
                }
                else if (Nombre == "Pajaro")
                {
                    animalesPool.Add(new Pajaro());
                }
                // Añadir más animales aquí según sea necesario
            }
        }
    }
}

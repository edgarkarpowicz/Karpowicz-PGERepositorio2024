// Programación Génerica y Eventos //
// Tomas Molina y Edgar Karpowicz //

// Ver comentarios para el Análisis //

using System;
public class Publicador
{
    public event EventHandler EventoOcurrido; // (2) Evento Personalizado aquí!

    public void DispararEvento() // Metodo para disparar el Evento, EventoOcurrido, e Invocarlo
    {
        EventoOcurrido?.Invoke(this, EventArgs.Empty);
    }
}

public class Suscriptor
{
    public void ManejadorEvento(object sender, EventArgs e) // (4) Manejador de Evento, recibe una vez ocurre el Evento y realiza un Procesamiento
    {
        Console.WriteLine("El evento ha ocurrido.");
    }
}

class Program
{
    static void Main()
    {
        Publicador publicador = new Publicador();
        Suscriptor suscriptor = new Suscriptor(); // Se crean las Instancias de las Clases

        publicador.EventoOcurrido += suscriptor.ManejadorEvento; // (3) Convertimos a la instancia de la Clase Subscriptor en un Suscriptor del Evento, EventoOcurrido, de la Instancia de la Clase Publicador

        publicador.DispararEvento(); // Se dispara el EventoOcurrido
    }
}

// (1) No tiene un Bucle Despachador de Eventos :(
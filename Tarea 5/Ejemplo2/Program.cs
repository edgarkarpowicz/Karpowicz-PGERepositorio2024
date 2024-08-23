// Programación Génerica y Eventos //
// Tomas Molina y Edgar Karpowicz //

// Ver comentarios para el Análisis //

using System;
using System.Collections.Generic;
using System.Threading;

namespace EventDispatcher
{
    public delegate void EventHandler(object sender, EventArgs e); // Definición de un Delegado, encapsula un Método o Conjunto de Métodos

    public class EventDispatcher
    {
        private readonly Dictionary<string, EventHandler> eventHandlers = new Dictionary<string, EventHandler>();

        public event EventHandler EventDispatched; // (2) Definición de Eventos Personalizados en la Clase

        public void Subscribe(string eventName, EventHandler eventHandler)
        {
            if (!eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = eventHandler;
            }
            else
            {
                eventHandlers[eventName] += eventHandler; // (3) Subscripción a Evento
            }
        }
        // Subscribe y Unsubscribe sirven para enviar el nombre de un Evento y posteriormente subscribe al EventHandler con el mismo.
        public void Unsubscribe(string eventName, EventHandler eventHandler)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] -= eventHandler; // (3) Desuscripción a Evento
            }
        }

        public void DispatchEvent(string eventName) // (4) Manejador de Evento, recibe una vez ocurre el Evento y realiza un Procesamiento
        {
            Console.WriteLine($"Evento '{eventName}' despachado.");
            EventDispatched?.Invoke(this, EventArgs.Empty);

            Thread.Sleep(1000);
        }
    }

    class Program
    {
        static void Main() // Ejecución del Programa
        {
            EventDispatcher eventDispatcher = new EventDispatcher();

            eventDispatcher.Subscribe("Evento1", Event1Handler);

            eventDispatcher.Subscribe("Evento2", Event2Handler);

            eventDispatcher.EventDispatched += GlobalEventHandler;

            eventDispatcher.DispatchEvent("Evento1");
            eventDispatcher.DispatchEvent("Evento2");

            eventDispatcher.Unsubscribe("Evento1", Event1Handler);

            eventDispatcher.DispatchEvent("Evento1");
            eventDispatcher.DispatchEvent("Evento2");
        }

        static void Event1Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador del Evento1");
        }

        static void Event2Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador del Evento2");
        }

        static void GlobalEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador Global del Evento");
        }
    }
}

// (1) No tiene un Bucle Despachador de Eventos :(
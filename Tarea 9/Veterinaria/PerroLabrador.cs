// Perro.cs
using System;
using System.Media;
using Veterinaria;

namespace Veterinaria
{
    public class PerroLabrador : Animal
    {
        private SoundPlayer soundPlayer;

        private string estadoComer, estadoDormir;

        public PerroLabrador()
        {
            // soundPlayer = new SoundPlayer("Audios\\perro_ladrido.wav"); // Ruta al archivo de sonido
        }

        public override void Comer(bool auxiliarComer)
        {
            if (auxiliarComer == true)
            {
                estadoComer = "El Perro Labrador está comiendo";
            }
            else
            {
                estadoComer = "El Perro Labrador no está comiendo";
            }

        }

        public override void Dormir(bool auxilitarDormir)
        {
            if (auxilitarDormir == true)
            {
                estadoDormir = "El Perro Labrador está durmiendo";
            }
            else
            {
                estadoDormir = "El Perro Labrador no está durmiendo";
            }

        }

        public override string EstadoDormir()
        {
            return estadoDormir;
        }

        public override string EstadoComer()
        {
            return estadoComer;
        }

        public override string Actividad()
        {
            // Reproducir sonido del perro
            using (soundPlayer = new SoundPlayer("Audios\\perro_ladrido.wav"))
            {
                soundPlayer.Play();
            }
            return $"{Nombre} ladra";
        }
    }
}

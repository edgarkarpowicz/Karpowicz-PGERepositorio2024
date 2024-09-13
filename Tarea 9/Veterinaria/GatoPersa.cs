// Gato.cs
using System;
using System.Media;
using Veterinaria;

namespace Veterinaria
{
    public class GatoPersa : Animal
    {
        private SoundPlayer soundPlayer;
        private string estadoDormir, estadoComer;

        public GatoPersa()
        {
            // soundPlayer = new SoundPlayer("Audios\\gato_meow.wav"); // Ruta al archivo de sonido
        }

        public override void Comer(bool auxiliarComer)
        {
            if (auxiliarComer == true)
            {
                estadoComer = "El gato persa está comiendo";
            }
            else
            {
                estadoComer = "El gato persa no está comiendo";
            }

        }

        public override void Dormir(bool auxilitarDormir)
        {
            if (auxilitarDormir == true)
            {
                estadoDormir = "El gato persa está durmiendo";
            }
            else
            {
                estadoDormir = "El gato  persa no está durmiendo";
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
            // Reproducir sonido del gato
            using (soundPlayer = new SoundPlayer("Audios\\gato_meow.wav"))
            {
                soundPlayer.Play();
            }
            return $"{Nombre} maúlla";
        }
    }
}

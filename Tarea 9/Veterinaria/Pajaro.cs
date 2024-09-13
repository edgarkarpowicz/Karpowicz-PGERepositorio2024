// Perro.cs
using System;
using System.Media;
using Veterinaria;

namespace Veterinaria
{
    public class Pajaro : Animal
    {
        private SoundPlayer soundPlayer;

        private string estadoComer, estadoDormir;

        public Pajaro()
        {
            // soundPlayer = new SoundPlayer("Audios\\Pajaro.wav"); // Ruta al archivo de sonido
        }

        public override void Comer(bool auxiliarComer)
        {
            if (auxiliarComer == true)
            {
                estadoComer = "El Pajaro está comiendo";
            }
            else
            {
                estadoComer = "El Pajaro no está comiendo";
            }

        }

        public override void Dormir(bool auxilitarDormir)
        {
            if (auxilitarDormir == true)
            {
                estadoDormir = "El Pajaro está durmiendo";
            }
            else
            {
                estadoDormir = "El Pajaro no está durmiendo";
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
            using (soundPlayer = new SoundPlayer("Audios\\Pajaro.wav"))
            {
                soundPlayer.Play();
            }
            return $"{Nombre} gorjea";
        }
    }
}

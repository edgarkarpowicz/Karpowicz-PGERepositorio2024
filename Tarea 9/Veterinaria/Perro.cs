// Perro.cs
using System;
using System.Media;
using Veterinaria;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Veterinaria
{
    public class Perro : Animal
    {
        private SoundPlayer soundPlayer;

        private string estadoComer, estadoDormir;

        public Perro()
        {
            // soundPlayer = new SoundPlayer("Audios\\perro_ladrido.wav"); // Ruta al archivo de sonido
        }

        public override void Comer(bool auxiliarComer)
        {
            if (auxiliarComer == true)
            {
                estadoComer = "El perro está comiendo";
            }
            else
            {
                estadoComer = "El perro no está comiendo";
            }

        }

        public override void Dormir(bool auxilitarDormir)
        {
            if (auxilitarDormir == true)
            {
                estadoDormir = "El perro está durmiendo";
            }
            else
            {
                estadoDormir = "El perro no está durmiendo";
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

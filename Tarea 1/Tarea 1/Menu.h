// Estudiante.h //

#include <iostream>
#include <string>
#include "Estudiante.h"
using namespace std;

class Menu {
	public:
		Menu();

		void Separacion();
		int encontrarEstudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
		void ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes);
		void delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
		void ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
		void print_Calificaciones(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
		void print_Estudiantes(vector <Estudiante>* Estudiantes);

}; 

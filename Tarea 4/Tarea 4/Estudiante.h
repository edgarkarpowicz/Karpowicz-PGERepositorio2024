// Estudiante.h //

#include <iostream>
#include <string>

#include <utility>
#include <vector>

#include "Persona.h"

using namespace std;

class Estudiante : public Persona {

	private:
		vector<pair<string, int>> Calificaciones;

	public:
		Estudiante(string Nombre, string Apellido, int Edad);

		vector<pair<string, int>> getCalificaciones();

		void imprimirCalificaciones();
		void sacarPromedio();
		void getDatos();
		bool emptyCalificaciones();
		void pushCalificacion(string Materia, int Nota);

		void cleanCalificaciones();
		void eraseCalificacion(int dondeBorrar);
};
// Funciones de Estudiante.h //

#include <iostream>
#include <string>

#include <utility>
#include <vector>

#include "Estudiante.h"

using namespace std;

Estudiante::Estudiante(string Nombre, string Apellido, int Edad) 
{
	setNombre(Nombre);
	setApellido(Apellido);
	setEdad(Edad);
}

void Estudiante::imprimirCalificaciones() 
{
	for (int x = 0; x != Calificaciones.size(); x++) {
		cout << Calificaciones.at(x).first << " con Nota " << Calificaciones.at(x).second << endl;
	}
}

void Estudiante::sacarPromedio() 
{
	int Total = 0;
	for (int x = 0; x != Calificaciones.size(); x++) {
		Total += Calificaciones.at(x).second;
	}
	int Promedio = Total / Calificaciones.size();
	cout << "Este es el Promedio: " << Promedio << endl;
}

void Estudiante::getDatos() 
{
	cout << "Nombre: " << getNombre() << " | Apellido: " << getApellido() << " | Edad: " << getEdad() << endl;
}

bool Estudiante::emptyCalificaciones() {
	if (Calificaciones.empty() == true) {
		return true;
	}
	else {
		return false;
	}
}

void Estudiante::pushCalificacion(string Materia, int Nota) 
{
	pair<string, int> temp;
	temp.first = Materia;
	temp.second = Nota;
	Calificaciones.push_back(temp);
}

void Estudiante::cleanCalificaciones() 
{
	Calificaciones.clear();
}
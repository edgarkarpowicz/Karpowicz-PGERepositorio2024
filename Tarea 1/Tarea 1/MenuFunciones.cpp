// Funciones de Menu.h //

#include <iostream>
#include <string>

#include <utility>
#include <vector>

#include "Menu.h"

using namespace std;

void Menu::Separacion() {
	for (int x = 0; x != 50; x++) {
		cout << "-";
	}
	cout << "" << endl;
}

int Menu::encontrarEstudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	int TEMP = 0;
	for (int x = 0; x != Estudiantes->size(); x++) {
		if (Estudiantes->at(x).getNombre() == Nombre && Estudiantes->at(x).getApellido() == Apellido && Estudiantes->at(x).getEdad() == Edad) {
			TEMP = x;
			return TEMP;
		}
	}
	return -1;
}

void Menu::ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
	}
	else {
		Estudiantes->at(POS).pushCalificacion(Materia, Nota);
	}
}

void Menu::delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
	}
	else {
		Estudiantes->erase(Estudiantes->begin() + POS);
	}
}

void Menu::ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	Estudiante* futuro_Estudiante = new Estudiante(Nombre, Apellido, Edad);
	Estudiantes->push_back(*futuro_Estudiante);
}

void Menu::print_Calificaciones(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
	}
	else {
		if (Estudiantes->at(POS).emptyCalificaciones() == true) {
			cout << "El Estudiante no tiene Calificaciones cargadas" << endl;
		}
		Estudiantes->at(POS).imprimirCalificaciones();
	}
	Separacion();
}

void Menu::print_Estudiantes(vector <Estudiante>* Estudiantes) {
	if (Estudiantes->size() == 0) {
		cout << "No hay Estudiantes" << endl;
	}
	for (int x = 0; x != Estudiantes->size(); x++) {
		Estudiantes->at(x).getDatos();
	}
	Separacion();
}

Menu::Menu() {
	vector <Estudiante>* Estudiantes = new vector <Estudiante>;
	while (true) {
		int seleccion = 0;
		string NOM;
		string APE;
		int EDA;
		string MAT;
		int NOT;
		cout << "GESTION DE BASE DE DATOS DE LOS ESTUDIANTES" << endl;
		cout << "MENU INTERACTIVO" << endl;
		Separacion();
		cout << "1 - Imprimir Estudiantes" << endl;
		cout << "2 - Obtener Calificaciones de un Estudiante" << endl;
		cout << "3 - Ingresar Estudiante" << endl;
		cout << "4 - Borrar un Estudiante" << endl;
		cout << "5 - Ingresar Calificacion a un Estudiante" << endl;
		cout << "6 - Salir" << endl;
		Separacion();
		cin >> seleccion;
		Separacion();
		switch (seleccion) {
		case 1:
			print_Estudiantes(Estudiantes);
			break;

		case 2:
			if (Estudiantes->empty() == true) {
				cout << "No hay Estudiantes cargados" << endl;
				Separacion();
			}
			else {
				cout << "Ingrese el Nombre del Estudiante" << endl;
				cin >> NOM;
				Separacion();
				cout << "Ingrese el Apellido del Estudiante" << endl;
				cin >> APE;
				Separacion();
				cout << "Ingrese la Edad del Estudiante" << endl;
				cin >> EDA;
				Separacion();
				print_Calificaciones(NOM, APE, EDA, Estudiantes);
			}
			break;

		case 3:
			cout << "Ingrese el Nombre del Estudiante" << endl;
			cin >> NOM;
			Separacion();
			cout << "Ingrese el Apellido del Estudiante" << endl;
			cin >> APE;
			Separacion();
			cout << "Ingrese la Edad del Estudiante" << endl;
			cin >> EDA;
			Separacion();
			ingresar_Estudiante(NOM, APE, EDA, Estudiantes);
			break;

		case 4:
			cout << "Ingrese el Nombre del Estudiante" << endl;
			cin >> NOM;
			Separacion();
			cout << "Ingrese el Apellido del Estudiante" << endl;
			cin >> APE;
			Separacion();
			cout << "Ingrese la Edad del Estudiante" << endl;
			cin >> EDA;
			Separacion();
			delete_Estudiante(NOM, APE, EDA, Estudiantes);
			break;

		case 5:
			cout << "Ingrese el Nombre del Estudiante" << endl;
			cin >> NOM;
			Separacion();
			cout << "Ingrese el Apellido del Estudiante" << endl;
			cin >> APE;
			Separacion();
			cout << "Ingrese la Edad del Estudiante" << endl;
			cin >> EDA;
			Separacion();
			cout << "Ingrese la Materia del Estudiante" << endl;
			cin >> MAT;
			Separacion();
			cout << "Ingrese la Nota del Estudiante" << endl;
			cin >> NOT;
			Separacion();
			ingresar_Calificacion(NOM, APE, EDA, MAT, NOT, Estudiantes);
			break;

		case 6:
			cout << "Saliendo..." << endl;
			return;
			break;

		default:
			cout << "Mal Ingreso. Vuelva a Intentar" << endl;
			Separacion();
			break;
		}
	}
}
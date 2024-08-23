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

string Menu::obtenerNombre() {
	string Nombre;
	cout << "Ingrese el Nombre del Estudiante" << endl;
	cin >> Nombre;
	return Nombre;
}

string Menu::obtenerApellido() {
	string Apellido;
	cout << "Ingrese el Apellido del Estudiante" << endl;
	cin >> Apellido;
	return Apellido;
}

int Menu::obtenerEdad() {
	int Edad = 0;
	cout << "Ingrese la Edad del Estudiante" << endl;
	cin >> Edad;
	return Edad;
}

string Menu::obtenerMateria() {
	string Materia;
	cout << "Ingrese la Materia en cuestion" << endl;
	cin >> Materia;
	return Materia;
}

int Menu::obtenerNota() {
	int Nota = 0;
	cout << "Ingrese la Nota del Estudiante" << endl;
	cin >> Nota;
	return Nota;
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

int Menu::encontrarCalificacion(string Materia, int Nota, vector<pair<string, int>> Calificaciones) {
	int TEMP = 0;
	for (int x = 0; x != Calificaciones.size(); x++) {
		if (Calificaciones.at(x).first == Materia && Calificaciones.at(x).second == Nota) {
			TEMP = x;
			return TEMP;
		}
	}
	return -1;
}

void Menu::ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes) {
	if (Nota < 0) {
		cout << "Nota no puede ser menor a 0" << endl;
		Separacion();
		return;
	}

	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
	}
	else {
		Estudiantes->at(POS).pushCalificacion(Materia, Nota);
	}
}

void Menu::eliminar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);

	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
		return;
	}
	else {
		int CALF = 0;
		CALF = encontrarCalificacion(Materia, Nota, Estudiantes->at(POS).getCalificaciones());
		if (CALF == -1) {
			cout << "No existe tal Calificacion" << endl;
			Separacion();
			return;
		}
		else {
			Estudiantes->at(POS).eraseCalificacion(CALF);
			cout << "Borrada con Exito!" << endl;
			Separacion();
			return;
		}
	}
	return;
}

void Menu::delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
	}
	else {
		Estudiantes->erase(Estudiantes->begin() + POS);
	}
}

void Menu::ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes) {
	if (Edad <= 0) {
		cout << "Edad no puede ser Negativa y/o 0" << endl;
		Separacion();
		return;
	} 
	int POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS != -1) {
		cout << "Ya existe un Estudiante de ese Nombre, Apellido, y Edad" << endl;
		Separacion();
		return;
	}

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
		Estudiantes->at(POS).sacarPromedio();
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

void Menu::callbackEstudiantes(int Posicion, vector<Estudiante>* Estudiantes) {
	if (Estudiantes->at(Posicion).emptyCalificaciones() == true) {
		cout << "El Estudiante no tiene Calificaciones cargadas" << endl;
	}
	Estudiantes->at(Posicion).imprimirCalificaciones();
	Estudiantes->at(Posicion).sacarPromedio();
}

void Menu::print_Calificaciones(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes, void (Menu:: *callback)(int, vector<Estudiante>*)) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
	}
	else {
		(this->*callback)(POS, Estudiantes);
	}
	Separacion();
}

void Menu::callbackProfesores(string Materia, int Nota, int Posicion, vector<Estudiante>* Estudiantes) {
	Estudiantes->at(Posicion).pushCalificacion(Materia, Nota);
}

void Menu::ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector<Estudiante>* Estudiantes, void (Menu:: *callback)(string, int, int, vector<Estudiante>*)) {
	if (Nota < 0) {
		cout << "Nota no puede ser menor a 0" << endl;
		Separacion();
		return;
	}

	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
	}
	else {
		(this->*callback)(Materia, Nota, POS, Estudiantes);
	}
}

void Menu::delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes, void (Menu::* callback)(int, vector<Estudiante>*)) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
	}
	else {
		(this->*callback)(POS, Estudiantes);
	}
}

void Menu::callbackDeleteEstudiantes(int Posicion, vector<Estudiante>* Estudiantes) {
	Estudiantes->erase(Estudiantes->begin() + Posicion);
}

void Menu::ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes, void (Menu::* callback)(Estudiante*, vector<Estudiante>*)) {
	if (Edad <= 0) {
		cout << "Edad no puede ser Negativa y/o 0" << endl;
		Separacion();
		return;
	}
	int POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);
	if (POS != -1) {
		cout << "Ya existe un Estudiante de ese Nombre, Apellido, y Edad" << endl;
		Separacion();
		return;
	}

	Estudiante* futuro_Estudiante = new Estudiante(Nombre, Apellido, Edad);
	callbackIngresarEstudiantes(futuro_Estudiante, Estudiantes);
}

void Menu::callbackIngresarEstudiantes(Estudiante* student, vector<Estudiante>* Estudiantes) {
	Estudiantes->push_back(*student);
}

void Menu::callbackEliminarCalificacion(int Posicion, int dondeBorrar, vector<Estudiante>* Estudiantes) {
	Estudiantes->at(Posicion).eraseCalificacion(dondeBorrar);
	cout << "Borrada con Exito!" << endl;
	Separacion();
}

void Menu::eliminar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes, void (Menu::* callback)(int, int, vector<Estudiante>*)) {
	int POS = 0;
	POS = encontrarEstudiante(Nombre, Apellido, Edad, Estudiantes);

	if (POS == -1) {
		cout << "No existe tal Estudiante" << endl;
		Separacion();
		return;
	}
	else {
		int CALF = 0;
		CALF = encontrarCalificacion(Materia, Nota, Estudiantes->at(POS).getCalificaciones());
		if (CALF == -1) {
			cout << "No existe tal Calificacion" << endl;
			Separacion();
			return;
		}
		else {
			callbackEliminarCalificacion(POS, CALF, Estudiantes);
			return;
		}
	}
	return;
}

void Menu::runEventLoop() {
	vector <Estudiante>* Estudiantes = new vector <Estudiante>;
	bool running = true;
	while (running) {
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
		cout << "6 - Eliminar una Calificacion de un Estudiante" << endl;
		cout << "7 - Salir" << endl;
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
				NOM = obtenerNombre();
				Separacion();
				APE = obtenerApellido();
				Separacion();
				EDA = obtenerEdad();
				Separacion();

				print_Calificaciones(NOM, APE, EDA, Estudiantes, &Menu::callbackEstudiantes);
			}
			break;

		case 3:
			NOM = obtenerNombre();
			Separacion();
			APE = obtenerApellido();
			Separacion();
			EDA = obtenerEdad();
			Separacion();

			ingresar_Estudiante(NOM, APE, EDA, Estudiantes, &Menu::callbackIngresarEstudiantes);
			break;

		case 4:
			NOM = obtenerNombre();
			Separacion();
			APE = obtenerApellido();
			Separacion();
			EDA = obtenerEdad();
			Separacion();

			delete_Estudiante(NOM, APE, EDA, Estudiantes, &Menu::callbackDeleteEstudiantes);
			break;

		case 5:
			NOM = obtenerNombre();
			Separacion();
			APE = obtenerApellido();
			Separacion();
			EDA = obtenerEdad();
			Separacion();
			MAT = obtenerMateria();
			Separacion();
			NOT = obtenerNota();
			Separacion();

			ingresar_Calificacion(NOM, APE, EDA, MAT, NOT, Estudiantes, &Menu::callbackProfesores);
			break;

		case 6:
			NOM = obtenerNombre();
			Separacion();
			APE = obtenerApellido();
			Separacion();
			EDA = obtenerEdad();
			Separacion();
			MAT = obtenerMateria();
			Separacion();
			NOT = obtenerNota();
			Separacion();

			eliminar_Calificacion(NOM, APE, EDA, MAT, NOT, Estudiantes, &Menu::callbackEliminarCalificacion);
			break;

		case 7:
			cout << "Saliendo..." << endl;
			running = false;
			break;

		default:
			cout << "Mal Ingreso. Vuelva a Intentar" << endl;
			Separacion();
			break;
		}
	}
}

Menu::Menu() {
	this->runEventLoop(); //Bucle de Eventos
}
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
	int encontrarCalificacion(string Materia, int Nota, vector<pair<string, int>> Calificaciones);
	void ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes);
	void eliminar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes);
	void delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
	void ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
	void print_Calificaciones(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes);
	void print_Estudiantes(vector <Estudiante>* Estudiantes);

	// Callbacks:
	void callbackEstudiantes(int Posicion, vector<Estudiante>* Estudiantes); 
	void callbackProfesores(string Materia, int Nota, int Posicion, vector<Estudiante>* Estudiantes); 

	void callbackDeleteEstudiantes(int Posicion, vector<Estudiante>* Estudiantes);
	void callbackIngresarEstudiantes(Estudiante* Student, vector<Estudiante>* Estudiantes);
	void callbackEliminarCalificacion(int Posicion, int dondeBorrar, vector<Estudiante>* Estudiantes);

	// Sobrecargas de las Funciones para la compatibilidad con los callbacks:
	void print_Calificaciones(string Nombre, string Apellido, int Edad, vector<Estudiante>* Estudiantes, void (Menu::* callback)(int, vector<Estudiante>*));
	void ingresar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector<Estudiante>* Estudiantes, void (Menu::* callback)(string, int, int, vector<Estudiante>*));

	void delete_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes, void (Menu::* callback)(int, vector<Estudiante>*));
	void ingresar_Estudiante(string Nombre, string Apellido, int Edad, vector <Estudiante>* Estudiantes, void (Menu::* callback)(Estudiante*, vector<Estudiante>*));
	void eliminar_Calificacion(string Nombre, string Apellido, int Edad, string Materia, int Nota, vector <Estudiante>* Estudiantes, void (Menu::* callback)(int, int, vector<Estudiante>*));

	string obtenerNombre();
	string obtenerApellido();
	int obtenerEdad();

	string obtenerMateria();
	int obtenerNota();

	// EventLoop:
	void runEventLoop();
}; 

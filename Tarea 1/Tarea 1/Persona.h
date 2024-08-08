// Persona.h //

#include <iostream>
#include <string>

using namespace std;

class Persona {

private:
	string Nombre;
	string Apellido;
	int Edad;

public:
	Persona();
	Persona(string Nombre, string Apellido, int Edad);

	void Saludar();

	void setNombre(string Nombre);
	void setApellido(string Apellido);
	void setEdad(int Edad);

	string getNombre();
	string getApellido();
	int getEdad();
};
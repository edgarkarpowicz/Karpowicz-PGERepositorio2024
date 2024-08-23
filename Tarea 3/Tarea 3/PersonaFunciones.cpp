// Funciones de Persona.h //

#include <iostream>
#include <string>
#include "Persona.h"

using namespace std;

Persona::Persona() 
{
	Nombre = "default";
	Apellido = "default";
	Edad = 0;
}

Persona::Persona(string Nombre, string Apellido, int Edad) 
{
	this->Nombre = Nombre;
	this->Apellido = Apellido;
	this->Edad = Edad;
}

void Persona::Saludar() 
{
	cout << "Hola, soy " << this->Nombre << endl;
}

void Persona::setNombre(string Nombre) 
{
	this->Nombre = Nombre;
}

void Persona::setApellido(string Apellido)
{
	this->Apellido = Apellido;
}

void Persona::setEdad(int Edad) 
{
	this->Edad = Edad;
}

string Persona::getNombre() 
{
	return this->Nombre;
}

string Persona::getApellido() 
{
	return this->Apellido;
}

int Persona::getEdad() 
{
	return this->Edad;
}
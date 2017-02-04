using System;


/**
 * Clase Sprite
 * Contendrá todos los elementos comunes a los diferentes elementos que vamos a dibujar en pantalla
*/
public class Sprite {

	protected int x; // Columna
	protected int y; // Fila (De 0 a 24)
	protected ConsoleColor color; // Color con el que dibujar
	protected string imagen; // imagen o símbolo del elemento a representar

	/* Constructor de la clase */
	public Sprite(int x, int y) {
		this.x = x;
		this.y = y;
	}

	/* GETTER */
	public int GetX() { return this.x;}
	public int GetY() { return this.y; }
	public ConsoleColor GetColor() { return this.color; }
	public string GetImagen() { return this.imagen; }

	/* SETTER */
	public void SetX(int x) { this.x = x;}
	public void SetY(int y) { this.y = y; }
	public void SetColor(ConsoleColor color) { this.color = color; }
	public void SetImagen(string imagen) { this.imagen = imagen; }

	/**
	 * Método virtual que nos permite dibujar la imagen del sprite en las coordenadas que tiene asignado
	*/
	public virtual void Dibujar() {
		Console.SetCursorPosition(this.x, this.y);
		Console.Write(imagen);	
	}
}

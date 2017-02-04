using System;

/**
 * Clase Nave
 * Será nuestra nave del juego que controlaremos, es decir, nuestro jugador principal
*/
public class Nave : Sprite {

	public Nave(int x, int y) : base(x, y){
		this.imagen = "U";
		this.color = ConsoleColor.Red;
	}
	/**
	 * Redefino el método Dibujar de Sprite para pintar con el color deseado la nave
	*/
	public override void Dibujar() {
		// Con fondo negro y texto blanco
		Console.ForegroundColor = this.color;

		// Invocamos al método padre para que dibuje
		base.Dibujar();

		// Reseteamos los colores del terminal
		Console.ResetColor();

	}
}

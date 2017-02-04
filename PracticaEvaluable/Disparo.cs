using System;

public class Disparo : Sprite{

	public Disparo(int x, int y) : base(x, y) { 
		this.imagen = "A";
	}

	public override void Dibujar() {
		// Con fondo negro y texto blanco
		Console.ForegroundColor = ConsoleColor.Black;

		// Invocamos al método padre para que dibuje
		base.Dibujar();

		// Reseteamos los colores del terminal
		Console.ResetColor();
	}
}

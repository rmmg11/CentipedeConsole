using System;

/**
 * Clase Juego
 * Esta clase se encarga de mostrar el rótulo el juego y decirle al usuario que pulse cualquier tecla para jugar o 
 * Esc para salir
*/

public class Juego {

	public void Lanzar() { 
		// Mientras que no elijamos salir:
		// 1. Lanzar la pantalla de partida
		// 2. Lanzar la pantalla de créditos
		Bienvenida pantallaBienvenida = new Bienvenida();
		Creditos pantallaCreditos = new Creditos();
		Partida pantallaPartida = new Partida();
		do {
			// Lanzar bienvenida
			pantallaBienvenida.Lanzar();

			// Si no se elige salir
			if (!pantallaBienvenida.GetSalir())
			{
				// Lanzar partida en el nivel inicial
				pantallaPartida.Lanzar();
				// Una vez que haya finalizado la partida 
				// Lanzar créditoss
				pantallaCreditos.Lanzar();
			}
		} while (!pantallaBienvenida.GetSalir());
	}
}

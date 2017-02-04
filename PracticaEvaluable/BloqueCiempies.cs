using System;

/**
 * Clase BloqueCiempies
 * Representa cada eslabón del ciempiés
*/
public class BloqueCiempies	: Sprite {

	/* Tipos de movimientos del ciempies */
	public const int IZQUIERDA = 0;
	public const int DERECHA = 1;
	public const int ABAJO = 2;

	/* Posiciones del obstáculo */
	public const int OBSTACULO_IZQUIERDA = -1;
	public const int OBSTACULO_DERECHA = 1;
	public const int NO_OBSTACULO = 0;

	private int movimientoActual = DERECHA; // movimiento actual del ciempies, por defecto a la derecha
	private int posicionObstaculo = NO_OBSTACULO; // Inicialmente no habrá obstáculos

	public BloqueCiempies(int x, int y) : base(x, y) {
		this.imagen = "O";
		this.color = ConsoleColor.Green;
	}

	public override void Dibujar() {
		Console.ForegroundColor = this.color;

		// Invocamos al método padre para que dibuje
		base.Dibujar();

		// Reseteamos los colores del terminal
		Console.ResetColor();
	}

	public void Mover(Obstaculo []obstaculos) {
		
		if (movimientoActual == ABAJO) {
			if (posicionObstaculo == DERECHA) movimientoActual = IZQUIERDA;
			else movimientoActual = DERECHA;
			posicionObstaculo = NO_OBSTACULO;
		}
		if (GetX() == 20 && movimientoActual == IZQUIERDA) {
			posicionObstaculo = IZQUIERDA;
			movimientoActual = ABAJO;
		}
		else if (GetX() == 59 && movimientoActual == DERECHA){			
			posicionObstaculo = DERECHA;
			movimientoActual = ABAJO;
		}


		bool detectaObstaculo = false;
		if (movimientoActual == IZQUIERDA) {
			// Recorremos todos los obstáculos y si alguno está a la izquierda cambiamos el mov hacia abajo
			for (int i = 0; i < obstaculos.Length && !detectaObstaculo; i++) {
				if (!obstaculos[i].GetDestruido() && 
				    obstaculos[i].GetX() == this.GetX() -1 && 
				    obstaculos[i].GetY() == this.GetY()) {
					posicionObstaculo = IZQUIERDA;
					movimientoActual = ABAJO;
					detectaObstaculo = true;
				}
			}
		}
		else if (movimientoActual == DERECHA){
			detectaObstaculo = false;
			// Recorremos todos los obstáculos y si alguno está a la derecha cambiamos el mov hacia abajo
			for (int i = 0; i < obstaculos.Length && !detectaObstaculo; i++) {
				if (!obstaculos[i].GetDestruido() &&
				    obstaculos[i].GetX() == this.GetX() + 1 &&
					obstaculos[i].GetY() == this.GetY()) {
					posicionObstaculo = DERECHA;
					movimientoActual = ABAJO;
					detectaObstaculo = true;
				}
			}
		}

	}

	public int GetMovimientoActual() { return movimientoActual;}
}

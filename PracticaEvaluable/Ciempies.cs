using System;


/**
 * Clase Ciempies
 * Clase que contiene un array de bloques (bloqueCiempies), representa el gusano que tenemos en el juego
*/
public class Ciempies{

	private BloqueCiempies[] bloqueCiempies;
	private int numBloquesPerdidos;

	public Ciempies(int longitud) {
		bloqueCiempies = new BloqueCiempies[longitud];
		bloqueCiempies[0] = new CabezaCiempies(20 + longitud - 1, 0);
		numBloquesPerdidos = 0;

		for (int i = 1; i < longitud; i++) { bloqueCiempies[i] = new BloqueCiempies(20 + longitud - 1 - i, 0);}
	}

	/*
	* Pintamos tanto s bloques como queden sin destruir empezando desde la cabeza
	*/
	public void Dibujar() {
		for (int i = 0; i < bloqueCiempies.Length - numBloquesPerdidos; i++) { bloqueCiempies[i].Dibujar();}
	}

	public void Mover(Obstaculo []obstaculo) {
		for (int i = 0; i < bloqueCiempies.Length; i++){
			Console.SetCursorPosition(bloqueCiempies[i].GetX(),
			bloqueCiempies[i].GetY());
			Console.Write(" ");

			bloqueCiempies[i].Mover(obstaculo);

			if (bloqueCiempies[i].GetMovimientoActual() == BloqueCiempies.IZQUIERDA)
				bloqueCiempies[i].SetX(bloqueCiempies[i].GetX() - 1);
			else if (bloqueCiempies[i].GetMovimientoActual() == BloqueCiempies.DERECHA)
				bloqueCiempies[i].SetX(bloqueCiempies[i].GetX() + 1);
			else if (bloqueCiempies[i].GetMovimientoActual() == BloqueCiempies.ABAJO)
				bloqueCiempies[i].SetY(bloqueCiempies[i].GetY() + 1);
		}
	}

	public bool CiempiesDestruido() { return numBloquesPerdidos == bloqueCiempies.Length; }

	public void DestruyeBloque() { this.numBloquesPerdidos++;}

	public void DetectarColisionesConDisparo(ref Disparo disparo) {
		// Recorre los bloques por destruir 
		for (int i = 0; i < bloqueCiempies.Length - numBloquesPerdidos && disparo != null; i++) {
			if (bloqueCiempies[i].GetX() == disparo.GetX() && 
			    bloqueCiempies[i].GetY() == disparo.GetY()) {
				DestruyeBloque();
				disparo = null;
			}
		}
	}
	public bool DetectarColisionConNave(Nave nave) {
		/* 
		 * Para cada bloque no destruido, si sus coordenadas coinciden con las de la nave devolvemos true, 
		 * si no false 
		*/
		for (int i = 0; i < bloqueCiempies.Length - numBloquesPerdidos; i++) {
			if (bloqueCiempies[i].GetX() == nave.GetX() && 
 			    bloqueCiempies[i].GetY() == nave.GetY()) 
				return true;
		}
		return false;
	}
	public bool FinalDelCamino() {
		bool resultado = false;
		// Comrpueba si el primer elemento del ciempiés está en la esquina inf izda o dcha
		if (!CiempiesDestruido()) {
			if ((bloqueCiempies[0].GetX() == 20 || 
			     bloqueCiempies[0].GetX() == 59) &&
			    bloqueCiempies[0].GetY() == 24) { 
				resultado = true;
			}
		}
		return resultado;
	}
}


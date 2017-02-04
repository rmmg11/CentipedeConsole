using System;

/**
 * Clase CentipedeConsole
 * Es la clase principal de nuestro juego. Será la encargada de crear un objeto de la clase juego y lanzarlo
 * ya que dicho objeto es el encargado de gestionar el paso entre pantallas
*/
public class CentipedeConsole {

	public static void Main(string[] args) {
		Juego juegoCentipede = new Juego();
		juegoCentipede.Lanzar();
	}
}

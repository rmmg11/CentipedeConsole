using System;


/**
 * Clase CabezaCiempies
 * Representa la cabeza del ciemprés y así poder saber hacia dónde se dirige en cada momento
*/
public class CabezaCiempies : BloqueCiempies {

	public CabezaCiempies(int x, int y) : base(x, y) {
		this.imagen = "$";
	}

}

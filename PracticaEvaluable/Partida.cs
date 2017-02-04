using System;

/**
 * Clase Partida
 * Esta clase es la encargada de gestionar la lógica del juego
*/
public class Partida {

	private int nivel;
	private int longCiempies;
	private int numObstaculos;
	private int puntos;

	private void SetLongCiempies(int longitud) { this.longCiempies = longitud;}
	private void SetNumObstaculos(int obstaculos) { this.numObstaculos = obstaculos; }
	private void SetPuntos(int puntos) { this.puntos = puntos; }
	private void SetNivel(int nivel) { this.nivel = nivel; }

	public Partida() {
		this.nivel = 1;
		this.longCiempies = 4; //10
		this.numObstaculos = 5; //20
		this.puntos = 0;
	}

	public void Lanzar() {

		bool finDePartida = false;

		// Defino un objeto de cada tipo
		Nave nave = new Nave(40, 23);
		Disparo disparo = null;
		Ciempies ciempies = new Ciempies(longCiempies);
		Obstaculo []obstaculo = CrearObstaculos(numObstaculos);

		DibujarLados();
		DibujarPuntos();

		while (!finDePartida) {

			// 1. Dibujar elementos del juego
			nave.Dibujar();
			if(disparo != null) disparo.Dibujar();
			ciempies.Dibujar();
			for (int i = 0; i < obstaculo.Length; i++) { obstaculo[i].Dibujar();}

			// 5. Pausar juego
			System.Threading.Thread.Sleep(100);

			// 2. Mover nave con mejora 8.1 
			// TODO mejora 8.1
			if(Console.KeyAvailable ) MoverNave(nave, ref disparo);

			// 3. Mover ciempiés y disparo(s), si los hay
			ciempies.Mover(obstaculo);
			if (disparo != null) {
				Console.SetCursorPosition(disparo.GetX(), disparo.GetY());
				Console.Write(" ");
				if (disparo.GetY() == 0) disparo = null;
				else disparo.SetY(disparo.GetY() - 1);
			}
			// 4. Detectar colisiones y actualizar estado
			DetectarColisiones(ref disparo, obstaculo, ciempies, nave, ref finDePartida);
			
		}
	}
	private void DetectarColisiones(ref Disparo disparo, Obstaculo []obstaculo, Ciempies ciempies, Nave nave, 
	                                ref bool finDePartida) {
		// si la cabeza del ciempies ha llegado a la esquina inf izda o dcha --> fin partida
		if (ciempies.FinalDelCamino()) finDePartida = true;

		// Colisión disparo - ciempiés
		if (disparo != null) {
			ciempies.DetectarColisionesConDisparo(ref disparo);

			// Si el disparo es nulo porque había colisionado incremento los puntos
			if (disparo == null) {
				this.puntos += 50;
				Console.Beep();
				DibujarPuntos();
				if (ciempies.CiempiesDestruido()) {
					finDePartida = true;

					// Y paso al siguiente nivel. Mejora: 8.2
					SetNivel(++this.nivel);
					SetNumObstaculos(this.numObstaculos + 5);
					SetLongCiempies(this.longCiempies * 2);

					this.Lanzar();
				}
			}
		}

		// Si es el ciempies quien colisiona con la nave
		if (ciempies.DetectarColisionConNave(nave)) finDePartida = true;

		/* Si disparo colisiona con un obstáculo */
		for (int i = 0; i < obstaculo.Length && disparo != null; i++) {
			if (!obstaculo[i].GetDestruido() && 
			    obstaculo[i].GetX() == disparo.GetX() &&
			    obstaculo[i].GetY() == disparo.GetY()) {					

				// Borramos la posición del obstáculo con un espacio
				Console.SetCursorPosition(obstaculo[i].GetX(), obstaculo[i].GetY());
				Console.Write(" ");

				// Marcamos el obstáculo como destruido 
				obstaculo[i].SetDestruido(true);

				// ponemos el disparo a null
				disparo = null;

				//Incremento el contador de puntos
				this.puntos += 10;
				DibujarPuntos();
			}
		}
	}
	private void MoverNave(Nave nave, ref Disparo disparo) {

		ConsoleKeyInfo tecla = Console.ReadKey();
		Console.SetCursorPosition(nave.GetX(), nave.GetY());
		Console.Write(" ");

		// Muevo la nave controlando que no salga de la pantalla
		if (tecla.Key == ConsoleKey.LeftArrow && nave.GetX() > 20) nave.SetX(nave.GetX() - 1);
		else if (tecla.Key == ConsoleKey.RightArrow && nave.GetX() < 58) nave.SetX(nave.GetX() + 1);
		else if (tecla.Key == ConsoleKey.UpArrow && nave.GetY() > 20) nave.SetY(nave.GetY() - 1);
		else if (tecla.Key == ConsoleKey.DownArrow && nave.GetY() < 23) nave.SetY(nave.GetY() + 1);
		// Compruebo si pulsa espacio
		else if (tecla.Key == ConsoleKey.Spacebar && disparo == null) disparo = new Disparo(nave.GetX(), nave.GetY());


	}

	private void DibujarLados() {
		// Lo primero es borrar el terminal
		for (int i = 0; i < 80; i++)
			for (int j = 0; j < 24; j++) { 
				Console.SetCursorPosition(i, j);
				Console.Write(" ");
			}

		// Fondo de color gris
		Console.BackgroundColor = ConsoleColor.Black;

		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 24; j++) {
				Console.SetCursorPosition(i, j);
				Console.Write(" ");
			}
		}
		for (int i = 60; i <= 79; i++) {
			for (int j = 0; j < 24; j++)
			{
				Console.SetCursorPosition(i, j);
				Console.Write(" ");
			}
		}
		Console.ResetColor();
	}

	public Obstaculo[] CrearObstaculos(int tam) {
		Obstaculo []obstaculo = new Obstaculo[tam];

		Random r = new Random();
		// Posiciones del random
		int cY = 0 , cX = 0;
		// Array para las posiciones ocupadas
		bool[][] posOcupadas = new bool[20][];
		VaciarArray(posOcupadas);
		bool ocupada = true;

		for (int i = 0; i < tam; i++) {
			// no pueden estar en mismas coordenadas ni en coord adyac
			// coordenada Y debe estar entre 1 y 20
			// coordenada X debe estar entre 21 y 58
			while (ocupada) {
				cY = r.Next(1, 21);
				cX = r.Next(21, 59);
				// Compruebo si está ocupada o es adyacente
				ocupada = ComprobarPosicion(posOcupadas, cY, cX);
			}
			ocupada = posOcupadas[cY - 1][cX - 21] = true;

			obstaculo[i] = new Obstaculo(cX, cY);
		}						
		return obstaculo;
	}

	public bool ComprobarPosicion(bool [][]posiciones, int posX, int posY) {
		int x = posX - 1, y = posY - 21;

		if (posiciones[x][y] == true) return true;
		if (x > 0 && posiciones[x - 1][y] == true) return true;
		if (y > 0 && posiciones[x][y - 1] == true) return true;
		if (x < posiciones.Length - 1 && posiciones[x + 1][y] == true) return true;
		if (y < posiciones[x].Length - 1 && posiciones[x][y + 1] == true) return true;
		return false;
	}

	public void VaciarArray(bool[][] posOcupadas) {
		for (int i = 0; i < posOcupadas.Length; i++) {
			posOcupadas[i] = new bool[38];
			for (int j = 0; j < posOcupadas[i].Length; j++) posOcupadas[i][j] = false;
		}
	}
	private void DibujarPuntos() {
		
		Console.SetCursorPosition(63, 3);
		Console.Write("Nivel: {0}", this.nivel);

		Console.SetCursorPosition(63, 4);
		Console.Write("Puntos: {0}", this.puntos);
	}
}

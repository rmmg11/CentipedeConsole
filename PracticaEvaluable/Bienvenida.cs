using System;

/**
 * Clase Bienvenida
 * Esta clase se encarga de mostrar el rótulo el juego y decirle al usuario que pulse la barra espaciadora para jugar o 
 * Esc para salir
*/
public class Bienvenida {

	// Atributos
	private bool salir; // Para saber si el usuario quiere salir

	/* GETTER */
	public bool GetSalir() { return this.salir; }


	// Métodos
	public void EscribirCentrado(string texto)
	{
		if (texto.Length == 79) Console.WriteLine(texto);
		else if (texto.Length < 79)
		{
			int space = (80 - texto.Length) / 2;
			for (int i = 0; i < space; i++) Console.Write(" ");
			Console.WriteLine(texto);
		}
	}

	public void Lanzar() {
		// Imprimir rótulo del juego.
		Console.WriteLine();
		// Pongo de color amarillo los asteriscos
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		for (int i = 0; i < 79; i++) Console.Write("*");
		// Pongo de color verde el mensaje 
		Console.ForegroundColor = ConsoleColor.DarkGreen;
		EscribirCentrado("Bienvenido a CentipedeConsole");
		EscribirCentrado("Pulse Espacio para jugar o Esc para salir");
		// Pongo de color amarillo los asteriscos
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		for (int i = 0; i < 79; i++) Console.Write("*");
		Console.WriteLine();

		// Pedirle al usuario que pulse una tecla. Por ejemplo, espacio
		// para jugar, o Escape para salir. Poner el atributo "salir" a
		// true o false según lo que haya pulsado el usuario

		// Pongo de color verde el mensaje 
		Console.ForegroundColor = ConsoleColor.DarkGreen;

		Console.WriteLine("Para mover la nave de un lado a otro, utilice las flechas del cursor. Para disparar, " +
		                  "iniciar partida, o reanudarla tras perder una vida, pulse la barra espaciadora.");

		// Reseteo el color
		Console.ResetColor();

		ConsoleKeyInfo tecla = Console.ReadKey();
		if (tecla.Key == ConsoleKey.Escape) this.salir = true;
		else this.salir = false;
	}
}

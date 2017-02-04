using System;

/**
 * Clase Creditos
 * Esta clase se encarga de mostrar el copyright y pedir al usuario que pulse cualquier tecla
*/

public class Creditos {

	public void EscribirCentrado(string texto) {
		if (texto.Length == 79) Console.WriteLine(texto);
		else if (texto.Length < 79)
		{
			int space = (80 - texto.Length) / 2;
			for (int i = 0; i < space; i++) Console.Write(" ");
			Console.WriteLine(texto);
		}
	}

	public void Lanzar() {
		// Imprimir créditos. Por ejemplo, tu nombre

		Console.WriteLine();

		// Pongo de color amarillo los asteriscos
		Console.ForegroundColor = ConsoleColor.Yellow;
		for (int i = 0; i < 79; i++) Console.Write("*");

		// Pongo de color verde el texto
		Console.ForegroundColor = ConsoleColor.Green;

		EscribirCentrado("(C) IES San Vicente 2016 - 2017");
		EscribirCentrado("Pulse cualquier tecla para volver a la pantalla de bienvenida");
		for (int i = 0; i < 79; i++) Console.Write("*");
		// Pongo de color amarillo los asteriscos
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine();

		// Reseteo el color
		Console.ResetColor();

		// Pedirle al usuario que pulse cualquier tecla
		Console.ReadKey();
		Bienvenida b = new Bienvenida();
		b.Lanzar();

	}
}

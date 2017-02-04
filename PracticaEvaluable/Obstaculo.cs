using System;

public class Obstaculo: Sprite {

	private bool destruido;

	public bool GetDestruido() { return destruido; }
	public void SetDestruido(bool destruido) { this.destruido = destruido; }

	public Obstaculo(int x, int y) : base(x, y) {
		this.imagen = "T";
		destruido = false;
		this.color = ConsoleColor.DarkYellow;
	}

	public override void Dibujar() {
		if (!destruido) {
			Console.ForegroundColor = this.color;
			// Invocamos al método padre para que dibuje
			base.Dibujar();
			// Reseteamos los colores del terminal
			Console.ResetColor();
		}
	}

}

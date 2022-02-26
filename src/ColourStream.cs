using System.Drawing;



public static class ColourStream {
	private static readonly Color[] COLOURS = new Color[] {
		Color.FromArgb(85, 255, 85), // Lime
		Color.FromArgb(85, 255, 255), // Aqua
		Color.FromArgb(255, 255, 85), // Yellow
		Color.FromArgb(255, 170, 00), // Orange
		Color.FromArgb(255, 85, 255) // Pink
	};
	private static int index = 0;

	public static Color nextColour() {
		Color colour = COLOURS[index];

		index = (index + 1) % COLOURS.Count();

		return colour;
	}
}

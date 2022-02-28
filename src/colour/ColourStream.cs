public static class ColourStream {
	private static readonly Colour[] COLOURS = new Colour[] {
		Colour.WHITE,
		Colour.LIME,
		Colour.AQUA,
		Colour.YELLOW,
		Colour.ORANGE,
		Colour.PINK
	};
	private static int index = 0;

	public static Colour nextColour() {
		Colour colour = COLOURS[index];

		index = (index + 1) % COLOURS.Count();

		return colour;
	}
}

using H.Hooks;
using LedCSharp;



class LightKey {
	private Colour? currentColour = null;
	private Colour? upcomingColour = null;

	public readonly Circle circle;

	public readonly Key? eventKey;
	public readonly GKey? gKey;

	public LightKey(
		ImmutablePoint centre,
		Key? _eventKey,
		GKey? _gKey,
		double radius = 0.25
	) {
		circle = new Circle(
			centre,
			radius
		);

		eventKey = _eventKey;
		gKey = _gKey;
	}

	public void overwriteCurrentColour(Colour colour) {
		currentColour = colour;
	}

	public void mergeUpcomingColour(Colour colour) {
		if (upcomingColour == null) {
			upcomingColour = colour;
			return;
		}

		upcomingColour.alphaCompositeBehind(colour);
	}

	public void maySendColour() {
		if (gKey == null || upcomingColour == null) return;

		if (!Colour.equal(currentColour, upcomingColour)) {
			G.colour((GKey) gKey, upcomingColour);
			overwriteCurrentColour(upcomingColour);
		}

		upcomingColour = null;
	}
}

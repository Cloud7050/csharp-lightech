using H.Hooks;
using LedCSharp;



class LightKey {
	private const int MAX_SEND_SKIPS = (int) (AnimationManager.TARGET_FPS / 2d);
	private Colour currentColour = Colour.BLACK;
	private Colour? upcomingColour = null;
	private int skippedSends = 0;

	public readonly Circle circle;

	public readonly Key? eventKey;
	public readonly GKey? gKey;

	public readonly RippleType rippleType;

	public LightKey(
		ImmutablePoint centre,
		Key? eventKey,
		GKey? gKey,
		double radius
	): this(centre, eventKey, gKey, RippleType.BIG, radius) {}

	public LightKey(
		ImmutablePoint centre,
		Key? _eventKey,
		GKey? _gKey,
		RippleType _rippleType = RippleType.FADE,
		double radius = 0.25
	) {
		circle = new Circle(
			centre,
			radius
		);

		eventKey = _eventKey;
		gKey = _gKey;
		rippleType = _rippleType;
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
		if (gKey == null) return;

		if (
			upcomingColour != null
			&& !Colour.equal(currentColour, upcomingColour)
		) {
			skippedSends = 0;

			G.colour((GKey) gKey, upcomingColour);
			overwriteCurrentColour(upcomingColour);
		} else {
			// There was no upcoming colour,
			// or the current colour is already what we want shown.
			// By definition, the current colour should already be showing

			if (skippedSends <= MAX_SEND_SKIPS) skippedSends++;
			else {
				skippedSends = 0;

				// If the SDK is overwhelmed, some updates don't happen.
				// This periodic sending prevents stuck colours
				G.colour((GKey) gKey, currentColour);
			}
		}

		upcomingColour = null;
	}
}

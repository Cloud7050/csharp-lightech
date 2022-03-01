class Ripple {
	private static readonly double FADE_DISTANCE = 1.5;

	private static readonly double SECONDS_TO_TRAVEL_WIDTH = 1.25;

	private Circle ring;

	private Colour colour;

	public Ripple(
		ImmutablePoint centre,
		Colour? _colour = null
	) {
		ring = new Circle(centre);

		colour = _colour ?? ColourStream.nextColour();
	}

	private double alphaIntervalFor(Circle lightCircle) {
		double ringToLightCentre = ring.circumferenceDistanceTo(lightCircle.centre);
		double lengthOutsideLightCircle = ringToLightCentre - lightCircle.radius;

		if (lengthOutsideLightCircle <= 0) return 1;

		if (lengthOutsideLightCircle > FADE_DISTANCE) return 0;

		double proximityToDimmestArc = FADE_DISTANCE - lengthOutsideLightCircle;
		return proximityToDimmestArc / FADE_DISTANCE;
	}

	public bool exceedsKeyboard() {
		Circle boundingCircle = ring.clone();
		boundingCircle.radius -= FADE_DISTANCE;

		//TODO
		return boundingCircle.contains(LightKeyManager.TOP_LEFT)
			&& boundingCircle.contains(LightKeyManager.TOP_RIGHT)
			&& boundingCircle.contains(LightKeyManager.BOTTOM_LEFT)
			&& boundingCircle.contains(LightKeyManager.BOTTOM_RIGHT);
	}

	public Colour newColourFor(LightKey lightKey) {
		Colour newColour = colour.clone();
		newColour.setAlphaInterval(
			alphaIntervalFor(lightKey.circle)
		);
		return newColour;
	}

	public void expandRadius() {
		double oneSecondDistance = LightKeyManager.TOTAL_WIDTH * (1 / SECONDS_TO_TRAVEL_WIDTH);
		ring.radius += oneSecondDistance / AnimationManager.PERFECT_FPS;
	}
}

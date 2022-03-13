class Ripple {
	private const double FADE_DISTANCE = LightKeyManager.KEY_SIZE * 1.5;

	private const double SECONDS_TO_TRAVEL_WIDTH = 1.5;

	private Circle ring;

	private Colour colour;

	public Ripple(ImmutablePoint centre) {
		ring = new Circle(centre);

		colour = ColourStream.nextColour();
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
		double oneSecondDistance = LightKeyManager.WIDTH * (1d / SECONDS_TO_TRAVEL_WIDTH);
		ring.radius += oneSecondDistance / AnimationManager.TARGET_FPS;
	}
}

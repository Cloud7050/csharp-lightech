class Ripple {
	private static readonly double SECONDS_TO_TRAVEL_WIDTH = 1.25;

	private static readonly double FADE_DISTANCE = 1.5;
	private static readonly double INTENSITY_SNAP = 0.9;

	private Circle ring;

	private Colour colour;

	public Ripple(
		Circle _ring,
		Colour _colour
	) {
		ring = _ring;
		colour = _colour;
	}

	public void expandRadius() {
		double oneSecondDistance = KeyLightManager.TOTAL_WIDTH * (1 / SECONDS_TO_TRAVEL_WIDTH);
		ring.radius += oneSecondDistance / AnimationManager.PERFECT_FPS;
	}

	public double alphaIntervalFor(LightKey keyLight) {
		Circle lightCircle = keyLight.lightCircle;

		double ringToLightCentre = ring.circumferenceDistanceTo(lightCircle.centre);
		double distanceOutsideLightCircle = ringToLightCentre - lightCircle.radius;

		double intensity;
		if (distanceOutsideLightCircle <= 0) intensity = 1;
		else {
			double validDistance = FADE_DISTANCE - distanceOutsideLightCircle;

			if (validDistance <= 0) intensity = 0;
			else {
				intensity = validDistance / FADE_DISTANCE;

				if (intensity > INTENSITY_SNAP) intensity = 1;
				else intensity /= INTENSITY_SNAP;
			}
		}

		return intensity;
	}
}

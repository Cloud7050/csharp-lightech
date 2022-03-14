using H.Hooks;



abstract class Ripple {
	protected bool isStillDown = true;

	protected double alphaMultiplier = 1;

	protected LightKey lightKey;

	protected Circle ring;
	protected Colour colour;

	protected double fadeDistance;

	public Ripple(
		LightKey _lightKey,
		double _fadeDistance
	) {
		lightKey = _lightKey;
		ring = new Circle(_lightKey.circle.centre);
		fadeDistance = _fadeDistance;

		colour = ColourStream.nextColour();
	}

	private double alphaIntervalFor(Circle lightCircle) {
		double ringToLightCentre = ring.circumferenceDistanceTo(lightCircle.centre);
		double lengthOutsideLightCircle = ringToLightCentre - lightCircle.radius;

		if (lengthOutsideLightCircle <= 0) return 1;

		if (lengthOutsideLightCircle > fadeDistance) return 0;

		double proximityToDimmestArc = fadeDistance - lengthOutsideLightCircle;
		return proximityToDimmestArc / fadeDistance;
	}

	public bool isForEventKey(Key eventKey) {
		return lightKey.eventKey == eventKey;
	}

	public void onThisKeyUp() {
		if(!isStillDown) return;

		isStillDown = false;
		onNoLongerDown();
	}

	public Colour onGetColour(LightKey lightKey) {
		Colour newColour = colour.clone();
		newColour.setAlphaInterval(
			alphaIntervalFor(lightKey.circle) * alphaMultiplier
		);
		return newColour;
	}

	public virtual void onNoLongerDown() {}

	public virtual void onFrameStart() {}

	public virtual bool onFrameEnd() {
		return false;
	}
}

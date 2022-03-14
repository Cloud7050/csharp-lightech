class BigRipple : Ripple {
	private const double SECONDS_TO_TRAVEL_WIDTH = 1.25;

	private const double FADE_DISTANCE = LightKeyManager.KEY_SIZE * 1.25;

	public BigRipple(LightKey lightKey) : base(lightKey, FADE_DISTANCE) {}

	public override bool onFrameEnd() {
		// Expand radius
		double oneSecondDistance = LightKeyManager.WIDTH / SECONDS_TO_TRAVEL_WIDTH;
		ring.radius += oneSecondDistance / AnimationManager.TARGET_FPS;

		// Remove if exceeds keyboard
		Circle boundingCircle = ring.clone();
		boundingCircle.radius -= FADE_DISTANCE;
		return boundingCircle.contains(LightKeyManager.TOP_LEFT)
			&& boundingCircle.contains(LightKeyManager.TOP_RIGHT)
			&& boundingCircle.contains(LightKeyManager.BOTTOM_LEFT)
			&& boundingCircle.contains(LightKeyManager.BOTTOM_RIGHT);
	}
}

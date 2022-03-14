class FadeRipple : Ripple {
	private const double RADIUS_START = LightKeyManager.KEY_SIZE;
	private const double RADIUS_END = LightKeyManager.KEY_SIZE * 3;
	private const int RADIUS_MAX_FRAMES = (int) (AnimationManager.TARGET_FPS * 0.6);
	private const int RADIUS_EXPONENT = 5;

	private const double FADE_START = 1;
	private const double FADE_END = 2.5;
	private const int FADE_FRAMES = (int) (AnimationManager.TARGET_FPS * 0.4);
	private const int FADE_EXPONENT = 4;

	private int upcomingRadiusFrame = 0;
	private int upcomingFadeFrame = 0;

	public FadeRipple(LightKey lightKey) : base(lightKey, FADE_START) {}

	private void mayExpandRadius() {
		if (upcomingRadiusFrame >= RADIUS_MAX_FRAMES) return;

		double frameProgress = upcomingRadiusFrame / (double) (RADIUS_MAX_FRAMES - 1);
		// Decreasing deceleration
		double exponential = Math.Pow(1 - frameProgress, RADIUS_EXPONENT);
		// Starting at 1 (second value) to 0 (first value)
		ring.radius = MathUtilities.lerp(RADIUS_END, RADIUS_START, exponential);

		upcomingRadiusFrame++;
	}

	private void increaseFade() {
		double frameProgress = upcomingFadeFrame / (double) (FADE_FRAMES - 1);
		// Decreasing deceleration
		double exponential = Math.Pow(1 - frameProgress, FADE_EXPONENT);

		// Starting at 1 (second value) to 0 (first value)
		fadeDistance = MathUtilities.lerp(FADE_END, FADE_START, exponential);

		alphaMultiplier = exponential;

		upcomingFadeFrame++;
	}

	public override void onFrameStart() {
		mayExpandRadius();

		if (!isStillDown) increaseFade();
	}

	public override bool onFrameEnd() {
		return upcomingFadeFrame >= FADE_FRAMES;
	}
}

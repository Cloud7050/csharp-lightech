class FadeRipple : Ripple {
	private const double RADIUS_START = LightKeyManager.KEY_SIZE;
	private const double RADIUS_END = LightKeyManager.KEY_SIZE * 3;
	private const double RADIUS_MAX_FRAMES = AnimationManager.TARGET_FPS * 0.6;
	private const double RADIUS_EXPONENT = 5;

	private const double FADE_START = 1;
	private const double FADE_END = 2;
	private const double FADE_FRAMES = AnimationManager.TARGET_FPS * 0.4;
	private const double FADE_EXPONENT = 4;

	private double radiusFrames = 0;
	private double fadeFrames = 0;

	public FadeRipple(LightKey lightKey) : base(lightKey, FADE_START) {}

	private void mayExpandRadius() {
		if (radiusFrames >= RADIUS_MAX_FRAMES) return;

		double frameProgress = radiusFrames / RADIUS_MAX_FRAMES;
		// Decreasing deceleration
		double exponential = Math.Pow(1 - frameProgress, RADIUS_EXPONENT);
		// Starting at 1 (second value) to 0 (first value)
		ring.radius = MathUtilities.lerp(RADIUS_END, RADIUS_START, exponential);

		radiusFrames++;
	}

	private void increaseFade() {
		double frameProgress = fadeFrames / FADE_FRAMES;
		// Decreasing deceleration
		double exponential = Math.Pow(1 - frameProgress, FADE_EXPONENT);

		// Starting at 1 (second value) to 0 (first value)
		fadeDistance = MathUtilities.lerp(FADE_END, FADE_START, exponential);

		alphaMultiplier = exponential;

		fadeFrames++;
	}

	public override bool onFrameEnd() {
		mayExpandRadius();

		if (!isStillDown) increaseFade();

		return fadeFrames >= FADE_FRAMES;
	}
}

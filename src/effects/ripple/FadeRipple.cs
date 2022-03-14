class FadeRipple : Ripple {
	private const double SLOWEST_SECONDS = 1;
	private const double UP_MULTIPLIER = 2;
	private const double EXPONENT = 2.5;

	private const double FADE_THRESHOLD = 0.5;
	private const double FADE_DISTANCE_START = LightKeyManager.KEY_SIZE;
	private const double FADE_DISTANCE_END = LightKeyManager.KEY_SIZE * 2;

	private const double SPEED_START = (LightKeyManager.KEY_SIZE * 30) / AnimationManager.TARGET_FPS;

	private double linearFactor = 1;

	public FadeRipple(LightKey lightKey) : base(lightKey, FADE_DISTANCE_START) {}

	private void addLinearFactor() {
		double thisFrameReduction = (1 / SLOWEST_SECONDS) / AnimationManager.TARGET_FPS;
		if (!isStillDown) thisFrameReduction *= UP_MULTIPLIER;

		linearFactor -= thisFrameReduction;
	}

	private double getProgressFactor() {
		double exponentialFactor = Math.Pow(linearFactor, EXPONENT);
		return Math.Clamp(exponentialFactor, 0, 1);
	}

	private double getFadeFactor(double progressFactor) {
		return progressFactor > FADE_THRESHOLD
			? 1
			: Math.Clamp(
				progressFactor / FADE_THRESHOLD,
				0,
				1
			);
	}

	private double lerp(double start, double end, double factor) {
		double difference = end - start;
		return start + (difference * factor);
	}

	public override bool onFrameEnd() {
		addLinearFactor();
		if (linearFactor < 0) return true;

		Console.WriteLine("");
		Console.WriteLine("LF "+linearFactor);
		double progressFactor = getProgressFactor();
		Console.WriteLine("SF "+progressFactor);

		// Expand radius
		double currentSpeed = SPEED_START * progressFactor;
		ring.radius += currentSpeed;

		// Update fade & alpha
		double fadeFactor = getFadeFactor(progressFactor);
		Console.WriteLine("FF "+fadeFactor);
		fadeDistance = lerp(FADE_DISTANCE_END, FADE_DISTANCE_START, fadeFactor);
		alphaMultiplier = fadeFactor;

		return false;
	}
}

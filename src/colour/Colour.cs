class Colour {
	public const int MIN = 0x00;
	public const int LOW = 0x55;
	public const int MEDIUM = 0x80;
	public const int HIGH = 0xAA;
	public const int MAX = 0xFF;

	public static readonly Colour WHITE = new Colour(MAX);
	public static readonly Colour LIME = new Colour(LOW, MAX, LOW);
	public static readonly Colour AQUA = new Colour(LOW, MAX, MAX);
	public static readonly Colour YELLOW = new Colour(MAX, MAX, LOW);
	public static readonly Colour ORANGE = new Colour(MAX, HIGH, MIN);
	public static readonly Colour PINK = new Colour(MAX, LOW, MAX);
	public static readonly Colour BLACK = new Colour(MIN);

	public int red = MIN;
	public int green = MIN;
	public int blue = MIN;
	public int alpha = MIN;

	public Colour(int component) : this(component, component, component) {}

	public Colour(int red, int green, int blue) : this(red, green, blue, MAX) {}

	public Colour(
		int _red,
		int _green,
		int _blue,
		int _alpha
	) {
		red = _red;
		green = _green;
		blue = _blue;
		alpha = _alpha;
	}

	private static double toInterval(int component) {
		return ((double) component) / MAX;
	}

	private static int fromInterval(double interval) {
		return MathUtilities.round(interval * MAX);
	}

	private static double toPercentageDouble(int component) {
		double componentInterval = toInterval(component);
		return componentInterval * 100;
	}

	private static int toPercentage(int component) {
		double componentPercentage = toPercentageDouble(component);
		return MathUtilities.round(componentPercentage);
	}

	private static int alphaCompositeComponent(
		int frontComponent,
		int backComponent,
		double frontAlphaInterval,
		double backAlphaInterval,
		double finalAlphaInterval
	) {
		return MathUtilities.round(
			(
				(frontComponent * frontAlphaInterval) + (
					backComponent * backAlphaInterval * (1 - frontAlphaInterval)
				)
			) / finalAlphaInterval
		);
	}

	public static bool equal(Colour? c1, Colour? c2) {
		if (c1 == null && c2 == null) return true;

		return c1?.red == c2?.red
			&& c1?.green == c2?.green
			&& c1?.blue == c2?.blue
			&& c1?.alpha == c2?.alpha;
	}

	private int toPercentageDimmed(int component) {
		double componentPercentage = toPercentageDouble(component);
		double alphaInterval = getAlphaInterval();
		return MathUtilities.round(componentPercentage * alphaInterval);
	}

	public Colour clone() {
		return new Colour(
			red,
			green,
			blue,
			alpha
		);
	}

	public double getAlphaInterval() {
		return toInterval(alpha);
	}

	public void setAlphaInterval(double alphaInterval) {
		alpha = fromInterval(alphaInterval);
	}

	public int getPercentageDimmedRed() {
		return toPercentageDimmed(red);
	}

	public int getPercentageDimmedGreen() {
		return toPercentageDimmed(green);
	}

	public int getPercentageDimmedBlue() {
		return toPercentageDimmed(blue);
	}

	public void alphaCompositeBehind(Colour front) {
		double frontAlphaInterval = front.getAlphaInterval();
		double backAlphaInterval = getAlphaInterval();
		double finalAlphaInterval = frontAlphaInterval + (backAlphaInterval * (1 - frontAlphaInterval));

		red = alphaCompositeComponent(
			front.red,
			red,
			frontAlphaInterval,
			backAlphaInterval,
			finalAlphaInterval
		);
		green = alphaCompositeComponent(
			front.green,
			green,
			frontAlphaInterval,
			backAlphaInterval,
			finalAlphaInterval
		);
		blue = alphaCompositeComponent(
			front.blue,
			blue,
			frontAlphaInterval,
			backAlphaInterval,
			finalAlphaInterval
		);
		alpha = fromInterval(finalAlphaInterval);
	}
}

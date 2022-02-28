class Colour {
	public static readonly int MIN = 0x00;
	public static readonly int LOW = 0x55;
	public static readonly int MEDIUM = 0x80;
	public static readonly int HIGH = 0xAA;
	public static readonly int MAX = 0xFF;

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

	public Colour(
		int red,
		int green,
		int blue
	) : this(
		red,
		green,
		blue,
		MAX
	) {}

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

	private static int round(double number) {
		return (int) Math.Round(
			number,
			MidpointRounding.AwayFromZero
		);
	}

	private static double toInterval(int component) {
		return ((double) component) / MAX;
	}

	private static int fromInterval(double interval) {
		return round(interval * MAX);
	}

	private static double toPercentageDouble(int component) {
		double componentInterval = toInterval(component);
		return componentInterval * 100;
	}

	private static int toPercentage(int component) {
		double componentPercentage = toPercentageDouble(component);
		return round(componentPercentage);
	}

	private static int alphaCompositeComponent(
		int frontComponent,
		int backComponent,
		double frontAlphaInterval,
		double backAlphaInterval,
		double finalAlphaInterval
	) {
		return round(
			(
				(frontComponent * frontAlphaInterval) + (
					backComponent * backAlphaInterval * (1 - frontAlphaInterval)
				)
			) / finalAlphaInterval
		);
	}

	private int toPercentageDimmed(int component) {
		double componentPercentage = toPercentageDouble(component);
		double alphaInterval = getAlphaInterval();
		return round(componentPercentage * alphaInterval);
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

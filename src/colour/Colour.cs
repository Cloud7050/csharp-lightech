class Colour {
	public static readonly int MIN = 0x00;
	public static readonly int LOW = 0x55;
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

	private int round(double number) {
		return (int) Math.Round(
			number,
			MidpointRounding.AwayFromZero
		);
	}

	private double toInterval(int component) {
		return ((double) component) / MAX;
	}

	private double toPercentageDouble(int component) {
		double componentInterval = toInterval(component);
		return componentInterval * 100;
	}

	private int toPercentage(int component) {
		double componentPercentage = toPercentageDouble(component);
		return round(componentPercentage);
	}

	private int toPercentageDimmed(int component) {
		double componentPercentage = toPercentageDouble(component);
		double alphaInterval = getAlphaInterval();
		return round(componentPercentage * alphaInterval);
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
}

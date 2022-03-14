static class MathUtilities {
	public static int round(double number) {
		return (int) Math.Round(
			number,
			MidpointRounding.AwayFromZero
		);
	}

	public static double lerp(double start, double end, double factor) {
		factor = Math.Clamp(factor, 0, 1);
		double difference = end - start;
		return start + (difference * factor);
	}
}

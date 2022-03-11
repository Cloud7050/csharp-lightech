sealed class ImmutablePoint {
	public readonly double x;
	public readonly double y;

	public ImmutablePoint(
		double _x,
		double _y
	) {
		x = _x;
		y = _y;
	}

	public double distanceTo(ImmutablePoint other) {
		return Math.Sqrt(
			Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2)
		);
	}
}

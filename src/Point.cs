class Point {
	public double x;
	public double y;

	public Point(
		double _x,
		double _y
	) {
		x = _x;
		y = _y;
	}

	public double distanceTo(Point other) {
		return Math.Sqrt(
			Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2)
		);
	}
}

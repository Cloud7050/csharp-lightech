class Circle {
	public readonly Point centre;

	public double radius;

	public Circle(
		Point _centre,
		double _radius = 0
	) {
		centre = _centre;
		radius = _radius;
	}

	public double circumferenceDistanceTo(Point point) {
		double distanceFromCentre = point.distanceTo(centre);
		return Math.Abs(distanceFromCentre - radius);
	}
}

using System.Transactions;

class Circle {
	public readonly ImmutablePoint centre;

	public double radius;

	public Circle(
		ImmutablePoint _centre,
		double _radius = 0
	) {
		centre = _centre;
		radius = _radius;
	}

	public Circle clone() {
		return new Circle(centre, radius);
	}

	public double circumferenceDistanceTo(ImmutablePoint point) {
		double distanceFromCentre = point.distanceTo(centre);
		return Math.Abs(distanceFromCentre - radius);
	}

	public bool contains(ImmutablePoint point) {
		return centre.distanceTo(point) <= radius;
	}
}

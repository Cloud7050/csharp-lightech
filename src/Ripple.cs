using System.Numerics;



public class Ripple {
	public readonly Vector2 centre;
	public double radius = 0;

	public Ripple(
		Vector2 _centre
	) {
		centre = _centre;
	}

	public double distanceToCircumference(Vector2 point) {
		double distanceToCentre = (point - centre).Length();
		return Math.Abs(distanceToCentre - radius);
	}
}

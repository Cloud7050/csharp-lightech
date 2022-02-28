using System.Drawing;
using System.Numerics;



public class Ripple {
	public readonly Vector2 centre;

	public readonly Color colour;

	public double radius = 0;

	public Ripple(
		Vector2 _centre,
		Color _colour
	) {
		centre = _centre;
		colour = _colour;
	}

	public double distanceToCircumference(Vector2 point) {
		double distanceToCentre = (point - centre).Length();
		return Math.Abs(distanceToCentre - radius);
	}
}

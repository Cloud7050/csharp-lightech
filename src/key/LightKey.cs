using H.Hooks;
using LedCSharp;



class LightKey {
	public readonly Circle circle;

	public readonly Key? eventKey;
	public readonly GKey? gKey;

	public LightKey(
		ImmutablePoint centre,
		Key? _eventKey,
		GKey? _gKey,
		double radius = 0.25
	) {
		circle = new Circle(
			centre,
			radius
		);

		eventKey = _eventKey;
		gKey = _gKey;
	}
}

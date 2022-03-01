using H.Hooks;



using N = LedCSharp.keyboardNames;



class LightKey {
	public readonly Circle circle;

	public readonly Key? eventKey;
	public readonly N? gKey;

	public LightKey(
		Point centre,
		Key? _eventKey,
		N? _gKey,
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

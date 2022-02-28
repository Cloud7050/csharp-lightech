using H.Hooks;



using N = LedCSharp.keyboardNames;



class LightKey {
	public readonly Point location;

	public readonly Key? eventKey;
	public readonly N? gKey;

	public LightKey(
		Point _location,
		Key? _eventKey,
		N? _gKey
	) {
		location = _location;
		eventKey = _eventKey;
		gKey = _gKey;
	}
}

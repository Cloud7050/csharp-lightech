using System.Numerics;
using H.Hooks;



using N = LedCSharp.keyboardNames;



class KeyLight {
	public readonly Vector2 location;

	public readonly Key? hookKey;
	public readonly N lightKey;

	public KeyLight(
		Vector2 _location,
		Key? _hookKey,
		N _lightKey
	) {
		location = _location;
		hookKey = _hookKey;
		lightKey = _lightKey;
	}
}

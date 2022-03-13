using System.Collections.Immutable;
using H.Hooks;



sealed class ImmutableKeyEvent {
	private static readonly ImmutableList<Key> IGNORED_KEYS = ImmutableList<Key>.Empty
		.Add(Key.Shift)
		.Add(Key.Control)
		.Add(Key.Alt);

	private static List<Key> downKeys = new List<Key>();

	public readonly bool isDown;
	public readonly KeyboardEventArgs data;

	public ImmutableKeyEvent(
		bool _isDown,
		KeyboardEventArgs _data
	) {
		isDown = _isDown;
		data = _data;
	}

	private static bool testIgnore(Key eventKey) {
		bool ignore = IGNORED_KEYS.Contains(eventKey);
		if (ignore) Console.WriteLine($">>> Ignore: {eventKey}");
		return ignore;
	}

	private void down() {
		foreach (Key eventKey in data.Keys.Values) {
			if (testIgnore(eventKey)) {
				Console.WriteLine($">>> DOWN ignore: {eventKey}");
				continue;
			}

			if (downKeys.Contains(eventKey)) {
				Console.WriteLine($">>> DOWN existing: {eventKey}");
				continue;
			};

			downKeys.Add(eventKey);
			EffectManager.onKeyDown(eventKey);
			Console.WriteLine($">>> DOWN fire: {eventKey}");
		}
	}

	private void up() {
		foreach (Key eventKey in data.Keys.Values) {
			if (testIgnore(eventKey)) {
				Console.WriteLine($">>> UP ignore: {eventKey}");
				continue;
			}

			downKeys.Remove(eventKey);
			EffectManager.onKeyUp(eventKey);
			Console.WriteLine($">>> UP fire: {eventKey}");
		}
	}

	public void run() {
		if (isDown) down();
		else up();
	}
}

using System.Collections.Generic;
using H.Hooks;



static class KeyEventManager {
	private static readonly List<Key> IGNORED_KEYS = new List<Key> {
		Key.Shift,
		Key.Control,
		Key.Alt
	};

	private static List<Key> downKeys = new List<Key>();

	private static bool testIgnore(Key eventKey) {
		bool ignore = IGNORED_KEYS.Contains(eventKey);
		if (ignore) Console.WriteLine($">>> Ignore: {eventKey}");
		return ignore;
	}

	private static void downHandler(object? sender, KeyboardEventArgs data) {
		Console.WriteLine($">>> Raw Down: {data}");

		foreach (Key eventKey in data.Keys.Values) {
			if (testIgnore(eventKey)) continue;

			if (downKeys.Contains(eventKey)) {
				Console.WriteLine($">>> Already Down: {eventKey}");
				continue;
			};

			downKeys.Add(eventKey);
			Console.WriteLine($">>> Add: {eventKey}");

			EffectManager.onKeyDown(eventKey);
			Console.WriteLine($">>> Fire Down: {eventKey}");
		}
	}

	private static void upHandler(object? sender, KeyboardEventArgs data) {
		Console.WriteLine($">>> Raw Up: {data}");

		foreach (Key eventKey in data.Keys.Values) {
			if (testIgnore(eventKey)) continue;

			EffectManager.onKeyUp(eventKey);
			Console.WriteLine($">>> Fire Up: {eventKey}");

			while (downKeys.Contains(eventKey)) {
				downKeys.Remove(eventKey);
				Console.WriteLine($">>> Remove: {eventKey}");
			}
		}
	}

	public static void onInitialise() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		hook.Down += downHandler;
		hook.Up += upHandler;

		hook.Start();
	}
}

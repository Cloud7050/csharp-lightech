static class Lightech {
	private static readonly List<Key> downKeys = new List<Key>();

	public static void Main(string[] args) {
		AnimationManager.onInitialise();

		register();

		AnimationManager.onAnimate();

		AnimationManager.onExit();
	}

	private static void register() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		EventHandler<KeyboardEventArgs> downLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"v {data}");
		};
		EventHandler<KeyboardEventArgs> upLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"^ {data}");
		};
		hook.Down += downLogger;
		hook.Up += upLogger;

		EventHandler<KeyboardEventArgs> downNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				if (downKeys.Contains(key)) continue;

				downKeys.Add(key);
				Console.WriteLine($"ADD {key}");
			}
		};
		EventHandler<KeyboardEventArgs> upNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				while (downKeys.Contains(key)) {
					downKeys.Remove(key);
					Console.WriteLine($"REM {key}");
				}
			}
		};
		hook.Down += downNonce;
		hook.Up += upNonce;

		hook.Start();
	}
}

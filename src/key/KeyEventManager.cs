using System.Collections.Concurrent;
using H.Hooks;



static class KeyEventManager {
	private static BlockingCollection<ImmutableKeyEvent> keyEvents = new BlockingCollection<ImmutableKeyEvent>();

	private static void downHandler(object? sender, KeyboardEventArgs data) {
		keyEvents.Add(
			new ImmutableKeyEvent(true, data)
		);
	}

	private static void upHandler(object? sender, KeyboardEventArgs data) {
		keyEvents.Add(
			new ImmutableKeyEvent(false, data)
		);
	}

	public static void onInitialise() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		hook.Down += downHandler;
		hook.Up += upHandler;

		hook.Start();
	}

	// This is fine
	public static void onFire() {
		ImmutableKeyEvent? keyEvent = null;
		while (keyEvents.TryTake(out keyEvent)) {
			keyEvent.run();
		}
	}
}

static class AnimationManager {
	public static readonly double TARGET_FPS = 50;
	private static readonly TimeSpan FRAME_INTERVAL = TimeSpan.FromSeconds(1d / TARGET_FPS);
	private static readonly TimeSpan MINIMUM_SLEEP = TimeSpan.FromMilliseconds(1);

	private static readonly TimeSpan CONNECTION_INTERVAL = TimeSpan.FromSeconds(15);

	private static bool connected = false;

	private static void awaitConnection() {
		bool success = G.dummyCommand();
		if (success) return;

		while (true) {
			G.reconnect();
			success = G.dummyCommand();

			if (success) {
				Console.WriteLine(">>> Connected ✅");
				connected = true;

				EffectManager.onWake();

				return;
			};

			Console.WriteLine(">>> Connection Failed ⚠️");
			connected = false;
			Thread.Sleep(CONNECTION_INTERVAL);
		}
	}

	public static bool isConnected() {
		return connected;
	}

	public static void onInitialise() {
		awaitConnection();
	}

	public static void onAnimate() {
		// Loop frames
		while (true) {
			awaitConnection();

			long startTicks = DateTime.Now.Ticks;
			EffectManager.onFrame();
			long endTicks = DateTime.Now.Ticks;

			TimeSpan busyTimespan = TimeSpan.FromTicks(endTicks - startTicks);
			TimeSpan remainingSleep = FRAME_INTERVAL.Subtract(busyTimespan);

			Thread.Sleep(
				TimeSpan.Compare(remainingSleep, MINIMUM_SLEEP) > 0
					? remainingSleep
					: MINIMUM_SLEEP
			);
		}
	}
}

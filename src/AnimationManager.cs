public static class AnimationManager {
	public static readonly double PERFECT_FPS = 240;
	private static readonly TimeSpan FRAME_SLEEP = TimeSpan.FromSeconds(1d / PERFECT_FPS);

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
				return;
			};

			Console.WriteLine(">>> Connection Failed ⚠️");
			connected = false;
			Thread.Sleep(CONNECTION_INTERVAL);
		}
	}

	private static void loopFrame() {
		awaitConnection();

		doFrame();

		Thread.Sleep(FRAME_SLEEP);
		loopFrame();
	}
	private static void doFrame() {
		//TODO Actually do effect
		G.colourGlobally(
			Colour.CYAN
		);
	}

	public static bool isConnected() {
		return connected;
	}

	public static void onStart() {
		awaitConnection();
	}

	public static void onAnimate() {
		//TODO Make its own effect
		G.colourGlobally(
			// new Colour(0x55, 0xFF, 0x55)
			Colour.LIME
		);

		loopFrame();
	}

	public static void onEnd() {
		G.disconnect();
	}
}

static class AnimationManager {
	//TODO As TARGET_FPS
	public static readonly double PERFECT_FPS = 240;
	//TODO As FRAME_INTERVAL
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

		EffectManager.onFrame();

		Thread.Sleep(FRAME_SLEEP);
		loopFrame();
	}

	//TODO key events only while connected
	public static bool isConnected() {
		return connected;
	}

	public static void onInitialise() {
		awaitConnection();
	}

	public static void onAnimate() {
		EffectManager.onStart();

		loopFrame();
	}

	public static void onExit() {
		G.disconnect();
	}
}

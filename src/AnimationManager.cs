using G = LedCSharp.LogitechGSDK;



public static class AnimationManager {
	public static readonly double PERFECT_FPS = 240;
	private static readonly TimeSpan FRAME_SLEEP = TimeSpan.FromSeconds(1d / PERFECT_FPS);

	private static readonly TimeSpan CONNECTION_INTERVAL = TimeSpan.FromSeconds(15);

	private static bool connected = false;

	private static void awaitConnection() {
		bool success = dummyCommand();
		if (success) return;

		while (true) {
			disconnect();
			G.LogiLedInitWithName("Lightech ☁");
			success = dummyCommand();

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
	private static bool dummyCommand() {
		return G.LogiLedSetLightingForKeyWithScanCode(7050, 0, 0, 0);
	}

	private static void disconnect() {
		G.LogiLedShutdown();
	}

	private static void loopFrame() {
		awaitConnection();

		//TODO Actually do effect
		G.LogiLedSetLighting(0, 100, 100);

		Thread.Sleep(FRAME_SLEEP);
		loopFrame();
	}

	public static bool isConnected() {
		return connected;
	}

	public static void connect() {
		awaitConnection();
	}

	public static void start() {
		//TODO Make its own effect
		G.LogiLedSetLighting(33, 100, 33);

		loopFrame();
	}

	public static void end() {
		disconnect();
	}
}

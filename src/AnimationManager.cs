static class AnimationManager {
	private static readonly TimeSpan FRAME_INTERVAL = TimeSpan.FromSeconds(1d / TARGET_FPS);
	private static readonly TimeSpan MINIMUM_SLEEP = TimeSpan.FromMilliseconds(1);

	private static readonly TimeSpan CONNECTION_INTERVAL = TimeSpan.FromSeconds(15);

	private static bool _isConnected = false;

	public const double TARGET_FPS = 60;

	private static async Task awaitConnection() {
		bool success = G.dummyCommand();
		if (success) return;

		while (true) {
			G.reconnect();
			success = G.dummyCommand();

			if (success) {
				Console.WriteLine(">>> Connected ✅");
				_isConnected = true;

				EffectManager.onWake();

				return;
			};

			Console.WriteLine(">>> Connection Failed ⚠️");
			_isConnected = false;
			await Task.Delay(CONNECTION_INTERVAL);
		}
	}

	public static bool isConnected() {
		return _isConnected;
	}

	public static async Task onInitialise() {
		await awaitConnection();
	}

	public static async Task onAnimate() {
		// Loop frames
		while (true) {
			await awaitConnection();

			long startTicks = DateTime.Now.Ticks;
			EffectManager.onFrame();
			long endTicks = DateTime.Now.Ticks;

			TimeSpan busyTimespan = TimeSpan.FromTicks(endTicks - startTicks);
			TimeSpan remainingSleep = FRAME_INTERVAL.Subtract(busyTimespan);

			await Task.Delay(
				TimeSpan.Compare(remainingSleep, MINIMUM_SLEEP) > 0
					? remainingSleep
					: MINIMUM_SLEEP
			);
		}
	}
}

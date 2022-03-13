static class AnimationManager {
	private static readonly TimeSpan FRAME_INTERVAL = TimeSpan.FromSeconds(1d / TARGET_FPS);
	private static readonly TimeSpan MINIMUM_SLEEP = TimeSpan.FromMilliseconds(1);

	private static readonly TimeSpan CONNECTION_INTERVAL = TimeSpan.FromSeconds(15);

	public const double TARGET_FPS = 60;

	private static async Task awaitConnection() {
		bool success = G.dummyCommand();
		if (success) return;

		while (true) {
			G.reconnect();
			success = G.dummyCommand();

			if (success) {
				Console.WriteLine(">>> Connected");

				EffectManager.onWake();
				return;
			};

			Console.WriteLine(">>> Connection Failed");
			await Waiter.wait(CONNECTION_INTERVAL);
		}
	}

	public static async Task onAnimate() {
		KeyEventManager.onInitialise();

		while (true) {
			await awaitConnection();

			long startTicks = DateTime.Now.Ticks;
			KeyEventManager.onFire();
			EffectManager.onFrame();
			long endTicks = DateTime.Now.Ticks;

			TimeSpan busyTimespan = TimeSpan.FromTicks(endTicks - startTicks);
			TimeSpan remainingSleep = FRAME_INTERVAL.Subtract(busyTimespan);

			await Waiter.wait(
				TimeSpan.Compare(remainingSleep, MINIMUM_SLEEP) > 0
					? remainingSleep
					: MINIMUM_SLEEP
			);
		}
	}
}

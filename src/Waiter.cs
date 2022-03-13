static class Waiter {
	private static double getCurrentMilliseconds() {
		return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
	}

	public static async Task wait(TimeSpan timespan) {
		double startMilliseconds = getCurrentMilliseconds();
		double endMilliseconds = startMilliseconds + timespan.TotalMilliseconds;
		while (getCurrentMilliseconds() < endMilliseconds) {
			await Task.Delay(
				TimeSpan.FromMilliseconds(0.1)
			);
		}
	}
}

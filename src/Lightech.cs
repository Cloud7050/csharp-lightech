static class Lightech {
	public static async Task Main(string[] args) {
		await AnimationManager.onInitialise();
		KeyEventManager.onInitialise();

		await AnimationManager.onAnimate();
	}
}

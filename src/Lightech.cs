static class Lightech {
	public static void Main(string[] args) {
		AnimationManager.onInitialise();
		KeyEventManager.onInitialise();

		AnimationManager.onAnimate();

		AnimationManager.onExit();
	}
}

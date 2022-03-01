using H.Hooks;



static class EffectManager {
	private static readonly Effect[] EFFECTS = new Effect[] {
		new EffectGlobalWipe(),
		new EffectRipple(),
	};

	public static void onStart() {
		foreach (Effect effect in EFFECTS) effect.onStart();
	}

	public static void onFrame() {
		foreach (Effect effect in EFFECTS) effect.onFrame();
	}

	public static void onKeyDown(Key eventKey) {
		if (!AnimationManager.isConnected()) return;

		foreach (Effect effect in EFFECTS) effect.onKeyDown(eventKey);
	}

	public static void onKeyUp(Key eventKey) {
		if (!AnimationManager.isConnected()) return;

		foreach (Effect effect in EFFECTS) effect.onKeyUp(eventKey);
	}
}

using H.Hooks;



static class EffectManager {
	private static readonly Effect[] EFFECTS = new Effect[] {
		new EffectRipple(),
	};

	public static void onWake() {
		foreach (Effect effect in EFFECTS) effect.onWake();
	}

	public static void onKeyDown(Key eventKey) {
		foreach (Effect effect in EFFECTS) effect.onKeyDown(eventKey);
	}

	public static void onKeyUp(Key eventKey) {
		foreach (Effect effect in EFFECTS) effect.onKeyUp(eventKey);
	}

	public static void onFrame() {
		foreach (Effect effect in EFFECTS) effect.onFrame();
		LightKeyManager.sendAllColours();
	}
}

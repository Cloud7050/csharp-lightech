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

	public static void registerKeyDowns(LowLevelKeyboardHook hook) {
		//TODO
	}

	public static void registerKeyUps(LowLevelKeyboardHook hook) {
		//TODO
	}
}

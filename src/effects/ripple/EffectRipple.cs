using H.Hooks;



class EffectRipple : Effect {
	private static List<Ripple> ripples = new List<Ripple>();

	public override void onKeyDown(Key eventKey) {
		LightKeyManager.forEachWithEventKey((LightKey lightKey) => {
			if (eventKey != lightKey.eventKey) return ForEach.CONTINUE;

			ripples.Add(
				new BigRipple(lightKey)
			);
			return ForEach.BREAK;
		});
	}

	public override void onKeyUp(Key eventKey) {
		foreach (Ripple ripple in ripples) {
			if (ripple.isForEventKey(eventKey)) ripple.onThisKeyUp();
		}
	}

	public override void onFrame() {
		foreach (Ripple ripple in ripples) {
			ripple.onFrameStart();
		}

		LightKeyManager.forEachWithGKey((LightKey lightKey) => {
			Colour changingColour = new Colour(
				Colour.MAX,
				Colour.MAX,
				Colour.MAX,
				Colour.MEDIUM
			); // Faded white
			foreach (Ripple ripple in ripples) {
				Colour frontColour = ripple.onGetColour(lightKey);
				if (frontColour.alpha == 0) continue;

				changingColour.alphaCompositeBehind(frontColour);
			}

			lightKey.mergeUpcomingColour(changingColour);

			return ForEach.VOID;
		});

		for (int i = ripples.Count - 1; i >= 0; i--) {
			Ripple ripple = ripples[i];

			ripple.onFrameEnd();
			if (ripple.onCheckRemove()) ripples.RemoveAt(i);
		}
	}
}

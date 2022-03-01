using H.Hooks;



using N = LedCSharp.keyboardNames;



class EffectRipple : Effect {
	private static readonly List<Ripple> pendingRipples = new List<Ripple>();
	private static readonly List<Ripple> liveRipples = new List<Ripple>();

	public override void onFrame() {
		while (pendingRipples.Count > 0) {
			Ripple ripple = pendingRipples[0];

			pendingRipples.RemoveAt(0);
			liveRipples.Add(ripple);
		}

		LightKeyManager.forEachWithGKey((LightKey lightKey) => {
			Colour changingColour = new Colour(
				Colour.MAX,
				Colour.MAX,
				Colour.MAX,
				Colour.MEDIUM
			); // Faded white
			foreach (Ripple ripple in liveRipples) {
				Colour frontColour = ripple.newColourFor(lightKey);
				if (frontColour.alpha == 0) continue;

				changingColour.alphaCompositeBehind(frontColour);
			}

			G.colour(
				(N) lightKey.gKey!,
				changingColour
			);
			return LightKeyManager.CONTINUE;
		});

		for (int i = liveRipples.Count - 1; i >= 0; i--) {
			Ripple ripple = liveRipples[i];

			ripple.expandRadius();
			if (ripple.exceedsKeyboard()) liveRipples.RemoveAt(i);
		}
	}

	public override void onKeyDown(KeyboardEventArgs data) {
		List<Key> relevantKeys = data.Keys.Values.ToList();
		LightKeyManager.forEachWithEventKey((LightKey lightKey) => {
			if (relevantKeys.Count == 0) return LightKeyManager.BREAK;

			Key eventKey = (Key) lightKey.eventKey!;
			if (!relevantKeys.Contains(eventKey)) return LightKeyManager.CONTINUE;
			relevantKeys.Remove(eventKey);

			pendingRipples.Add(
				new Ripple(
					lightKey.circle.centre
				)
			);
			return LightKeyManager.CONTINUE;
		});
	}
}

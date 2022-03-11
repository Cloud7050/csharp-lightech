using H.Hooks;
using LedCSharp;



class EffectRipple : Effect {
	private static List<Ripple> pendingRipples = new List<Ripple>();
	private static List<Ripple> liveRipples = new List<Ripple>();

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
				(GKey) lightKey.gKey!,
				changingColour
			);

			return ForEach.VOID;
		});

		for (int i = liveRipples.Count - 1; i >= 0; i--) {
			Ripple ripple = liveRipples[i];

			ripple.expandRadius();
			if (ripple.exceedsKeyboard()) liveRipples.RemoveAt(i);
		}
	}

	public override void onKeyDown(Key eventKey) {
		LightKeyManager.forEachWithEventKey((LightKey lightKey) => {
			if (eventKey != lightKey.eventKey) return ForEach.CONTINUE;

			pendingRipples.Add(
				new Ripple(
					lightKey.circle.centre
				)
			);
			return ForEach.BREAK;
		});
	}
}

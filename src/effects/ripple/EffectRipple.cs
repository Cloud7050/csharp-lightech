using H.Hooks;



class EffectRipple : Effect {
	private static readonly List<Ripple> pendingRipples = new List<Ripple>();
	private static readonly List<Ripple> liveRipples = new List<Ripple>();

	public override void onFrame() {
		while (pendingRipples.Count > 0) {
			Ripple ripple = pendingRipples[0];

			pendingRipples.Remove(ripple);
			liveRipples.Add(ripple);
		}

		foreach (Ripple ripple in liveRipples) {
			ripple.outOfRange = true;
		}

		LightKeyManager.forEachGKey((LightKey lightKey) => {
			Colour changingColour = new Colour(
				Colour.MAX,
				Colour.MAX,
				Colour.MAX,
				Colour.MEDIUM
			); // Faded white
			foreach (Ripple ripple in liveRipples) {
				Colour frontColour = ripple.newColourFor(lightKey);
				if (frontColour.alpha == 0) continue;

				ripple.outOfRange = false;
				changingColour.alphaCompositeBehind(frontColour);
			}

			G.colour(
				lightKey.gKey,
				changingColour
			);
		});

		for (int i = liveRipples.Count - 1; i >= 0; i--) {
			Ripple ripple = liveRipples[i];

			if (ripple.outOfRange) {
				liveRipples.RemoveAt(i);
				continue;
			}

			ripple.expandRadius();
		}
	}

	public override void onKeyDown(KeyboardEventArgs data) {
		//TODO
		// foreach (Key hookKey in data.Keys.Values) {
		// 	foreach (LightKey locatedKey in LOCATED_KEYS) {
		// 		if (hookKey != locatedKey.hookKey) continue;

		// 		if (downKeys.Contains(hookKey)) continue;

		// 		incomingRipples.Add(
		// 			new Ripple(
		// 				locatedKey.location,
		// 				ColourStream.nextColour()
		// 			)
		// 		);
		// 		return;
		// 	}
		// }
	}
}

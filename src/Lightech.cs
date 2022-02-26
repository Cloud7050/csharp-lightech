using System.Drawing;
using System.Numerics;
using H.Hooks;

using G = LedCSharp.LogitechGSDK;
using N = LedCSharp.keyboardNames;



public static class Lightech {
	private static readonly double PERFECT_FPS = 300;
	private static readonly TimeSpan FRAME_SLEEP = TimeSpan.FromSeconds(1d / PERFECT_FPS);
	private static readonly double FRAME_RADIUS = 40 / PERFECT_FPS;

	private static readonly double FADE_DISTANCE = 1.25;
	private static readonly double INTENSITY_SNAP = 0.1;

	private static readonly LocatedKey[] LOCATED_KEYS = new LocatedKey[] {
		new LocatedKey(new Vector2(-6.25f, 2), Key.OemTilde, N.TILDE),
		new LocatedKey(new Vector2(-5.25f, 2), Key.D1, N.ONE),
		new LocatedKey(new Vector2(-4.25f, 2), Key.D2, N.TWO),
		new LocatedKey(new Vector2(-3.25f, 2), Key.D3, N.THREE),
		new LocatedKey(new Vector2(-2.25f, 2), Key.D4, N.FOUR),
		new LocatedKey(new Vector2(-1.25f, 2), Key.D5, N.FIVE),
		new LocatedKey(new Vector2(-0.25f, 2), Key.D6, N.SIX),
		new LocatedKey(new Vector2(0.75f, 2), Key.D7, N.SEVEN),
		new LocatedKey(new Vector2(1.75f, 2), Key.D8, N.EIGHT),
		new LocatedKey(new Vector2(2.75f, 2), Key.D9, N.NINE),
		new LocatedKey(new Vector2(3.75f, 2), Key.D0, N.ZERO),
		new LocatedKey(new Vector2(4.75f, 2), Key.OemMinus, N.MINUS),
		new LocatedKey(new Vector2(5.75f, 2), Key.OemPlus, N.EQUALS),

		new LocatedKey(new Vector2(-4.75f, 1), Key.Q, N.Q),
		new LocatedKey(new Vector2(-3.75f, 1), Key.W, N.W),
		new LocatedKey(new Vector2(-2.75f, 1), Key.E, N.E),
		new LocatedKey(new Vector2(-1.75f, 1), Key.R, N.R),
		new LocatedKey(new Vector2(-0.75f, 1), Key.T, N.T),
		new LocatedKey(new Vector2(0.25f, 1), Key.Y, N.Y),
		new LocatedKey(new Vector2(1.25f, 1), Key.U, N.U),
		new LocatedKey(new Vector2(2.25f, 1), Key.I, N.I),
		new LocatedKey(new Vector2(3.25f, 1), Key.O, N.O),
		new LocatedKey(new Vector2(4.25f, 1), Key.P, N.P),
		new LocatedKey(new Vector2(5.25f, 1), Key.OemOpenBrackets, N.OPEN_BRACKET),
		new LocatedKey(new Vector2(6.25f, 1), Key.OemCloseBrackets, N.CLOSE_BRACKET),

		new LocatedKey(new Vector2(-4.5f, 0), Key.A, N.A),
		new LocatedKey(new Vector2(-3.5f, 0), Key.S, N.S),
		new LocatedKey(new Vector2(-2.5f, 0), Key.D, N.D),
		new LocatedKey(new Vector2(-1.5f, 0), Key.F, N.F),
		new LocatedKey(new Vector2(-0.5f, 0), Key.G, N.G),
		new LocatedKey(new Vector2(0.5f, 0), Key.H, N.H),
		new LocatedKey(new Vector2(1.5f, 0), Key.J, N.J),
		new LocatedKey(new Vector2(2.5f, 0), Key.K, N.K),
		new LocatedKey(new Vector2(3.5f, 0), Key.L, N.L),
		new LocatedKey(new Vector2(4.5f, 0), Key.OemSemicolon, N.SEMICOLON),
		new LocatedKey(new Vector2(5.5f, 0), Key.OemQuotes, N.APOSTROPHE),

		new LocatedKey(new Vector2(-4, -1), Key.Z, N.Z),
		new LocatedKey(new Vector2(-3, -1), Key.X, N.X),
		new LocatedKey(new Vector2(-2, -1), Key.C, N.C),
		new LocatedKey(new Vector2(-1, -1), Key.V, N.V),
		new LocatedKey(new Vector2(0, -1), Key.B, N.B),
		new LocatedKey(new Vector2(1, -1), Key.N, N.N),
		new LocatedKey(new Vector2(2, -1), Key.M, N.M),
		new LocatedKey(new Vector2(3, -1), Key.OemComma, N.COMMA),
		new LocatedKey(new Vector2(4, -1), Key.OemPeriod, N.PERIOD),
		new LocatedKey(new Vector2(5, -1), Key.OemQuestion, N.FORWARD_SLASH)
	};

	private static readonly List<Key> downKeys = new List<Key>();

	private static readonly List<Ripple> incomingRipples = new List<Ripple>();
	private static readonly List<Ripple> volatileRipples = new List<Ripple>();

	public static void Main(string[] args) {
		G.LogiLedInit();

		register();

		animate();

		Thread.Sleep(Timeout.Infinite);

		G.LogiLedShutdown();
	}

	private static void register() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		EventHandler<KeyboardEventArgs> downLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"v {data}");
		};
		EventHandler<KeyboardEventArgs> upLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"^ {data}");
		};
		hook.Down += downLogger;
		hook.Up += upLogger;

		EventHandler<KeyboardEventArgs> downRippler = (object? sender, KeyboardEventArgs data) => {
			foreach (Key hookKey in data.Keys.Values) {
				foreach (LocatedKey locatedKey in LOCATED_KEYS) {
					if (hookKey != locatedKey.hookKey) continue;

					if (downKeys.Contains(hookKey)) continue;

					incomingRipples.Add(
						new Ripple(
							locatedKey.location,
							ColourStream.nextColour()
						)
					);
					return;
				}
			}
		};
		hook.Down += downRippler;

		EventHandler<KeyboardEventArgs> downNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				if (downKeys.Contains(key)) continue;

				downKeys.Add(key);
				Console.WriteLine($"ADD {key}");
			}
		};
		EventHandler<KeyboardEventArgs> upNonce = (object? sender, KeyboardEventArgs data) => {
			foreach (Key key in data.Keys.Values) {
				while (downKeys.Contains(key)) {
					downKeys.Remove(key);
					Console.WriteLine($"REM {key}");
				}
			}
		};
		hook.Down += downNonce;
		hook.Up += upNonce;

		hook.Start();
	}

	private static void animate() {
		G.LogiLedSetLighting(0, 100, 0);

		Timer timer = new Timer(
			onFrame,
			null,
			TimeSpan.Zero,
			FRAME_SLEEP
		);
	}
	private static void onFrame(object? _state) {
		while (incomingRipples.Count > 0) {
			Ripple incomingRipple = incomingRipples[0];
			incomingRipples.RemoveAt(0);
			volatileRipples.Add(incomingRipple);
		}

		foreach (LocatedKey locatedKey in LOCATED_KEYS) {
			Color changingColour = Color.FromArgb(
				170,
				255,
				255,
				255
			); // Faded white
			foreach (Ripple ripple in volatileRipples) {
				double distance = ripple.distanceToCircumference(locatedKey.location);

				double intensityFactor = FADE_DISTANCE - distance;
				if (intensityFactor <= 0) continue;

				double intensityInterval = intensityFactor / FADE_DISTANCE;
				if (intensityInterval <= INTENSITY_SNAP) intensityInterval = 1;
				else intensityInterval = (intensityInterval - INTENSITY_SNAP) / (1 - INTENSITY_SNAP);

				double alpha = intensityInterval * 255;
				Color frontColour = ColourUtilities.overwriteAlpha(
					ripple.colour,
					alpha
				);

				changingColour = ColourUtilities.alphaCompositeOver(
					frontColour,
					changingColour
				);
			}

			G.LogiLedSetLightingForKeyWithKeyName(
				locatedKey.lightKey,
				ColourUtilities.toAlphaPercentage(changingColour.R, changingColour.A),
				ColourUtilities.toAlphaPercentage(changingColour.G, changingColour.A),
				ColourUtilities.toAlphaPercentage(changingColour.B, changingColour.A)
			);
		}

		for (int i = volatileRipples.Count - 1; i >= 0; i--) {
			Ripple ripple = volatileRipples[i];

			ripple.radius += FRAME_RADIUS;
			if (ripple.radius > 50) volatileRipples.RemoveAt(i);
		}
	}
}

using System.Collections.Generic;
using System.Numerics;
using H.Hooks;

using G = LedCSharp.LogitechGSDK;
using N = LedCSharp.keyboardNames;



public static class Lightech {
	private static readonly int FPS = 240;
	private static readonly TimeSpan FRAME_TIME = TimeSpan.FromSeconds(1d / FPS);

	private static readonly LocatedKey[] LOCATED_KEYS = new LocatedKey[] {
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

	private static readonly List<Ripple> ripples = new List<Ripple>();

	public static void Main(string[] args) {
		G.LogiLedInit();

		register();

		animate();

		Thread.Sleep(Timeout.Infinite);

		G.LogiLedShutdown();
	}

	private static void register() {
		LowLevelKeyboardHook hook = new LowLevelKeyboardHook();

		EventHandler<KeyboardEventArgs> upLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"{nameof(hook.Up)}: {data}");
		};
		EventHandler<KeyboardEventArgs> downLogger = (object? sender, KeyboardEventArgs data) => {
			Console.WriteLine($"{nameof(hook.Down)}: {data}");
		};
		hook.Up += upLogger;
		hook.Down += downLogger;

		EventHandler<KeyboardEventArgs> downRippler = (object? sender, KeyboardEventArgs data) => {
			foreach (LocatedKey locatedKey in LOCATED_KEYS) {
				if (!data.Keys.Values.Contains(locatedKey.hookKey)) continue;

				ripples.Add(
					new Ripple(locatedKey.location)
				);
				return;
			}
		};
		hook.Down += downRippler;

		hook.Start();
	}

	private static void animate() {
		G.LogiLedSetLighting(100, 100, 100);

		TimerCallback animationCallback = (object? _state) => {
			foreach (LocatedKey locatedKey in LOCATED_KEYS) {
				double colourIntensity = 0;
				foreach (Ripple ripple in ripples) {
					double distance = ripple.distanceToCircumference(locatedKey.location);

					double intensityFactor = (1.5 - distance) / 1.5;
					if (intensityFactor <= 0) continue;

					colourIntensity = Math.Max(
						colourIntensity,
						intensityFactor
					);
				}

				int colourPercentage = Convert.ToInt32(100 * colourIntensity);

				G.LogiLedSetLightingForKeyWithKeyName(
					locatedKey.lightKey,
					100 - colourPercentage,
					100,
					100 - colourPercentage
				);
			}

			for (int i = ripples.Count - 1; i >= 0; i--) {
				Ripple ripple = ripples[i];

				ripple.radius += (40d / FPS);
				if (ripple.radius > 100) ripples.RemoveAt(i);
			}
		};

		Timer timer = new Timer(
			animationCallback,
			null,
			TimeSpan.Zero,
			FRAME_TIME
		);
	}
}

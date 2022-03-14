using H.Hooks;
using LedCSharp;



static class LightKeyManager {
	private const double CONTROL_SIZE = KEY_SIZE * 1.5;
	private const double TAB_SIZE = CONTROL_SIZE;
	private const double BACKSLASH_SIZE = CONTROL_SIZE;

	private const double WINDOWS_SIZE = KEY_SIZE * 1.25;
	private const double ALT_SIZE = WINDOWS_SIZE;
	private const double APPS_SIZE = WINDOWS_SIZE;

	private const double SPACE_SIZE = KEY_SIZE * 5.75;

	private const double LEFT_SHIFT_SIZE = KEY_SIZE * 2.25;
	private const double ENTER_SIZE = LEFT_SHIFT_SIZE;

	private const double RIGHT_SHIFT_SIZE = KEY_SIZE * 2.75;

	private const double CAPSIZE = KEY_SIZE * 1.75;

	private const double GAP_SIZE = KEY_SIZE / 3d;
	private const double FUNCTION_GAP_SIZE = (2 * KEY_SIZE) / 3d;

	private static readonly LightKey[] ROW_1;
	private static readonly LightKey[] ROW_2;
	private static readonly LightKey[] ROW_3;
	private static readonly LightKey[] ROW_4;
	private static readonly LightKey[] ROW_5;
	private static readonly LightKey[] ROW_6;
	private static readonly LightKey[] ROW_7;

	private static readonly LightKey[] LIGHT_KEYS;

	public const double KEY_SIZE = 1;

	public static readonly ImmutablePoint TOP_LEFT;
	public static readonly ImmutablePoint TOP_RIGHT;
	public static readonly ImmutablePoint BOTTOM_LEFT;
	public static readonly ImmutablePoint BOTTOM_RIGHT;

	public static readonly double WIDTH;

	static LightKeyManager() {
		double row1Y = KEY_SIZE / 2d;
		double row2Y = row1Y + KEY_SIZE;
		double row3Y = row2Y + KEY_SIZE;
		double row4Y = row3Y + KEY_SIZE;
		double row5Y = row4Y + KEY_SIZE;
		double row6Y = row5Y + KEY_SIZE + GAP_SIZE;
		double row7Y = row6Y + KEY_SIZE + GAP_SIZE;

		double row1X = 0;
		double row2X = 0;
		double row3X = 0;
		double row4X = 0;
		double row5X = 0;
		double row6X = 0;
		double row7X = 0;

		ROW_1 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row1X += KEY_SIZE / 2d,
				row1Y
			), null, GKey.G_5),

			new LightKey(new ImmutablePoint(
				row1X += (KEY_SIZE / 2d) + GAP_SIZE + (CONTROL_SIZE / 2d),
				row1Y
			), Key.LeftControl, GKey.LEFT_CONTROL),
			new LightKey(new ImmutablePoint(
				row1X += (CONTROL_SIZE / 2d) + (WINDOWS_SIZE / 2d),
				row1Y
			), Key.LeftWindows, GKey.LEFT_WINDOWS),
			new LightKey(new ImmutablePoint(
				row1X += (WINDOWS_SIZE / 2d) + (ALT_SIZE / 2d),
				row1Y
			), Key.LeftAlt, GKey.LEFT_ALT),
			new LightKey(new ImmutablePoint(
				row1X += (ALT_SIZE / 2d) + (SPACE_SIZE / 2d),
				row1Y
			), Key.Space, GKey.SPACE),
			new LightKey(new ImmutablePoint(
				row1X += (SPACE_SIZE / 2d) + (ALT_SIZE / 2d),
				row1Y
			), Key.RightAlt, GKey.RIGHT_ALT),
			new LightKey(new ImmutablePoint(
				row1X += (ALT_SIZE / 2d) + (WINDOWS_SIZE / 2d),
				row1Y
			), Key.RightWindows, GKey.RIGHT_WINDOWS),
			new LightKey(new ImmutablePoint(
				row1X += (WINDOWS_SIZE / 2d) + (APPS_SIZE / 2d),
				row1Y
			), Key.Apps, GKey.APPLICATION_SELECT, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row1X += (APPS_SIZE / 2d) + (CONTROL_SIZE / 2d),
				row1Y
			), Key.RightControl, GKey.RIGHT_CONTROL),

			new LightKey(new ImmutablePoint(
				row1X += (CONTROL_SIZE / 2d) + GAP_SIZE + (KEY_SIZE / 2d),
				row1Y
			), Key.Left, GKey.ARROW_LEFT),
			new LightKey(new ImmutablePoint(
				row1X += KEY_SIZE,
				row1Y
			), Key.Down, GKey.ARROW_DOWN),
			new LightKey(new ImmutablePoint(
				row1X += KEY_SIZE,
				row1Y
			), Key.Right, GKey.ARROW_RIGHT),

			new LightKey(new ImmutablePoint(
				row1X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row1Y
			), Key.NumPad0, GKey.NUM_ZERO),
			new LightKey(new ImmutablePoint(
				row1X += KEY_SIZE * 1.5,
				row1Y
			), Key.Decimal, GKey.NUM_PERIOD),
			new LightKey(new ImmutablePoint(
				row1X += KEY_SIZE,
				row1Y + (KEY_SIZE / 2d)
			), null, GKey.NUM_ENTER)
		};

		ROW_2 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE / 2d,
				row2Y
			), null, GKey.G_4),

			new LightKey(new ImmutablePoint(
				row2X += (KEY_SIZE / 2d) + GAP_SIZE + (LEFT_SHIFT_SIZE / 2d),
				row2Y
			), Key.LeftShift, GKey.LEFT_SHIFT),
			new LightKey(new ImmutablePoint(
				row2X += (LEFT_SHIFT_SIZE / 2d) + (KEY_SIZE / 2d),
				row2Y
			), Key.Z, GKey.Z),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.X, GKey.X),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.C, GKey.C),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.V, GKey.V),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.B, GKey.B),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.N, GKey.N),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.M, GKey.M),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemComma, GKey.COMMA),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemPeriod, GKey.PERIOD),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.OemQuestion, GKey.FORWARD_SLASH),
			new LightKey(new ImmutablePoint(
				row2X += (KEY_SIZE / 2d) + (RIGHT_SHIFT_SIZE / 2d),
				row2Y
			), Key.RightShift, GKey.RIGHT_SHIFT),

			new LightKey(new ImmutablePoint(
				row2X += (RIGHT_SHIFT_SIZE / 2d) + GAP_SIZE + (KEY_SIZE * 1.5),
				row2Y
			), Key.Up, GKey.ARROW_UP),

			new LightKey(new ImmutablePoint(
				row2X += (KEY_SIZE * 2) + GAP_SIZE,
				row2Y
			), Key.NumPad1, GKey.NUM_ONE),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.NumPad2, GKey.NUM_TWO),
			new LightKey(new ImmutablePoint(
				row2X += KEY_SIZE,
				row2Y
			), Key.NumPad3, GKey.NUM_THREE)
		};

		ROW_3 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE / 2d,
				row3Y
			), null, GKey.G_3),

			new LightKey(new ImmutablePoint(
				row3X += (KEY_SIZE / 2d) + GAP_SIZE + (CAPSIZE / 2d),
				row3Y
			), Key.Escape, GKey.CAPS_LOCK, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row3X += (CAPSIZE / 2d) + (KEY_SIZE / 2d),
				row3Y
			), Key.A, GKey.A),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.S, GKey.S),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.D, GKey.D),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.F, GKey.F),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.G, GKey.G),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.H, GKey.H),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.J, GKey.J),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.K, GKey.K),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.L, GKey.L),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.OemSemicolon, GKey.SEMICOLON),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.OemQuotes, GKey.APOSTROPHE),
			new LightKey(new ImmutablePoint(
				row3X += (KEY_SIZE / 2d) + (ENTER_SIZE / 2d),
				row3Y
			), Key.Enter, GKey.ENTER, RippleType.BIG),

			new LightKey(new ImmutablePoint(
				row3X += (ENTER_SIZE / 2d) + (GAP_SIZE * 2) + (KEY_SIZE * 3.5),
				row3Y
			), Key.NumPad4, GKey.NUM_FOUR),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.NumPad5, GKey.NUM_FIVE),
			new LightKey(new ImmutablePoint(
				row3X,
				row3Y
			), Key.Clear, GKey.NUM_FIVE),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y
			), Key.NumPad6, GKey.NUM_SIX),
			new LightKey(new ImmutablePoint(
				row3X += KEY_SIZE,
				row3Y + (KEY_SIZE / 2d)
			), Key.Add, GKey.NUM_PLUS)
		};

		ROW_4 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE / 2d,
				row4Y
			), null, GKey.G_2),

			new LightKey(new ImmutablePoint(
				row4X += (KEY_SIZE / 2d) + GAP_SIZE + (TAB_SIZE / 2d),
				row4Y
			), Key.Tab, GKey.TAB, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row4X += (TAB_SIZE / 2d) + (KEY_SIZE / 2d),
				row4Y
			), Key.Q, GKey.Q),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.W, GKey.W),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.E, GKey.E),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.R, GKey.R),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.T, GKey.T),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.Y, GKey.Y),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.U, GKey.U),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.I, GKey.I),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.O, GKey.O),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.P, GKey.P),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.OemOpenBrackets, GKey.OPEN_BRACKET),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.OemCloseBrackets, GKey.CLOSE_BRACKET),
			new LightKey(new ImmutablePoint(
				row4X += (KEY_SIZE / 2d) + (BACKSLASH_SIZE / 2d),
				row4Y
			), Key.OemPipe, GKey.BACKSLASH),

			new LightKey(new ImmutablePoint(
				row4X += (BACKSLASH_SIZE / 2d) + GAP_SIZE + (KEY_SIZE / 2d),
				row4Y
			), Key.Delete, GKey.KEYBOARD_DELETE),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.End, GKey.END, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.PageDown, GKey.PAGE_DOWN, RippleType.BIG),

			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE + GAP_SIZE,
				row4Y
			), Key.NumPad7, GKey.NUM_SEVEN),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.NumPad8, GKey.NUM_EIGHT),
			new LightKey(new ImmutablePoint(
				row4X += KEY_SIZE,
				row4Y
			), Key.NumPad9, GKey.NUM_NINE)
		};

		ROW_5 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE / 2d,
				row5Y
			), null, GKey.G_1),

			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE + GAP_SIZE,
				row5Y
			), Key.OemTilde, GKey.TILDE),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D1, GKey.ONE),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D2, GKey.TWO),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D3, GKey.THREE),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D4, GKey.FOUR),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D5, GKey.FIVE),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D6, GKey.SIX),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D7, GKey.SEVEN),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D8, GKey.EIGHT),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D9, GKey.NINE),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.D0, GKey.ZERO),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.OemMinus, GKey.MINUS),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.OemPlus, GKey.EQUALS),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE * 1.5,
				row5Y
			), Key.Back, GKey.BACKSPACE),

			new LightKey(new ImmutablePoint(
				row5X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row5Y
			), Key.Insert, GKey.INSERT, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.Home, GKey.HOME, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.PageUp, GKey.PAGE_UP, RippleType.BIG),

			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE + GAP_SIZE,
				row5Y
			), Key.NumLock, GKey.NUM_LOCK, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.Divide, GKey.NUM_SLASH),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.Multiply, GKey.NUM_ASTERISK),
			new LightKey(new ImmutablePoint(
				row5X += KEY_SIZE,
				row5Y
			), Key.Subtract, GKey.NUM_MINUS)
		};

		ROW_6 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row6X += (KEY_SIZE * 1.5) + GAP_SIZE,
				row6Y
			), Key.CapsLock, GKey.ESC, RippleType.BIG),

			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F1, GKey.F1),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F2, GKey.F2),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F3, GKey.F3),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F4, GKey.F4),

			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F5, GKey.F5),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F6, GKey.F6),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F7, GKey.F7),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F8, GKey.F8),

			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE + FUNCTION_GAP_SIZE,
				row6Y
			), Key.F9, GKey.F9),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F10, GKey.F10),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F11, GKey.F11),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.F12, GKey.F12),

			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE + GAP_SIZE,
				row6Y
			), Key.PrintScreen, GKey.PRINT_SCREEN, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.Scroll, GKey.SCROLL_LOCK, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.Pause, GKey.PAUSE_BREAK, RippleType.BIG),

			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE + GAP_SIZE,
				row6Y
			), Key.MediaPreviousTrack, null, 0.5),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.MediaPlayPause, null, 0.5),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.MediaNextTrack, null, 0.5),
			new LightKey(new ImmutablePoint(
				row6X += KEY_SIZE,
				row6Y
			), Key.VolumeMute, null, 0.5)
		};

		ROW_7 = new LightKey[] {
			new LightKey(new ImmutablePoint(
				row7X += KEY_SIZE / 2d,
				row7Y
			), null, GKey.G_LOGO, 1),

			new LightKey(new ImmutablePoint(
				row7X += (KEY_SIZE * 20.5) + (GAP_SIZE * 3),
				row7Y + (KEY_SIZE / 2d)
			), Key.VolumeUp, null, RippleType.BIG),
			new LightKey(new ImmutablePoint(
				row7X,
				row7Y + (KEY_SIZE / 2d)
			), Key.VolumeDown, null, RippleType.BIG)
		};

		LIGHT_KEYS = ROW_1
			.Concat(ROW_2)
			.Concat(ROW_3)
			.Concat(ROW_4)
			.Concat(ROW_5)
			.Concat(ROW_6)
			.Concat(ROW_7)
			.ToArray();

		double left = Double.PositiveInfinity;
		double right = Double.NegativeInfinity;
		double top = Double.NegativeInfinity;
		double bottom = Double.PositiveInfinity;
		foreach (LightKey lightKey in LIGHT_KEYS) {
			Circle lightCircle = lightKey.circle;

			left = Math.Min(left, lightCircle.leftMost());
			right = Math.Max(right, lightCircle.rightMost());
			top = Math.Max(top, lightCircle.topMost());
			bottom = Math.Min(bottom, lightCircle.bottomMost());
		}

		TOP_LEFT = new ImmutablePoint(left, top);
		TOP_RIGHT = new ImmutablePoint(right, top);
		BOTTOM_LEFT = new ImmutablePoint(left, bottom);
		BOTTOM_RIGHT = new ImmutablePoint(right, bottom);

		WIDTH = TOP_LEFT.distanceTo(TOP_RIGHT);
	}

	private static void forEachCondition(
		Func<LightKey, bool> condition,
		Func<LightKey, ForEach> callback
	) {
		foreach (LightKey lightKey in LIGHT_KEYS) {
			if (!condition(lightKey)) continue;

			ForEach response = callback(lightKey);
			if (response == ForEach.BREAK) break;
		}
	}

	public static void forEachWithEventKey(Func<LightKey, ForEach> callback) {
		forEachCondition(
			(LightKey lightKey) => lightKey.eventKey != null,
			callback
		);
	}

	public static void forEachWithGKey(Func<LightKey, ForEach> callback) {
		forEachCondition(
			(LightKey lightKey) => lightKey.gKey != null,
			callback
		);
	}

	public static void notifyGlobalColour(Colour colour) {
		forEachWithGKey((LightKey lightKey) => {
			lightKey.overwriteCurrentColour(colour);
			return ForEach.VOID;
		});
	}

	public static void sendAllColours() {
		forEachWithGKey((LightKey lightKey) => {
			lightKey.maySendColour();
			return ForEach.VOID;
		});
	}
}

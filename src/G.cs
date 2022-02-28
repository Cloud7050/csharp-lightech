using S = LedCSharp.LogitechGSDK;
using N = LedCSharp.keyboardNames;



static class G {
	public static bool connect(
		string? name = "Lightech ☁"
	) {
		if (name == null) return S.LogiLedInit();

		return S.LogiLedInitWithName(name);
	}

	public static void disconnect() {
		S.LogiLedShutdown();
	}

	public static void reconnect() {
		disconnect();
		connect();
	}

	public static bool dummyCommand() {
		return colour(
			(N) 7050,
			Colour.BLACK
		);
	}

	public static bool colourGlobally(
		Colour colour
	) {
		return S.LogiLedSetLighting(
			colour.getPercentageDimmedRed(),
			colour.getPercentageDimmedGreen(),
			colour.getPercentageDimmedBlue()
		);
	}

	public static bool colour(
		N keyName,
		Colour colour
	) {
		return S.LogiLedSetLightingForKeyWithKeyName(
			keyName,
			colour.getPercentageDimmedRed(),
			colour.getPercentageDimmedGreen(),
			colour.getPercentageDimmedBlue()
		);
	}
}

public class PitchResult {
	public PitchResultType type;
	public int outs;
	public int basesAdvanced;
}

public enum PitchResultType {
	Strike,
	Ball,
	Foul,
	InPlay
}
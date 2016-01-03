using UnityEngine;
using System.Collections;

abstract public class FieldingUIController : MonoBehaviour {
	public PitchIconView pitchIcons;
	public StrikeZoneView strikeZone;
	public FieldingCursor cursor;
	public PitcherController pitcherController;
	public PitchList pitches;

	public virtual void pitchSelected(int index) { }
	public virtual void locationSelected(Vector2 location) { }
	
	public virtual void PitchAdvanced() {}
	public virtual void PitchDone() {}
}

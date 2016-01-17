using UnityEngine;
using System.Collections;

abstract public class FieldingUIController : MonoBehaviour {
	public StrikeZoneView strikeZone;
	public PitchList pitches;
	public BaseRunnerView runners;
	
	protected void _init() {
	}
	

	public virtual void pitchSelected(int index) { }
	public virtual void locationSelected(Vector2 location) { }
	
	public virtual void StartPitch() {}
	public virtual void PitchAdvanced() {}
	public virtual void PitchDone() {}
	
	public static FieldingUIController getInstance() {
		return GameObject.FindGameObjectWithTag("UI Controller").GetComponent<FieldingUIController>();
	}
}

using UnityEngine;
using System.Collections;

abstract public class FieldingUIController : MonoBehaviour {
	public StrikeZoneView strikeZone;
	public PitchList pitches;
	
	protected void _Init() {
	}
	

	public virtual void PitchSelected(int index) { }
	public virtual void LocationSelected(Vector2 location) { }
	
	public virtual void StartPitch() {}
	public virtual void PitchAdvanced() {}
	public virtual void PitchDone() {}
	
	public static FieldingUIController GetInstance() {
		return GameObject.FindGameObjectWithTag("UI Controller").GetComponent<FieldingUIController>();
	}
}

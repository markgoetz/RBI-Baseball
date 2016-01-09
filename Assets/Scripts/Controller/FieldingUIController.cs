using UnityEngine;
using System.Collections;

abstract public class FieldingUIController : MonoBehaviour {
	public StrikeZoneView strikeZone;
	public FieldingCursor cursor;
	public PitchList pitches;
	public BaseRunnerView runners;
	
	protected GameController gameController;
	
	protected void _init() {
		gameController = GameController.getInstance ();
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

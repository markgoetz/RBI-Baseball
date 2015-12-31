using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class FieldingCursor : MonoBehaviour {
	private FieldingUIController UIController;
	private StrikeZoneView view;
	private bool inside_strike_zone;
	private bool visible;
	
	void Start () {
		FieldingMasterController master = FieldingMasterController.getInstance();
		UIController = master.UIController;
		view = UIController.strikeZone;
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		Vector3 screenpoint = Input.mousePosition;
	
		transform.position = new Vector2(
			Camera.main.ScreenToWorldPoint(screenpoint).x,
			Camera.main.ScreenToWorldPoint(screenpoint).y
		);
		
		// TODO: Hide and ignore events if outside the strike zone
		InsideStrikeZone = view.isInsideStrikeZone(screenpoint);
		
		// TODO: Scale in relation to distance from the sweet spot
	}
	
	public void Clicked() {
		if (!InsideStrikeZone) return;
	}
	
	public bool InsideStrikeZone {
		get { return inside_strike_zone; }
		set {
			inside_strike_zone = value;
			GetComponent<SpriteRenderer>().enabled = value & Visible;
		}
	}
	
	public bool Visible {
		get { return visible; }
		set {
			visible = value;
			GetComponent<SpriteRenderer>().enabled = value & InsideStrikeZone;
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class FieldingCursor : MonoBehaviour {
	private FieldingUIController UIController;
	private PitcherController pitcherController; // TODO: THIS NEEDS TO BE REFACTORED!!!!
	private StrikeZoneView view;
	private bool inside_strike_zone;
	private bool visible;
	private Vector2 sweet_spot; // TODO: THIS TOO!!!
	
	void Start () {
		UIController = FieldingUIController.getInstance();
		view = UIController.strikeZone;
		pitcherController = PitcherController.getInstance();
		sweet_spot = pitcherController.SweetSpot;
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		if (!visible) return;
	
		Vector3 screenpoint = Input.mousePosition;
	
		transform.position = new Vector2(
			Camera.main.ScreenToWorldPoint(screenpoint).x,
			Camera.main.ScreenToWorldPoint(screenpoint).y
		);
		
		InsideStrikeZone = view.isInsideStrikeZone(screenpoint);
		
		// TODO: Scale in relation to distance from the sweet spot
		// TODO: THIS NEEDS TO BE REFACTORED!!!
		Vector2 strike_zone_location = view.worldSpaceToStrikeZone(screenpoint);
		float scale = Vector2.Distance(strike_zone_location, sweet_spot);
		transform.localScale = new Vector2(scale, scale);
	}
	
	public void Clicked() {
		if (!Enabled)
			return;
	
		view.Clicked(Input.mousePosition);
	}
	
	public bool InsideStrikeZone {
		get { return inside_strike_zone; }
		set {
			inside_strike_zone = value;
			GetComponent<SpriteRenderer>().enabled = Enabled;
		}
	}
	
	public bool Visible {
		get { return visible; }
	}
	
	public void setVisible(bool value) {
		visible = value;
		GetComponent<SpriteRenderer>().enabled = Enabled;
	}
	
	public bool Enabled {
		get { return Visible && InsideStrikeZone; }
	}
}

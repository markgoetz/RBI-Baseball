using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
public class PitchingCursor : MonoBehaviour {
	private FieldingUIController UIController;
	private PitcherController pitcherController; // TODO: THIS NEEDS TO BE REFACTORED!!!!
	private StrikeZoneView view;
	private bool inside_strike_zone;
	private bool visible;
	private Rect rect;
	
	private float strike_zone_width;
	
	void Start () {
		UIController = FieldingUIController.getInstance();
		view = UIController.strikeZone;
		strike_zone_width = view.pixelWidth;
		pitcherController = PitcherController.getInstance();
		rect = GetComponent<RectTransform>().rect;
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		if (!Visible) return;
	
		Vector3 screenpoint = Input.mousePosition;
	
		transform.position = new Vector2(
			Camera.main.ScreenToWorldPoint(screenpoint).x,
			Camera.main.ScreenToWorldPoint(screenpoint).y
		);
		
		InsideStrikeZone = view.isInsideStrikeZone(screenpoint);
		
		// Scale in relation to distance from the sweet spot
		Vector2 strike_zone_location = view.worldSpaceToStrikeZone(screenpoint);
		float radius = pitcherController.spreadRadius(strike_zone_location);
		
		float scale = getScale(radius);
		
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
	
	private float getScale(float radius) {
		// How wide is the strike zone in pixels?
		// scale the radius until it matches the strike zone * radius.
		float cursor_pixel_size = radius * strike_zone_width;
		Debug.Log ("Radius: " + radius + "  Strike zone width: " + strike_zone_width + "  Cursor size:" + cursor_pixel_size);
		
		Debug.Log ("sprite size:" + rect.width + "   scale: " + (cursor_pixel_size * rect.width));
		return cursor_pixel_size * rect.width / 100; // HACK: The 100 is hardcoded!
	}
	
	public bool Visible {
		get { return visible; }
		set {
			visible = value;
			GetComponent<SpriteRenderer>().enabled = Enabled;
		}
	}
	
	public void setVisible(bool value) {
		visible = value;
		GetComponent<SpriteRenderer>().enabled = Enabled;
	}
	
	public bool Enabled {
		get { return Visible && InsideStrikeZone; }
	}
}

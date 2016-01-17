using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
[RequireComponent (typeof(Image))]
public class PitchingCursor : MonoBehaviour {
	private FieldingUIController UIController;
	private PitcherController pitcherController;
	private StrikeZoneView view;
	private bool inside_strike_zone;
	private bool visible;
	private RectTransform rect_transform;
	
	private float strike_zone_width;
	
	void Start () {
		UIController = FieldingUIController.getInstance();
		view = UIController.strikeZone;
		strike_zone_width = view.pixelWidth;
		pitcherController = PitcherController.getInstance();
		rect_transform = GetComponent<RectTransform>();
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		if (!Visible) return;
	
		Vector3 screenpoint = Input.mousePosition;
	
		rect_transform.position = screenpoint;
		
		InsideStrikeZone = view.isInsideStrikeZone(screenpoint);
		
		// Scale in relation to distance from the sweet spot
		Vector2 strike_zone_location = view.worldSpaceToStrikeZone(screenpoint);
		float radius = strike_zone_width * pitcherController.spreadRadius(strike_zone_location);
		rect_transform.sizeDelta = new Vector2(radius, radius);
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
			GetComponent<Image>().enabled = Enabled;
		}
	}

	public bool Visible {
		get { return visible; }
		set {
			visible = value;
			GetComponent<Image>().enabled = Enabled;
		}
	}
	
	public void setVisible(bool value) {
		visible = value;
		GetComponent<Image>().enabled = Enabled;
	}
	
	public bool Enabled {
		get { return Visible && InsideStrikeZone; }
	}
}

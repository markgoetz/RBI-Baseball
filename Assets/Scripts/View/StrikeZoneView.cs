using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Button))]
public class StrikeZoneView : MonoBehaviour {
	private FieldingUIController UIController;
	private Button button;
	private Rect rect;
	
	public void setVisible(bool status) {
		button.interactable = status;
		button.image.color = (status) ? Color.white : Color.clear;
	}
	
	void Awake() {
		UIController = FieldingUIController.getInstance();
		button = GetComponent<Button>();
	}
	
	void Start() {		
		RectTransform rect_transform = transform as RectTransform;
		rect = rect_transform.rect;
	}
	
	public bool isInsideStrikeZone(Vector2 screen_point) {
		Vector2 strikeZonePoint = screenPointToStrikeZone(screen_point);
		
		if (strikeZonePoint.x < 0 || strikeZonePoint.x > 1)
			return false;
		if (strikeZonePoint.y < 0 || strikeZonePoint.y > 1)
			return false;
		
		return true;
	}
	
	public void Clicked(Vector2 worldspacePoint) {
		if (!isInsideStrikeZone(worldspacePoint))
			return;
		
		UIController.locationSelected(screenPointToStrikeZone(worldspacePoint));
	}
	
	// Convert a world space point in pixels to the corresponding point in the strike zone.
	// If the point is inside the strike zone, the X and Y coordinates will be between 0 (lower-left) and 1 (upper-right)
	public Vector2 screenPointToStrikeZone(Vector2 screenPoint) {
	
		// first, translate the point from world space to local space.
		Vector2 localPoint = transform.InverseTransformPoint(screenPoint);
		
		// now, determine where it is within local space from 0 to 1.
		// finally, scale the local point to its location relative to the transform rectangle.
		Vector2 strikeZonePoint = new Vector2(
			(localPoint.x - rect.x) / (float)rect.width,
			(localPoint.y - rect.y) / (float)rect.height
		);
		
		return strikeZonePoint;
	}
	
	public Vector2 strikeZoneToScreenPoint(Vector2 strike_zone_point) {
		Vector2 local_point = new Vector2(
			strike_zone_point.x * rect.width  + rect.x,
			strike_zone_point.y * rect.height + rect.y
		);
		
		return transform.TransformPoint(local_point);
	}
	
	public Vector2 strikeZoneToWorldSpace(Vector2 strike_zone_point) {
		Vector2 screen_point = strikeZoneToScreenPoint(strike_zone_point);
		
		return Camera.main.ScreenToWorldPoint(screen_point);
	}
	
	public float pixelWidth {
		get { return rect.width; }
	}
	
	public static StrikeZoneView getInstance() {
		return GameObject.FindGameObjectWithTag("Strike Zone View").GetComponent<StrikeZoneView>();
	}
}

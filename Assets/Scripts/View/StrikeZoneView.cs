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
	
	public bool isInsideStrikeZone(Vector2 worldspacePoint) {
		Vector2 strikeZonePoint = worldSpaceToStrikeZone(worldspacePoint);
		
		if (strikeZonePoint.x < 0 || strikeZonePoint.x > 1)
			return false;
		if (strikeZonePoint.y < 0 || strikeZonePoint.y > 1)
			return false;
		
		return true;
	}
	
	public void Clicked(Vector2 worldspacePoint) {
		if (!isInsideStrikeZone(worldspacePoint))
			return;
		
		UIController.locationSelected(worldSpaceToStrikeZone(worldspacePoint));
	}
	
	// Convert a world space point in pixels to the corresponding point in the strike zone.
	// If the point is inside the strike zone, the X and Y coordinates will be between 0 (lower-left) and 1 (upper-right)
	public Vector2 worldSpaceToStrikeZone(Vector2 worldspacePoint) {
	
		// first, translate the point from world space to local space.
		Vector2 localPoint = transform.InverseTransformPoint(worldspacePoint);
		
		// now, determine where it is within local space from 0 to 1.
		// finally, scale the local point to its location relative to the transform rectangle.
		Vector2 strikeZonePoint = new Vector2(
			(localPoint.x - rect.x) / (float)rect.width,
			(localPoint.y - rect.y) / (float)rect.height
		);
		
		return strikeZonePoint;
	}
	
	public float pixelWidth {
		get { return rect.width; }
	}
}

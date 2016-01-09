using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Button))]
public class StrikeZoneView : MonoBehaviour {
	private FieldingUIController UIController;
	private Button button;
	
	public void setVisible(bool status) {
		button.interactable = status;
		button.image.color = (status) ? Color.white : Color.clear;
	}
	
	void Awake() {
		FieldingMasterController master = FieldingMasterController.getInstance();
		UIController = master.UIController;
		button = GetComponent<Button>();
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
		// start this by getting the strike zone's transform rectangle in pixel coordinates.
		RectTransform rect_transform = transform as RectTransform;
		Rect localRect = rect_transform.rect;
		 
		// finally, scale the local point to its location relative to the transform rectangle.
		Vector2 strikeZonePoint = new Vector2(
			(localPoint.x - localRect.x) / (float)localRect.width,
			(localPoint.y - localRect.y) / (float)localRect.height
		);
		
		return strikeZonePoint;
	}
}

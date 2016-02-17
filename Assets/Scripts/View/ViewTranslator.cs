using UnityEngine;
using System.Collections;

public class ViewTranslator : MonoBehaviour {
	private StrikeZoneView _strikeZoneView;
	private Rect _rect;


	void Awake () {
		_strikeZoneView = StrikeZoneView.GetInstance();
		_rect = ((RectTransform)_strikeZoneView.transform).rect;
	}

	// Convert a world space point in pixels to the corresponding point in the strike zone.
	// If the point is inside the strike zone, the X and Y coordinates will be between 0 (lower-left) and 1 (upper-right)
	public Vector2 ScreenPointToStrikeZone(Vector2 screen_point) {
	
		// first, translate the point from world space to local space.
		Vector2 local_point = transform.InverseTransformPoint(screen_point);
		
		// now, determine where it is within local space from 0 to 1.
		// finally, scale the local point to its location relative to the transform rectangle.
		Vector2 strike_zone_point = new Vector2(
			(local_point.x - _rect.x) / (float)_rect.width,
			(local_point.y - _rect.y) / (float)_rect.height
		);
		
		return strike_zone_point;
	}
	
	public Vector2 StrikeZoneToScreenPoint(Vector2 strike_zone_point) {
		Vector2 local_point = new Vector2(
			strike_zone_point.x * _rect.width  + _rect.x,
			strike_zone_point.y * _rect.height + _rect.y
		);
		
		return transform.TransformPoint(local_point);
	}
	
	public Vector2 StrikeZoneToWorldSpace(Vector2 strike_zone_point) {
		Vector2 screen_point = StrikeZoneToScreenPoint(strike_zone_point);
		
		return Camera.main.ScreenToWorldPoint(screen_point);
	}

	public static ViewTranslator GetInstance() {
		return GameObject.FindGameObjectWithTag("View Translator").GetComponent<ViewTranslator>();
	}
}

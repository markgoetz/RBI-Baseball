using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Button))]
public class StrikeZoneView : MonoBehaviour {
	private FieldingUIController _UIController;
	private Button _button;
	private Rect _rect;
	
	public void SetVisible(bool status) {
		_button.interactable = status;
		_button.image.color = (status) ? Color.white : Color.clear;
	}
	
	void Awake() {
		_UIController = FieldingUIController.GetInstance();
		_button = GetComponent<Button>();
	}
	
	void Start() {		
		RectTransform rect_transform = transform as RectTransform;
		_rect = rect_transform.rect;
	}
	
	public bool IsInsideStrikeZone(Vector2 screen_point) {
		Vector2 strike_zone_point = ScreenPointToStrikeZone(screen_point);
				
		if (strike_zone_point.x < 0 || strike_zone_point.x > 1) {
			return false;
		}
		if (strike_zone_point.y < 0 || strike_zone_point.y > 1) {
			return false;
		}
				
		return true;
	}
	
	public void Clicked() {
		Vector2 screen_point = Input.mousePosition;

		if (!IsInsideStrikeZone(screen_point))
			return;
		
		_UIController.LocationSelected(ScreenPointToStrikeZone(screen_point));
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
	
	public float pixelWidth {
		get { return _rect.width; }
	}
	
	public static StrikeZoneView GetInstance() {
		return GameObject.FindGameObjectWithTag("Strike Zone View").GetComponent<StrikeZoneView>();
	}
}

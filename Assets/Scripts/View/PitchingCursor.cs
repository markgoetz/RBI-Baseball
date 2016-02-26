using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
[RequireComponent (typeof(UICircle))]
public class PitchingCursor : MonoBehaviour {
	private FieldingUIController _UIController;
	private PitcherController _pitcherController;
	private StrikeZoneView _view;
	private bool _insideStrikeZone;
	private bool _visible;
	private RectTransform _rectTransform;
	private UICircle _circle;
	
	private float _strikeZoneWidth;
	
	void Awake () {
		_UIController = FieldingUIController.GetInstance();
		_view = _UIController.strikeZone;
		_pitcherController = PitcherController.GetInstance();
		_rectTransform = GetComponent<RectTransform>();
		_circle = GetComponent<UICircle>();
	}

	void Start() {
		_strikeZoneWidth = _view.pixelWidth;
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		if (!visible) return;
	
		Vector3 screenpoint = Input.mousePosition;
	
		_rectTransform.position = screenpoint;
		
		insideStrikeZone = _view.IsInsideStrikeZone(screenpoint);
		
		// Scale in relation to distance from the sweet spot
		Vector2 strike_zone_location = _view.ScreenPointToStrikeZone(screenpoint);

		float radius = _strikeZoneWidth * _pitcherController.SpreadRadius(strike_zone_location);
		_rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
	}
	
	public void Clicked() {
		if (!active)
			return;
	
		_view.Clicked();
	}
	
	public bool insideStrikeZone {
		get { return _insideStrikeZone; }
		set {
			_insideStrikeZone = value;
			_circle.enabled = active;
		}
	}

	public bool visible {
		get { return _visible; }
		set {
			_visible = value;
			_circle.enabled = active;
		}
	}
	
	public void SetVisible(bool value) {
		_visible = value;
		_circle.enabled = active;
	}
	
	public bool active {
		get { return _visible && _insideStrikeZone; }
	}
	
	void OnDrawGizmos() {
		if (!visible) return;
		
		Vector2 strike_zone_location = _view.ScreenPointToStrikeZone(Input.mousePosition);
		float radius = _pitcherController.SpreadRadius(strike_zone_location);
		
		Gizmos.DrawSphere(_view.StrikeZoneToWorldSpace(strike_zone_location + Vector2.up    * radius), .1f);
		Gizmos.DrawSphere(_view.StrikeZoneToWorldSpace(strike_zone_location + Vector2.down  * radius), .1f);
		Gizmos.DrawSphere(_view.StrikeZoneToWorldSpace(strike_zone_location + Vector2.left  * radius), .1f);
		Gizmos.DrawSphere(_view.StrikeZoneToWorldSpace(strike_zone_location + Vector2.right * radius), .1f);
		
	}
}

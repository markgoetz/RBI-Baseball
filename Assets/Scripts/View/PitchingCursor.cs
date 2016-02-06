using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
[RequireComponent (typeof(Image))]
public class PitchingCursor : MonoBehaviour {
	private FieldingUIController _UIController;
	private PitcherController _pitcherController;
	private StrikeZoneView _view;
	private bool _insideStrikeZone;
	private bool _visible;
	private RectTransform _rectTransform;
	
	private float _strikeZoneWidth;
	
	void Start () {
		_UIController = FieldingUIController.GetInstance();
		_view = _UIController.strikeZone;
		_strikeZoneWidth = _view.pixelWidth;
		_pitcherController = PitcherController.GetInstance();
		_rectTransform = GetComponent<RectTransform>();
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
	
		_view.Clicked(Input.mousePosition);
	}
	
	public bool insideStrikeZone {
		get { return _insideStrikeZone; }
		set {
			_insideStrikeZone = value;
			GetComponent<Image>().enabled = active;
		}
	}

	public bool visible {
		get { return _visible; }
		set {
			_visible = value;
			GetComponent<Image>().enabled = active;
		}
	}
	
	public void SetVisible(bool value) {
		_visible = value;
		GetComponent<Image>().enabled = active;
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

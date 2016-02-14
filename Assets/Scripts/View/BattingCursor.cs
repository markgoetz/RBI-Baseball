using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
[RequireComponent (typeof(Image))]
public class BattingCursor : MonoBehaviour {
	private BatterController _batterController;
	private StrikeZoneView _view;
	private bool _insideStrikeZone;
	private bool _insideRadius;
	private bool _visible;
	private RectTransform _rectTransform;
	
	private float _strikeZoneWidth;
	
	void Start () {
		_batterController = BatterController.GetInstance();
		_rectTransform = GetComponent<RectTransform>();
		_view = StrikeZoneView.GetInstance();
	}
	
	// Move the fielding cursor so that it follows the mouse.
	void Update () {
		if (!visible) return;
	
		Vector3 screenpoint = Input.mousePosition;
	
		_rectTransform.position = screenpoint;
		
		insideStrikeZone = _view.IsInsideStrikeZone(screenpoint);
		
		// Verify that this is inside the radius.
		Vector2 strike_zone_location = _view.ScreenPointToStrikeZone(screenpoint);
		_verifyInsideRadius(strike_zone_location);
	}
	
	private void _verifyInsideRadius(Vector2 strike_zone_location) {
		_insideRadius = _batterController.isInsideRadius(strike_zone_location);
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
	
	public bool insideRadius {
		get { return _insideRadius; }
		set {
			_insideRadius = value;
			GetComponent<Image>().enabled = active;
		}
	}
	
	public void SetVisible(bool value) {
		_visible = value;
		GetComponent<Image>().enabled = active;
	}
	
	public bool active {
		get { return _visible && _insideStrikeZone && _insideRadius; }
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
[RequireComponent (typeof(Image))]
public class BattingRadiusView : MonoBehaviour {
	private bool _visible;
	private float _radius;
	private StrikeZoneView _view;
	
	private RectTransform _rectTransform;
	
	// Use this for initialization
	void Start () {
		_rectTransform = GetComponent<RectTransform>();
		_view = StrikeZoneView.GetInstance();
	}
	
	public void SetVisible(bool value) {
		_visible = value;
		GetComponent<Image>().enabled = _visible;
	}
	
	public void SetStrikeZoneLocation(Vector2 strike_zone_location) {
		_rectTransform.anchorMax = strike_zone_location;
		_rectTransform.anchorMin = strike_zone_location;
	}
	
	public float radius {
		get { return _radius; }
		set {
			_radius = value;
			_rectTransform.sizeDelta = _view.pixelWidth * new Vector2(_radius * 2, _radius * 2);
		}
	}


	public void Clicked() {
		if (!_visible) return;
		_view.Clicked(Input.mousePosition);
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	public GameObject batterSwingIcon;
	
	protected StrikeZoneView _strikeZoneView;
	protected Player _playerStats;
	protected BatterSprite _sprite;
	
	protected Vector2 _swingLocation;
	
	protected bool _swingReady;
	
	public void Reset() {
		_swingReady = false;
	}

	abstract public void PromptForSwing();
	
	public void SetUnready() {
		_swingReady = false;
	}
	
	public bool swingReady {
		get { return _swingReady; }
	}
	
	protected void _Init() {
		_sprite = GetComponent<BatterSprite>();
		_playerStats = new Player();
		_strikeZoneView = StrikeZoneView.GetInstance();
	}
	
	public void Swing() {
		_sprite.PlaySwingAnimation(_swingLocation);
		ShowIcon(_swingLocation);
	}
	
	
	public void ShowIcon(Vector2 location) {	
		Vector2 icon_position = _strikeZoneView.StrikeZoneToWorldSpace(location);
		Instantiate(batterSwingIcon, icon_position, Quaternion.identity);
	}
	
	public static BatterController GetInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
}

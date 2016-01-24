using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	public GameObject batterSwingIcon;
	
	protected StrikeZoneView strike_zone_view;
	protected Player player_stats;
	protected BatterSprite sprite;
	
	protected Vector2 swing_location;
	
	protected bool swing_ready;
	
	public void Reset() {
		swing_ready = false;
	}

	abstract public void PromptForSwing();
	
	public bool swingReady {
		get { return swing_ready; }
	}
	
	protected void _init() {
		sprite = GetComponent<BatterSprite>();
		player_stats = new Player();
		strike_zone_view = StrikeZoneView.getInstance();
	}
	
	public void Swing() {
		sprite.playSwingAnimation(swing_location);
		showIcon(swing_location);
	}
	
	
	public void showIcon(Vector2 location) {	
		Vector2 icon_position = strike_zone_view.strikeZoneToWorldSpace(location);
		Instantiate(batterSwingIcon, icon_position, Quaternion.identity);
	}
	
	public static BatterController getInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
}

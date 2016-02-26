using UnityEngine;
using System.Collections;

abstract public class FieldingUIController : MonoBehaviour {
	public StrikeZoneView strikeZone;
	
	protected void _Init() {
	}
	
	public virtual void LocationSelected(Vector2 location) { }

	public static FieldingUIController GetInstance() {
		return GameObject.FindGameObjectWithTag("UI Controller").GetComponent<FieldingUIController>();
	}
}

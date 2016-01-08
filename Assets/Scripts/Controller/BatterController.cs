using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	abstract public void StartPitch();
	abstract public void PitchAdvanced();
	abstract public void PitchDone();
	
	public static BatterController getInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
}

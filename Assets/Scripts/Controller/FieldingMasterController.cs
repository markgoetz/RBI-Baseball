using UnityEngine;
using System.Collections;

public class FieldingMasterController : MonoBehaviour {
	public FieldingUIController UIController;
	public PitcherController pitcherController;
	public BatterController batterController;
	public GameController gameController;
	
	public static FieldingMasterController getInstance() {
		return GameObject.FindGameObjectWithTag("Master Controller").GetComponent<FieldingMasterController>();
	}
}

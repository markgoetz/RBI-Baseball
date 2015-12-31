using UnityEngine;
using System.Collections;

public class FieldingMasterController : MonoBehaviour {
	public FieldingUIController UIController;
	
	public static FieldingMasterController getInstance() {
		return GameObject.FindGameObjectWithTag("Master Controller").GetComponent<FieldingMasterController>();
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutsView : MonoBehaviour {
	public Text outsText;

	public void SetOuts(int outs) {
		outsText.text = "OUTS: " + outs;
	}

	public static OutsView GetInstance() {
		return GameObject.FindGameObjectWithTag("Outs View").GetComponent<OutsView>();
	}
 }

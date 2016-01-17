using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class PitchIconView : MonoBehaviour {
	private FieldingUIController UIController;
	private Canvas canvas;
	private Button[] icons;
	
	void Awake() {
		icons = GetComponentsInChildren<Button>();
		UIController = FieldingUIController.getInstance();
	}
	
	public void setVisible(bool status) { 
		foreach (Button icon in icons) {
			icon.interactable = status;
			icon.image.color = (status) ? Color.white : Color.clear;
		}
	}
	
	public void pitchIconPressed(int pitch_number) {
		UIController.pitchSelected(pitch_number);
	}
}

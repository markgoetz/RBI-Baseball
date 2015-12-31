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
		
		FieldingMasterController master = FieldingMasterController.getInstance();
		UIController = master.UIController;
	}
	
	public void enable() { }
	public void disable() { }
	
	public void hide() { 
		foreach (Button icon in icons) {
			icon.interactable = false;
			icon.image.color = Color.clear;
		}
	}
	
	public void pitchIconPressed(int pitch_number) {
		UIController.pitchSelected(pitch_number);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class PitchIconView : MonoBehaviour {
	private FieldingUIController _UIController;
	private Canvas _canvas;
	private Button[] _icons;
	
	void Awake() {
		_icons = GetComponentsInChildren<Button>();
		_UIController = FieldingUIController.GetInstance();
	}
	
	public void SetVisible(bool status) { 
		foreach (Button icon in _icons) {
			icon.interactable = status;
			icon.image.color = (status) ? Color.white : Color.clear;
		}
	}
	
	public void PitchIconPressed(int pitch_number) {
		_UIController.PitchSelected(pitch_number);
	}
}

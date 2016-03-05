using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Sprite))]
public class ResultDebugStrikeZoneView : MonoBehaviour {
	public float delayAfterIcon;

	private bool _done;

	void Awake() {
		_done = false;
	}


	public void Display(Vector2 location) {
		StartCoroutine(_DisplayCoroutine(location));
	}

	private IEnumerator _DisplayCoroutine(Vector2 location) {
		_done = false;

		yield return new WaitForSeconds(delayAfterIcon);

		_done = true;
	}

	public bool Done {
		get { return _done; }
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PitchResultView : MonoBehaviour {
	public Text strikeText;
	public Text ballText;
	public Text foulText;
	public float flashDuration;
	public float flashInterval;

	private bool _isDone;

	public void DisplayResult(PitchResult result) {
		_isDone = false;

		switch (result.type) {
			case PitchResultType.Ball:
				StartCoroutine(_FlashTextCoroutine(ballText));
				break;
			case PitchResultType.Foul:
				StartCoroutine(_FlashTextCoroutine(foulText));
				break;
			case PitchResultType.Strike:
				StartCoroutine(_FlashTextCoroutine(strikeText));
				break;
			case PitchResultType.InPlay:
				_isDone = true;
				break;
		}
	}

	private IEnumerator _FlashTextCoroutine(Text t) {
		t.enabled = true;

		float time = 0;

		while (time < flashDuration) {
			if (time % flashInterval < (flashInterval * .5f)) {
				t.enabled = true;
			}
			else {
				t.enabled = false;
			}

			yield return null;
			time += Time.deltaTime;
		}
		t.enabled = false;
		_isDone = true;
	}

	public bool IsDone {
		get { return _isDone; }
	}



	public static PitchResultView GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result View").GetComponent<PitchResultView>();
	}
}

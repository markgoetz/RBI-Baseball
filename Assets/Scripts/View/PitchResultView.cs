using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PitchResultView : MonoBehaviour {
	public Image pitchIcon;
	public Image swingIcon;
	public Text strikeText;
	public Text ballText;
	public Text foulText;
	public float flashDuration;
	public float flashInterval;

	private bool _isDone;

	public void Start() {
		_hideAll();
	}

	public void DisplayResult(Vector2 pitch_location, Vector2 swing_location, PitchResult result) {
		_isDone = false;

		_moveStrikeZoneIcon(pitchIcon, pitch_location);
		_moveStrikeZoneIcon(swingIcon, swing_location);

		_setStrikeZoneIcon(pitchIcon, true);
		_setStrikeZoneIcon(swingIcon, true);

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
				_FinishView();
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

		_FinishView();
	}

	private void _FinishView() {
		_hideAll();
		_isDone = true;
	}

	public bool IsDone {
		get { return _isDone; }
	}

	private void _setStrikeZoneIcon(Image img, bool visible) {
		img.enabled = visible;
	}

	private void _moveStrikeZoneIcon(Image img, Vector2 location) {
		img.rectTransform.anchorMax = location;
		img.rectTransform.anchorMin = location;
	}

	private void _hideAll() {
		_hideNotifications();
		_hideIcons();
	}

	private void _hideNotifications() {
		strikeText.enabled = false;
		ballText.enabled = false;
		foulText.enabled = false;
	}

	private void _hideIcons() {
		_setStrikeZoneIcon(pitchIcon, false);
		_setStrikeZoneIcon(swingIcon, false);
	}

	public static PitchResultView GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result View").GetComponent<PitchResultView>();
	}
}

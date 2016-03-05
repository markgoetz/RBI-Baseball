using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class ResultDebugBallHitView : MonoBehaviour {
	public Vector2 scaleVector;

	private Vector2 _startPosition;
	private bool _animating;

	void Start () {
		_startPosition = transform.position;
		_animating = false;
	}

	public void DisplayResult(BallHit hit) {
		StartCoroutine(DisplayResultCoroutine(hit));
	}

	private IEnumerator DisplayResultCoroutine(BallHit hit) {
		_animating = true;
		float elapsed_time = 0;

		Vector2 _endPosition = _startPosition + Vector2.Scale(hit.endPosition, scaleVector);

		while (elapsed_time < hit.time) {
			transform.position = Vector2.Lerp(_startPosition, _endPosition, elapsed_time / hit.time);

			elapsed_time += Time.deltaTime;
			yield return null;
		}

		_animating = false;
	}

	private void ResetPosition() {
		transform.position = _startPosition;
	}

	public bool Done {
		get { return !_animating; }
	}

	public static ResultDebugBallHitView GetInstance() {
		return GameObject.FindGameObjectWithTag("Ball Hit View").GetComponent<ResultDebugBallHitView>();
	}
}

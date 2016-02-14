using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteFader : MonoBehaviour {
	public float fadeTime;
	
	private SpriteRenderer _sprite;

	void Awake () {
		_sprite = GetComponent<SpriteRenderer>();
	}

	void Start() {
		StartCoroutine("FadeOutCoroutine");
	}
	
	private IEnumerator FadeOutCoroutine() {
		yield return new WaitForSeconds(fadeTime);
		Destroy(gameObject);
	}
}

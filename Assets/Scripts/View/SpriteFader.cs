using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteFader : MonoBehaviour {
	public float fadeTime;
	
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		
		StartCoroutine("FadeOutCoroutine");
	}
	
	private IEnumerator FadeOutCoroutine() {
		yield return new WaitForSeconds(fadeTime);
		Destroy(gameObject);
	}
}

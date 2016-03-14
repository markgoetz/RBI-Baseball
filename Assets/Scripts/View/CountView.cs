using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountView : MonoBehaviour {
	public Text ballText;
	public Text strikeText;

	public void UpdateCount(Count count) {
		ballText.text = "BALLS: " + count.balls;
		strikeText.text = "STRIKES: " + count.strikes;
	}

	public static CountView GetInstance() {
		return GameObject.FindGameObjectWithTag("Count Controller").GetComponent<CountView>();
	}
}

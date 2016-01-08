using UnityEngine;
using UnityEngine.UI;

public class BaseRunnerView : MonoBehaviour {
	public Sprite playerRunnerImage;
	public Sprite enemyRunnerImage;
	
	private bool is_player;
	
	public void setIsPlayer(bool status) {
		is_player = status;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

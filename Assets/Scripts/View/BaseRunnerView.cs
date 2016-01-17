using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(BaseRunnerController))]
public class BaseRunnerView : MonoBehaviour {
	public Sprite playerRunnerSprite;
	public Sprite enemyRunnerSprite;
	
	public Image firstBase;
	public Image secondBase;
	public Image thirdBase;
	
	private Sprite runner_sprite;
	
	private BaseRunnerController controller;
	
	private bool is_player;
	
	public void setIsPlayer(bool status) {
		is_player = status;
		runner_sprite = (is_player) ? playerRunnerSprite : enemyRunnerSprite;
		
		firstBase.sprite  = runner_sprite;
		secondBase.sprite = runner_sprite;
		thirdBase.sprite  = runner_sprite;
	}
	
	void Start() {
		controller = GetComponent<BaseRunnerController>();
	}
	
	void Update () {
	
	}
	
	private void updateView() {	
		// TODO: Tween this shit
		BaseRunners runners = controller.baseRunners;
		firstBase.color  = (runners.FirstBase)  ? Color.white : Color.clear;
		secondBase.color = (runners.SecondBase) ? Color.white : Color.clear;
		thirdBase.color  = (runners.ThirdBase)  ? Color.white : Color.clear;
	}
}

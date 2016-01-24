using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(BaseRunnerController))]
public class BaseRunnerView : MonoBehaviour {
	public Sprite playerRunnerSprite;
	public Sprite enemyRunnerSprite;
	
	public Image firstBase;
	public Image secondBase;
	public Image thirdBase;
	
	private Sprite _runnerSprite;
	
	private BaseRunnerController _controller;
	
	private bool _isPlayer;
	
	public void SetIsPlayer(bool status) {
		_isPlayer = status;
		_runnerSprite = (_isPlayer) ? playerRunnerSprite : enemyRunnerSprite;
		
		firstBase.sprite  = _runnerSprite;
		secondBase.sprite = _runnerSprite;
		thirdBase.sprite  = _runnerSprite;
	}
	
	void Start() {
		_controller = GetComponent<BaseRunnerController>();
	}
	
	void Update () {
	
	}
	
	private void _updateView() {	
		// TODO: Tween this shit
		BaseRunners runners = _controller.baseRunners;
		firstBase.color  = (runners.firstBase)  ? Color.white : Color.clear;
		secondBase.color = (runners.secondBase) ? Color.white : Color.clear;
		thirdBase.color  = (runners.thirdBase)  ? Color.white : Color.clear;
	}
}

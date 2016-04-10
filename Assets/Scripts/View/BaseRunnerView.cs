using UnityEngine;
using UnityEngine.UI;

public class BaseRunnerView : MonoBehaviour {
	public Sprite playerRunnerSprite;
	public Sprite enemyRunnerSprite;
	
	public Image firstBase;
	public Image secondBase;
	public Image thirdBase;
	
	private Sprite _runnerSprite;

	private bool _isPlayer;
	
	public void SetIsPlayer(bool status) {
		_isPlayer = status;
		_runnerSprite = (_isPlayer) ? playerRunnerSprite : enemyRunnerSprite;
		
		firstBase.sprite  = _runnerSprite;
		secondBase.sprite = _runnerSprite;
		thirdBase.sprite  = _runnerSprite;
	}
	
	public void UpdateView(BaseRunners runners) {	
		// TODO: Tween this shit
		firstBase.color  = (runners.firstBase  != null) ? Color.white : Color.clear;
		secondBase.color = (runners.secondBase != null) ? Color.white : Color.clear;
		thirdBase.color  = (runners.thirdBase  != null) ? Color.white : Color.clear;
	}

	static public BaseRunnerView GetInstance() {
		return GameObject.FindGameObjectWithTag("BaseRunners").GetComponent<BaseRunnerView>();
	}
}
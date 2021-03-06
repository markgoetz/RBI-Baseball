﻿using UnityEngine;
using System.Collections;

public class ResultDebugController : MonoBehaviour {

	public Character pitcher;
	public Character batter;

	private ResultDebugUIController _uiController;

	private PitchResultCalculator _calculator;

	// Use this for initialization
	void Awake () {
		_calculator = new PitchResultCalculator();
		_uiController = ResultDebugUIController.GetInstance() as ResultDebugUIController;
		pitcher = Character.GetCharacter();
		batter  = Character.GetCharacter();
	}

	void Start() {
		StartCoroutine(GameLoop());
	}
	
	private IEnumerator GameLoop() {
		while (true) {
			while (!_uiController.resultReady) {
				yield return null;
			}


			BallHit ball_hit = _calculator.GetBallHit(
				pitcher,
				_uiController.pitchLocation,
				batter,
				_uiController.swingLocation
			);

			_uiController.DisplayResult(ball_hit);

			while (!_uiController.resultDone) {
				yield return null;
			}

			_uiController.Clear();
		}
	}
}

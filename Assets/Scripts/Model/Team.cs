using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team {
	public List<Character> sPitchers;
	public List<Character> rPitchers;
	public List<Character> Catchers;
	public List<Character> FirstBases;
	public List<Character> SecondBases;
	public List<Character> ThirdBases;
	public List<Character> ShortStops;
	public List<Character> RightFields;
	public List<Character> CenterFields;
	public List<Character> LeftFields;
	public Dictionary<Position,List<Character>> roster;

	public Team GetTeam() {
		Team t = new Team();

		int sPitcherCount = 4;
		for(int i=0;i<sPitcherCount;i++) {
			t.sPitchers.Add(new Character());
		}

		int rPitcherCount = 4;
		for(int i=0;i<rPitcherCount;i++) {
			t.rPitchers.Add(new Character());
		}

		int catcherCount = 2;
		for(int i=0;i<catcherCount;i++) {
			t.Catchers.Add(new Character());
		}

		int firstBaseCount = 2;
		for(int i=0;i<firstBaseCount;i++) {
			t.FirstBases.Add(new Character());
		}

		int secondBaseCount = 2;
		for(int i=0;i<secondBaseCount;i++) {
			t.SecondBases.Add(new Character());
		}

		int thirdBaseCount = 2;
		for(int i=0;i<thirdBaseCount;i++) {
			t.ThirdBases.Add(new Character());
		}

		int shortStopCount = 2;
		for(int i=0;i<shortStopCount;i++) {
			t.ShortStops.Add(new Character());
		}

		int rightFieldCount = 2;
		for(int i=0;i<rightFieldCount;i++) {
			t.RightFields.Add(new Character());
		}

		int centerFieldCount = 2;
		for(int i=0;i<centerFieldCount;i++) {
			t.CenterFields.Add(new Character());
		}

		int leftFieldCount = 2;
		for(int i=0;i<leftFieldCount;i++) {
			t.LeftFields.Add(new Character());
		}

		return t;
	}
}

using UnityEngine;
using System;
using System.Collections;

public class Viking_Boss : MonoBehaviour {

	enum Attack {none, running, wait, charge, spin};

	private Attack next_attack = Attack.none;
	private System.Random random = new System.Random ();
	private Attack[] attacks;

	// Use this for initialization
	void Start () {
		attacks = (Attack[])Enum.GetValues (typeof(Attack));
	}
	
	// Update is called once per frame
	void Update () {
		if (next_attack == Attack.none) {
			next_attack = (Attack)attacks.GetValue (random.Next (attacks.Length - 1) + 1);
			DoAttack ();
		}
	}

	void DoAttack () {
		//Do Stuff
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {

	public int pointsForBumper;
	public float multiplierScale; 
	private ScoreKeeper ScoringObject;
	public GameObject bumper;
	public GameObject ball;

//	void Awake(){
//		ScoringObject = gameObject.Find("Main_Camera");
//	}

	// Use this for initialization
	void Start () {
		ScoringObject = GameObject.Find ("Camera").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {

//		if (ScoringObject.TotalScore > 50) {
//			Destroy (bumper);
//		}
	}

	void OnCollisionEnter (Collision collision) {
		float oldMult = ScoringObject.GetMultiplier ();
		if (collision.gameObject.name == ball.name) {
			//Destroy (bumper);
			ScoringObject.Score (pointsForBumper);
			ScoringObject.SetMultiplier (oldMult += multiplierScale);
			//print (ScoringObject.GetMultiplier());	
		}
	}
}

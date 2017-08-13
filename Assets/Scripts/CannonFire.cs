using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour {

	GameManager gameManager;
	public GameObject cannonBallPref;

	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	Vector3 GetVector(){
		
		int direction = GetComponent<Cannon> ().GetCannonDirection ();

		Vector3 result = new Vector3(0,0,0);

		if (direction == -45) {
			result = new Vector3 (-1, 0, 1);
		}
		if (direction == 0) {
			result = new Vector3 (0, 0, 1);
		}
		if (direction == 45) {
			result = new Vector3 (1, 0, 1);
		}
		if (direction == 135) {
			result = new Vector3 (1, 0, -1);
		}
		if (direction == 180) {
			result = new Vector3 (0, 0, -1);
		}
		if (direction == 225) {
			result = new Vector3 (-1, 0, -1);
		}
		return result;
	}

	GameObject[] GetTargets(){
		Vector3 position = this.transform.position;
		int reach = GetComponent<Cannon> ().reach;
		GameObject[] tiles = new GameObject[reach + 1];
		GameObject targetPlayer = gameManager.GetIdlePlayer ();
		float xOffset = GetVector ().x;
		float zOffset = GetVector ().z;

		for (int i = 1; i < reach + 1; i++) {
			int x = (int)(position.x + (xOffset * i));
			int z = (int)(position.z + (zOffset * i));
			GameObject tile = targetPlayer.GetComponent<DeckManager> ().RetrieveTile (x, z);
			if (tile != null) {
				tiles [i] = tile;
			}
		}
		return tiles;
	}

	public void ApplyDamage(){
		foreach (GameObject i in GetTargets ()){
			if (i != null) {
				i.GetComponentInChildren<DeckTile> ().TakeDamage (GetComponent<Cannon>().damage);
			}
		}
		GetComponent<Cannon> ().SetAmmo (0);
		FireCannonBall ();
	}

	void FireCannonBall(){
		Vector3 dir = GetVector ();
		GameObject cannonBall;
		cannonBall = GameObject.Instantiate (cannonBallPref, transform.position, Quaternion.identity);
		cannonBall.GetComponent<CannonBall> ().Setup (GetComponent<Cannon> ().reach, dir);

	}
		//Cannon coordinate
		//new tile array [reach]
		//for (int i = 0; i < reach + 1; i++)
		//DeckManager.RetrieveTile(cannon coordinate + vector)
		//if not null, add to target array

}

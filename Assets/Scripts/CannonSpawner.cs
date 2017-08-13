using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawner : MonoBehaviour {

	public GameObject cannonPrefab;
	public GameObject player;
	public GameObject cannonManager;

	// Use this for initialization
	void Start () {
		CreateCannon ();
		Destroy (this.gameObject);
	}

	void CanonSpawner(GameObject newPlayer, GameObject newCannonManager){
		player = newPlayer;
		cannonManager = newCannonManager;
	}

	void CreateCannon(){
		GameObject cannon;
		cannon = GameObject.Instantiate (cannonPrefab, this.transform.position, Quaternion.identity);
		cannon.GetComponent<Cannon> ().SetUp (player, cannonManager.GetComponent<CannonManager>().cannonNumber + 1);
	}
}

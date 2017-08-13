using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour {

	public Material[] playerColors;
	public int playerNumber;
	public GameObject gameManager;
	public GameObject ammoObject;
	public GameObject woodObject;
	GameObject tile;

	public bool hasAmmo;
	public bool hasWood;
	int id;
	bool awake;



	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		hasAmmo = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PickUpAmmo(){
		hasAmmo = true;
		ammoObject.SetActive (true);
	}

	public void DropAmmo(){
		hasAmmo = false;
		ammoObject.SetActive (false);
	}

	public void PickUpWood(){
		hasWood = true;
		woodObject.SetActive (true);
	}

	public void DropWood(){
		hasWood = false;
		woodObject.SetActive (false);
	}

	void OnMouseDown(){
		gameManager.GetComponent<ClickHandler2> ().ClickedOn(this.gameObject);

	}

	public void PlacePirate(GameObject tile){
		this.transform.position = tile.transform.position;
	}

	public bool ViableDestination(GameObject player, GameObject tile){
		//check if tile is on player's boat
		bool result = false;
		if (tile.GetComponent<DeckTile> ().GetPlayerNum() == playerNumber) {
			result = true;
		}
		return result;
	}

	public void SetUp(GameObject player){
		playerNumber = player.GetComponent<Player> ().playerNumber;
		GetComponent<Renderer> ().material = playerColors [playerNumber];
	}

	public void SetAwake(){
		awake = true;
		transform.rotation = Quaternion.Euler(0,0,0);
	}

	public void SetAsleep(){
		awake = false;
		transform.rotation = Quaternion.Euler(90,0,0);
	}

	public void Die(){
		Destroy(this);
		Debug.Log ("I'm heading to Neptunes table me mateys");
	}

	public bool BelongsToPlayer(GameObject player){
		if (player.GetComponent<Player> ().playerNumber == playerNumber) {
			return true;
		} else {
			return false;
		}
	}
		
}

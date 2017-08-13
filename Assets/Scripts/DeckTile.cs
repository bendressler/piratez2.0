using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTile : MonoBehaviour {

	public int xPos;
	public int zPos;
	public int health;
	public Material[] materials;
	bool destroyed;
	GameObject[] pirates;
	GameObject gameManager;
	int playerNumber;
	bool isBusy;

	// Use this for initialization
	void Start () {
		health = 2;
		UpdateSprite ();
		gameManager = GameObject.Find ("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
		UpdateSprite ();
	}

	void OnMouseDown(){
		gameManager.GetComponent<ClickHandler2> ().ClickedOn(this.gameObject);
	}

	public void Repair(){
		if (health < 2) {
			health += 1;
		}
	}

	public void TakeDamage(int damage){
		health -= damage;
		if (health < 0) {
			health = 0;
		}

	}

	public int GetPlayerNum(){
		return playerNumber;
	}

	public void SetUp(int x, int z, int playerNum){
		xPos = x;
		zPos = z;
		playerNumber = playerNum;
	}
		

	void UpdateSprite(){
		GetComponent<Renderer> ().material = materials[health];
	}
}

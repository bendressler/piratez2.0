using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour {

	int playerNumber;
	int direction;
	int directionOffset;
	int cannonID;
	public int damage;
	public int reach;
	GameObject gameManager;
	public GameObject turret;
	public int ammo;
	public GameObject[] ammoArray;

	void Start(){
		gameManager = GameObject.Find ("GameManager");
		reach = 0;
		damage = 1;
	}

	void Update(){
		reach = ammo + 1;
	}

	public void SetUp(GameObject player, int id){
		playerNumber = player.GetComponent<Player>().playerNumber;
		direction = 0;
		if (playerNumber == 1) {
			directionOffset = 180;
		}
		turret.transform.rotation = Quaternion.Euler(0,(direction + directionOffset),0);
	}

	void OnMouseDown(){
		gameManager.GetComponent<ClickHandler2> ().ClickedOn(this.gameObject);
	}

	public void PlaceCannon(GameObject tile){
		this.transform.position = tile.transform.position;
	}

	public bool ViableDestination(GameObject player, GameObject tile){
		//check if tile is on player's boat and in the front row
		bool result = false;
		if (tile.GetComponent<DeckTile> ().GetPlayerNum() == playerNumber) {
			if (playerNumber == 0) {
				if (tile.transform.position.z == player.GetComponent<DeckManager> ().deckHeight-1) {
					result = true;
				}
			} else if (playerNumber == 1) {
				if (tile.transform.position.z == player.GetComponent<Player> ().posOffsetZ) {
					result = true;
				}
			}
		}
		return result;
	}

	public bool BelongsToPlayer(GameObject player){
		if (player.GetComponent<Player> ().playerNumber == playerNumber) {
			return true;
		} else {
			return false;
		}
	}

	public void TurnLeft(){
		if ((direction == 0) || (direction == 45)) {
			direction -= 45;
			gameManager.GetComponent<TurnManager> ().SpendMoves (gameManager.GetComponent<MovementCost>().GetMovementCost("Turn Cannon"));
		}
		turret.transform.rotation = Quaternion.Euler(0,(direction + directionOffset),0);

	}

	public void TurnRight(){
		if ((direction == -45) || (direction == 0)) {
			direction += 45;
			gameManager.GetComponent<TurnManager> ().SpendMoves (gameManager.GetComponent<MovementCost>().GetMovementCost("Turn Cannon"));
		}
		turret.transform.rotation = Quaternion.Euler(0,(direction + directionOffset),0);

	}

	public int GetCannonDirection(){
		return direction + directionOffset;
	}

	void UpdateCannonBalls(){
		foreach (GameObject i in ammoArray) {
			i.SetActive (false);
		}
		for (int i = 0; i < ammo; i++) {
			ammoArray[i].SetActive (true);
		}
	}

	public void SetAmmo(int newAmmo){
		ammo = newAmmo;
		UpdateCannonBalls ();
	}

	public void AddAmmo(){
		if (ammo <= 3) {
			ammo += 1;
			UpdateCannonBalls ();
		}
	}


}

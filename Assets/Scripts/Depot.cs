using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depot : MonoBehaviour {

	int playerNumber;
	GameObject gameManager;
	public string depotType;
	MovementCost movementCost;


	void Start(){
		gameManager = GameObject.Find ("GameManager");
		movementCost = gameManager.GetComponent<MovementCost> ();
	}


	public void SetUp(GameObject player){
		playerNumber = player.GetComponent<Player>().playerNumber;

	}


	void OnMouseDown(){
		gameManager.GetComponent<ClickHandler2> ().ClickedOn(this.gameObject);
	}


	public void PlaceDepot(GameObject tile){
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


	public bool BelongsToPlayer(GameObject player){
		if (player.GetComponent<Player> ().playerNumber == playerNumber) {
			return true;
		} else {
			return false;
		}
	}


	public void Distribute(GameObject pirate){

		Player activePlayer = gameManager.GetComponent<GameManager>().activeShip.GetComponent<Player> ();

		Pirate pir = pirate.GetComponent<Pirate> ();

		if (depotType == "Ammo") {
			
			if (activePlayer.movesLeft >= movementCost.GetMovementCost("Take Ammo")) {
				
				if (!pir.hasAmmo && !pir.hasWood) {
				
					pir.PickUpAmmo ();
					gameManager.GetComponent<TurnManager> ().SpendMoves (movementCost.GetMovementCost ("Take Ammo"));
				}
			}
		}

		if (depotType == "Wood") {

			if (activePlayer.movesLeft >= movementCost.GetMovementCost("Take Wood")) {
			
				if (!pir.hasAmmo && !pir.hasWood) {
				
					pir.PickUpWood ();
					gameManager.GetComponent<TurnManager> ().SpendMoves (movementCost.GetMovementCost ("Take Wood"));
				}
			}
		}
	}
}

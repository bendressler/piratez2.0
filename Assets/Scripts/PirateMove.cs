using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMove : MonoBehaviour {

	GameObject selectedPirate;
	GameObject selectedTile; 


	void Update(){
	}


	public void SelectPirate(GameObject pirate){
		int activePlayerId = GetComponent<GameManager> ().activeShip.GetComponent<Player> ().playerNumber;
		if (pirate.GetComponent<Pirate> ().playerNumber == activePlayerId) {
			selectedPirate = pirate;
		}
	}


	public void SelectTile(GameObject tile){
		DeckTile deckTile = tile.GetComponent<DeckTile> ();
		if (selectedPirate != null) {
			if (deckTile.health > 0) {
				selectedTile = tile;
			}
		}
	}

	public void MovePirate(){
		if (selectedPirate != null) {
			if (selectedTile != null) {
				if (CheckNeighbor (selectedPirate, selectedTile)) {
					selectedPirate.transform.position = selectedTile.transform.position;
					GetComponent<TurnManager> ().SpendMoves (GetComponent<MovementCost>().GetMovementCost("Walk"));
					if (selectedTile.GetComponentInChildren<DeckTile> ().health < 2) {
						GetComponent<GameManager>().activeShip.GetComponent<PirateManager> ().ShowPirateMenu ();

					}
					selectedPirate = null;
					selectedTile = null;
				}
			}
		}
	}



	public bool CheckNeighbor(GameObject pirate, GameObject tile){
		float xDif = Mathf.Abs(pirate.transform.position.x - tile.transform.position.x);
		float zDif = Mathf.Abs(pirate.transform.position.z - tile.transform.position.z);

		if ((xDif <= 1) && (zDif <= 1)) {
			return true;
		} else {
			return false;
		}
	}

}

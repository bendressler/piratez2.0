using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

	bool battlePhase;
	public int currentTurn;

	Player playerOne;
	Player playerTwo;
	GameObject activePlayer;
	public int movesLeft;

	public Text moves;

	void Start(){
		activePlayer = GetComponent<GameManager> ().activeShip;
		movesLeft = activePlayer.GetComponent<Player> ().maxMoves;
	}

	public void NewTurn(GameObject player){
		currentTurn += 1;
		player.GetComponent<Player> ().movesLeft = player.GetComponent<Player> ().maxMoves;
		movesLeft = player.GetComponent<Player> ().movesLeft;
		activePlayer = player;
		moves.text = movesLeft.ToString ();
	}

	public bool CanMove(int moves){
		if (movesLeft >= moves) {
			return true;
		} else {
			return false;
		}
	}

	public void SpendMoves(int movesSpent){
		movesLeft -= movesSpent;
		activePlayer.GetComponent<Player> ().movesLeft = movesLeft;
		moves.text = movesLeft.ToString ();
	}


}

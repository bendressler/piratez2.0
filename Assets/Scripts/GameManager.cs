using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject activeShip;
	public Button swapPlayer;
	public bool buildPhase;
	public bool battlePhase;
	public GameObject buildPanel;
	public GameObject battlePanel;

	void Start(){
		swapPlayer.GetComponent<Button> ().onClick.AddListener (SwapTurn);
		buildPhase = true;
		battlePhase = false;
	}

	void Update(){
	}


	void SwapTurn(){
		if (activeShip == playerOne) {
			activeShip = playerTwo;
			playerTwo.GetComponent<Player> ().isActive = true;
			playerOne.GetComponent<Player> ().isActive = false;
			GetComponent<TurnManager> ().NewTurn (playerTwo);

		} else {
			activeShip = playerOne;
			playerTwo.GetComponent<Player> ().isActive = false;
			playerOne.GetComponent<Player> ().isActive = true;
			GetComponent<TurnManager> ().NewTurn (playerOne);

		}
		BroadcastMessage ("SwapPlayer", SendMessageOptions.DontRequireReceiver);
	}

	public void EndBuildPhase(){
		buildPanel.SetActive (false);
		battlePanel.SetActive (true);
		buildPhase = false;
		battlePhase = true;
		GetComponent<ClickHandler2> ().battlePhase = true;
		SwapTurn ();
	}

	public GameObject GetActivePlayer(){
		return activeShip;
	}

	public GameObject GetIdlePlayer(){
		if (activeShip == playerOne) {
			return playerTwo;
		} else {
			return playerOne;
		}
	}
}

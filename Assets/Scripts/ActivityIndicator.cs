using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityIndicator : MonoBehaviour {

	public GameManager gameManager;
	public GameObject player;
	public GameObject sphere;

	void Start(){
		PositionIndicator ();
	}

	void Update(){
		if (gameManager.activeShip == player) {
			sphere.SetActive (true);
		} else {
			sphere.SetActive (false);
		}
	}

	void PositionIndicator(){
		DeckManager deck = player.GetComponent<DeckManager> ();
		int xOffset = player.GetComponent<Player> ().posOffsetX;
		int zOffset = player.GetComponent<Player> ().posOffsetZ;
		this.transform.position = new Vector3((deck.deckBreadth + xOffset + 1),0,(Mathf.RoundToInt(deck.deckHeight / 2) + zOffset));
	}
}

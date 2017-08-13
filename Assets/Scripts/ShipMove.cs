using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipMove : MonoBehaviour {

	GameObject gameManager;
	public Button moveLeft;
	public Button moveRight;

	void Start(){
		moveLeft.GetComponent<Button> ().onClick.AddListener (MoveLeft);
		moveRight.GetComponent<Button> ().onClick.AddListener (MoveRight);
		gameManager = GameObject.Find ("GameManager");
	}

	void MoveLeft(){
		if (gameManager.GetComponent<GameManager> ().activeShip == this.gameObject) {
			if (gameManager.GetComponent<TurnManager> ().CanMove (gameManager.GetComponent<MovementCost>().GetMovementCost("Move Ship"))) {
				this.transform.position = new Vector3 (this.transform.position.x - 1, 0, this.transform.position.z);
				GetComponent<Player> ().posOffsetX -= 1;
				gameManager.GetComponent<TurnManager> ().SpendMoves (gameManager.GetComponent<MovementCost>().GetMovementCost("Move Ship"));
			}
		}
	}

	void MoveRight(){
		if (gameManager.GetComponent<GameManager> ().activeShip == this.gameObject) {
			if (gameManager.GetComponent<TurnManager> ().CanMove (gameManager.GetComponent<MovementCost> ().GetMovementCost ("Move Ship"))) {
				this.transform.position = new Vector3 (this.transform.position.x + 1, 0, this.transform.position.z);
				GetComponent<Player> ().posOffsetX += 1;
				gameManager.GetComponent<TurnManager> ().SpendMoves (gameManager.GetComponent<MovementCost> ().GetMovementCost ("Move Ship"));
			}

		}
	}
}

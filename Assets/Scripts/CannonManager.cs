using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonManager : MonoBehaviour {

	public int cannonNumber;
	public int cannonsCreated;
	public GameObject[] cannons;
	public Transform cannonParent;
	public GameObject cannonPrefab;
	public GameObject selectedCannon;
	GameObject gameManager;
	MovementCost cost;

	public GameObject cannonPanel;
	public Button turnLeft;
	public Button turnRight;
	public Button cannonExit;
	public Button fire;

	void Start(){
		cannonsCreated = 0;
		cannons = new GameObject[cannonNumber];
		selectedCannon = null;
		gameManager = GameObject.Find ("GameManager");
		cost = gameManager.GetComponent<MovementCost> ();

		cannonExit.GetComponent<Button> ().onClick.AddListener (HideCannonMenu);
		turnLeft.GetComponent<Button> ().onClick.AddListener (CannonTurnLeft);
		turnRight.GetComponent<Button> ().onClick.AddListener (CannonTurnRight);
		fire.GetComponent<Button> ().onClick.AddListener (CannonFire);
	}

	public GameObject CreateCannon(Transform pos){
		
			GameObject newCannon;
			newCannon = GameObject.Instantiate (cannonPrefab, pos.position, Quaternion.identity) as GameObject;
			newCannon.transform.parent = cannonParent;
			newCannon.GetComponent<Cannon> ().SetUp (GetComponent<Player> ().gameObject, cannonsCreated + 1);
			return newCannon;
	}

	public bool CannonSlotsLeft(){
		
		bool result = false;
		if (cannonsCreated < cannonNumber) {
			result = true;
		}
		return result;

	}

	public void SelectCannon(GameObject cannon, GameObject player){
		if (cannon.GetComponent<Cannon> ().BelongsToPlayer (player)) {
			selectedCannon = cannon;
		}
	}

	public void ShowCannonMenu(){
		
		cannonPanel.SetActive (true);
	
	}

	public void HideCannonMenu(){
		cannonPanel.SetActive (false);
		selectedCannon = null;
	}

	void CannonTurnLeft(){
		if (GetComponent<Player> ().isActive) {
			if (GetComponent<Player> ().movesLeft >= cost.GetMovementCost("Turn Cannon")) {
				selectedCannon.GetComponent<Cannon> ().TurnLeft ();
			}
		}
	}

	void CannonTurnRight(){
		if (GetComponent<Player> ().isActive) {
			if (GetComponent<Player> ().movesLeft >= cost.GetMovementCost("Turn Cannon")) {
				selectedCannon.GetComponent<Cannon> ().TurnRight ();
			}
		}

	}

	void CannonFire(){
		if (GetComponent<Player> ().isActive) {
			if (selectedCannon.GetComponent<Cannon> ().ammo > 0) {
				if (GetComponent<Player> ().movesLeft >= cost.GetMovementCost ("Fire Cannon")) {
					selectedCannon.GetComponent<CannonFire> ().ApplyDamage ();
					gameManager.GetComponent<TurnManager> ().SpendMoves (cost.GetMovementCost ("Fire Cannon"));
				}
			}
		}
	}

	public bool BuildUpDone(){
		if (cannonsCreated >= cannonNumber) {
			return true;
		} else {
			return false;
		}
	}
}

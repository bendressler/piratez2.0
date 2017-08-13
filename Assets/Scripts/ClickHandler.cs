using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour {

	public GameObject previousSelection;
	public GameObject currentSelection;

	public GameObject cannon;
	public GameObject pirate;
	public GameObject tile;

	bool cannonCreation;

	/*

	void Start(){
		placeCannon.GetComponent<Button>().onClick.AddListener(CannonSelection);
		cannonCreation = false;


	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (currentSelection != null) {
				if (previousSelection == null) {
					if (currentSelection.CompareTag ("Pirate")) {
						GetComponent<PirateMove> ().SelectPirate (currentSelection);
					}
					if (currentSelection.CompareTag ("Cannon")) {
						ShowCannonMenu ();
					}
				}
				else if (previousSelection.CompareTag ("Pirate")) {
					if (currentSelection.CompareTag ("Pirate")) {
						GetComponent<PirateMove> ().SelectPirate (currentSelection);

					}
					if (currentSelection.CompareTag ("Cannon")) {
						//GetComponent<PirateMove> ().SelectTile (currentSelection.GetComponent<Cannon>().GetTile());
					}
					if (currentSelection.CompareTag ("Tile")) {
						GetComponent<PirateMove> ().SelectTile (currentSelection);
					}
				}

				else if (previousSelection.CompareTag ("Tile")) {
					if (currentSelection.CompareTag ("Pirate")) {
						GetComponent<PirateMove> ().SelectPirate (currentSelection);
					}
					if (currentSelection.CompareTag ("Cannon")) {
						ShowCannonMenu ();
					}
				}
				else if (previousSelection.CompareTag ("Cannon")) {
					if (currentSelection.CompareTag ("Tile")) {
						if (cannonCreation) {
							if(previousSelection.GetComponent<Cannon> ().ViableDestination(GetComponent<GameManager>().activeShip,currentSelection)){
							previousSelection.GetComponent<Cannon> ().PlaceCannon (currentSelection);
							cannonCreation = false;
							}
						}
					}
					if (currentSelection.CompareTag ("Cannon")) {
						ShowCannonMenu ();
					}
				}

			}
		}
	}
		
	void CannonSelection(){
		GameObject newCannon;
		CannonManager cannons = GetComponent<GameManager> ().activeShip.GetComponent<CannonManager> ();
		if (cannons.CannonSlotsLeft ()) {
			newCannon = cannons.CreateCannon (this.transform);
			currentSelection = newCannon;
			cannonCreation = true;	
		}

	}

	public void UpdateSelection(GameObject newSelection){
		previousSelection = currentSelection;
		currentSelection = newSelection;
	}

	public void PurgeSelection(){
		previousSelection = null;
		currentSelection = null;
	}

*/





}

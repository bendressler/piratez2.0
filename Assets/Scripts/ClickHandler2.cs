using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler2 : MonoBehaviour {

	public GameObject previousSelection;
	public GameObject currentSelection;
	public bool battlePhase;
	GameObject activePlayer;
	TurnManager turnManager;


	void Start(){
		
		battlePhase = GetComponent<GameManager>().battlePhase;
		activePlayer = GetComponent<GameManager> ().activeShip;
		turnManager = GetComponent<TurnManager> ();

	}
		

	public void ClickedOn(GameObject clicked){
		
		activePlayer = GetComponent<GameManager> ().activeShip;

		previousSelection = currentSelection;
		currentSelection = clicked;

		if (battlePhase) {
			
			if (currentSelection.CompareTag ("Tile")) {
				
				if (previousSelection.CompareTag ("Pirate")) {
					
					if (previousSelection.GetComponent<Pirate> ().BelongsToPlayer (activePlayer)) {
						
						if (turnManager.CanMove (GetComponent<MovementCost> ().GetMovementCost ("Walk"))) {
							
							GetComponent<PirateMove> ().SelectTile (currentSelection);
							GetComponent<PirateMove> ().MovePirate ();
						}
					}
				}
			}

			if (currentSelection.CompareTag ("Cannon")) {
				
				Cannon cannon = currentSelection.GetComponent<Cannon> ();

				if (previousSelection.CompareTag ("Pirate")) {
					
					Pirate pirate = previousSelection.GetComponent<Pirate> ();

					if (GetComponent<PirateMove> ().CheckNeighbor (previousSelection, currentSelection)) {
						
						if (turnManager.CanMove (GetComponent<MovementCost>().GetMovementCost("Load Cannon"))) {
							
							if (pirate.BelongsToPlayer (activePlayer)) {
								
								if (pirate.hasAmmo) {
									
									if (cannon.ammo < 4) {
										
										pirate.DropAmmo ();
										cannon.AddAmmo ();
										turnManager.SpendMoves (GetComponent<MovementCost> ().GetMovementCost ("Load Cannon"));
									}
								}
							}
						}
					}
				} else if (cannon.BelongsToPlayer (activePlayer)) {
					
					activePlayer.GetComponent<CannonManager> ().SelectCannon (currentSelection, activePlayer);
					activePlayer.GetComponent<CannonManager> ().ShowCannonMenu ();
				}
			}


			if (currentSelection.CompareTag ("Pirate")) {
				
				PirateManager pirateManager = activePlayer.GetComponent<PirateManager> ();

				if (currentSelection.GetComponent<Pirate> ().BelongsToPlayer (activePlayer)) {
					
					GetComponent<PirateMove> ().SelectPirate (currentSelection);
					pirateManager.SelectPirate (currentSelection, activePlayer);

					if (pirateManager.CanRepair (currentSelection)) {
						
						pirateManager.ShowPirateMenu ();
					}
				}
			}
				
			if (currentSelection.CompareTag ("Depot")) {
				
				if (previousSelection.CompareTag ("Pirate")) {
					
					if (previousSelection.GetComponent<Pirate> ().BelongsToPlayer (activePlayer)) {
						
						if (GetComponent<PirateMove> ().CheckNeighbor (previousSelection, currentSelection)) {
							
							currentSelection.GetComponent<Depot> ().Distribute (previousSelection);
						}
					}
				}

			}
		}
			if (!battlePhase) {
			
				if (currentSelection.CompareTag ("Tile")) {
				
					GetComponent<BuildManager> ().Deploy (currentSelection);
				}
			}
	}
	

	public void PurgeSelection(){
		previousSelection = null;
		currentSelection = null;
	}

	void SwapPlayer(){
		activePlayer.GetComponent<CannonManager> ().HideCannonMenu ();
		activePlayer = GetComponent<GameManager> ().activeShip;
	}

}



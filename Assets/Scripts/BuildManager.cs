using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	bool buildingDone;

	public Player playerOne;
	public Player playerTwo;
	GameObject activePlayer;
	GameObject cannonToDeploy;
	GameObject pirateToDeploy;
	GameObject ammoDepotToDeploy;
	GameObject woodDepotToDeploy;


	public Button placeCannon;
	public Button placePirate;
	public Button placeAmmoDepot;
	public Button placeWoodDepot;


	public Text cannons;
	public Text pirates;
	public Text ammoDepots;
	public Text woodDepots;

	void Start(){
		buildingDone = false;
		placeCannon.GetComponent<Button> ().onClick.AddListener (SetUpCannon);
		placePirate.GetComponent<Button> ().onClick.AddListener (SetUpPirate);
		placeAmmoDepot.GetComponent<Button> ().onClick.AddListener (SetUpAmmoDepot);
		placeWoodDepot.GetComponent<Button> ().onClick.AddListener (SetUpWoodDepot);

		activePlayer = GetComponent<GameManager> ().activeShip;
		playerOne = GetComponent<GameManager> ().playerOne.GetComponent<Player>();
		playerTwo = GetComponent<GameManager> ().playerTwo.GetComponent<Player>();

	}

	void Update(){

		DepotManager depotManager = activePlayer.GetComponent<DepotManager> ();
		CannonManager cannonManager = activePlayer.GetComponent<CannonManager> ();
		PirateManager pirateManager = activePlayer.GetComponent<PirateManager> ();

		cannons.text = cannonManager.cannonsCreated.ToString();
		pirates.text = activePlayer.GetComponent<PirateManager> ().piratesCreated.ToString();
		ammoDepots.text = depotManager.ammoDepotsCreated.ToString();
		woodDepots.text = depotManager.woodDepotsCreated.ToString();

		if (!buildingDone) {
			
			if (playerOne.GetComponent<PirateManager>().BuildUpDone() && playerOne.GetComponent<CannonManager>().BuildUpDone() && playerOne.GetComponent<DepotManager>().BuildUpDone()){
				
				if (playerTwo.GetComponent<PirateManager>().BuildUpDone() && playerTwo.GetComponent<CannonManager>().BuildUpDone() && playerTwo.GetComponent<DepotManager>().BuildUpDone()){
					
						buildingDone = true;
						GetComponent<GameManager> ().EndBuildPhase ();
				}
			}
		}
	}


	public void SetUpCannon(){

		CannonManager cannonManager = activePlayer.GetComponent<CannonManager> ();

		if (cannonManager.cannonsCreated < cannonManager.cannonNumber) {
			
			cannonToDeploy = cannonManager.CreateCannon (this.transform);
		}
	}


	public void SetUpPirate(){

		PirateManager pirateManager = activePlayer.GetComponent<PirateManager> ();

		if (pirateManager.piratesCreated < pirateManager.crewSize) {
			
			pirateToDeploy = pirateManager.CreatePirate (this.transform);
		}
	}


	public void SetUpAmmoDepot(){

		DepotManager depotManager = activePlayer.GetComponent<DepotManager> ();

		if (depotManager.ammoDepotsCreated < depotManager.ammoDepotNumber) {
			
			ammoDepotToDeploy = depotManager.CreateAmmoDepot (this.transform);
		}
	}


	public void SetUpWoodDepot(){
		
		DepotManager depotManager = activePlayer.GetComponent<DepotManager> ();

		if (depotManager.woodDepotsCreated < depotManager.woodDepotNumber) {
			
			woodDepotToDeploy = depotManager.CreateWoodDepot (this.transform);
		}
	}


	public void Deploy(GameObject tile){

		if (cannonToDeploy != null) {

			Cannon cannon = cannonToDeploy.GetComponent<Cannon> ();

			if (cannon.ViableDestination (activePlayer, tile)) {
				cannon.PlaceCannon (tile);
				cannonToDeploy = null;
				activePlayer.GetComponent<CannonManager> ().cannonsCreated += 1;
			}

		} else if (pirateToDeploy != null) {

			Pirate pirate = pirateToDeploy.GetComponent<Pirate> ();

			if (pirate.ViableDestination (activePlayer, tile)) {
				pirate.PlacePirate (tile);
				activePlayer.GetComponent<PirateManager> ().piratesCreated += 1;
				pirateToDeploy = null;
			}
		}

		else if (ammoDepotToDeploy != null) {

			Depot depotAmmo = ammoDepotToDeploy.GetComponent<Depot> ();

			if (depotAmmo.ViableDestination (activePlayer, tile)) {
				depotAmmo.PlaceDepot (tile);
				activePlayer.GetComponent<DepotManager> ().ammoDepotsCreated += 1;
				ammoDepotToDeploy = null;
			}
		}

		else if (woodDepotToDeploy != null) {

			Depot depotWood = woodDepotToDeploy.GetComponent<Depot> ();

			if (depotWood.ViableDestination (activePlayer, tile)) {
				depotWood.PlaceDepot (tile);
				activePlayer.GetComponent<DepotManager> ().woodDepotsCreated += 1;
				woodDepotToDeploy = null;
			}
		}
	}


	void SwapPlayer(){
		activePlayer = GetComponent<GameManager> ().activeShip;
	}



}

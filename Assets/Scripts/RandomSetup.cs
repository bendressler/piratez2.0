using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSetup : MonoBehaviour {

	public Button randomSetup;
	GameObject gameManager;
	BuildManager buildManager;
	public GameObject player1;
	public GameObject player2;

	void Start(){
		randomSetup.GetComponent<Button> ().onClick.AddListener (RandomSetUp);
		gameManager = GameObject.Find ("GameManager");
		buildManager = gameManager.GetComponent<BuildManager> ();

	}

	void RandomSetUp(){
		RandomSetUpPlayer (player1);
		RandomSetUpPlayer (player2);
	}

	void RandomSetUpPlayer(GameObject player){
		CreateCannons(player);
		CreatePirates (player);
		CreateDepots (player);
	}



	void CreateDepots(GameObject player){

		DepotManager depotManager = player.GetComponent<DepotManager> ();
		DeckManager deckManager = player.GetComponent<DeckManager> ();
		Vector3[] positions = GetDepotPositions(player);

		for (int i = 0; i < (depotManager.ammoDepotNumber + depotManager.woodDepotNumber); i++) {
			
			if (depotManager.ammoDepotsCreated < depotManager.ammoDepotNumber) {
				
				GameObject depotToDeploy = depotManager.CreateAmmoDepot (player.transform);
				int xPos = (int)positions [i].x;
				int zPos = (int)positions [i].z;
				depotToDeploy.GetComponent<Depot> ().PlaceDepot (deckManager.RetrieveTile (xPos, zPos));
				depotManager.ammoDepotsCreated += 1;

			} else {
				
				GameObject depotToDeploy = depotManager.CreateWoodDepot (player.transform);
				int xPos = (int)positions [i].x;
				int zPos = (int)positions [i].z;
				depotToDeploy.GetComponent<Depot> ().PlaceDepot (deckManager.RetrieveTile (xPos, zPos));
				depotManager.woodDepotsCreated += 1;
			}
		}
	}


	Vector3[] GetDepotPositions(GameObject player){

		DeckManager deckManager = player.GetComponent<DeckManager> ();
		CannonManager cannonManager = player.GetComponent<CannonManager> ();

		Vector3[] result = new Vector3[cannonManager.cannonNumber];
		float[] xPosUsed = new float[cannonManager.cannonNumber];
		float zPos = 0;

		if (player == player1) {
			
			zPos = deckManager.deckHeight - (deckManager.deckHeight );

		} else if (player == player2) {
			
			zPos = player.GetComponent<Player> ().posOffsetZ + (deckManager.deckHeight - 1);
		}

		for (int i = 0; i < result.Length; i++) {
			
			float newX = GetRandomX (player, xPosUsed);
			xPosUsed [i] = newX;
			result [i] = new Vector3 (newX, 0, zPos);
		}

		return result;
	}


	void CreateCannons(GameObject player){

		DeckManager deckManager = player.GetComponent<DeckManager> ();
		CannonManager cannonManager = player.GetComponent<CannonManager> ();
		
		Vector3[] positions = GetCannonPositions(player);

		for (int i = 0; i < cannonManager.cannonNumber; i++) {
			
			GameObject cannonToDeploy = cannonManager.CreateCannon (player.transform);
			int xPos = (int)positions [i].x;
			int zPos = (int)positions [i].z;
			cannonToDeploy.GetComponent<Cannon>().PlaceCannon(deckManager.RetrieveTile(xPos,zPos));
			cannonManager.cannonsCreated += 1;
		}
	}


 	Vector3[] GetCannonPositions(GameObject player){
		
		Vector3[] result = new Vector3[player.GetComponent<CannonManager> ().cannonNumber];
		float[] xPosUsed = new float[player.GetComponent<CannonManager> ().cannonNumber];
		float zPos = 0;

		if (player == player1) {
			
			zPos = player.GetComponent<DeckManager> ().deckHeight - 1;

		} else if (player == player2) {

			zPos = player.GetComponent<Player> ().posOffsetZ;
		}

		for (int i = 0; i < result.Length; i++) {
			
			float newX = GetRandomX (player, xPosUsed);
			xPosUsed [i] = newX;
			result [i] = new Vector3 (newX, 0, zPos);
		}

		return result;
	}


	void CreatePirates(GameObject player){

		PirateManager pirateManager = player.GetComponent<PirateManager> ();
		Vector3[] positions = GetPiratePositions(player);

		for (int i = 0; i < pirateManager.crewSize; i++) {
			
			GameObject pirateToDeploy = pirateManager.CreatePirate (player.transform);
			int xPos = (int)positions [i].x;
			int zPos = (int)positions [i].z;
			pirateToDeploy.GetComponent<Pirate>().PlacePirate(player.GetComponent<DeckManager>().RetrieveTile(xPos,zPos));
			pirateManager.piratesCreated += 1;

		}
	}


	Vector3[] GetPiratePositions(GameObject player){
		
		Vector3[] result = new Vector3[player.GetComponent<PirateManager> ().crewSize];
		float[] xPosUsed = new float[player.GetComponent<PirateManager> ().crewSize];
		float zPos = 0;

		if (player == player1) {
			
			zPos = player.GetComponent<DeckManager> ().deckHeight - 2;

		} else if (player == player2) {
			
			zPos = player.GetComponent<Player> ().posOffsetZ + 1;
		}

		for (int i = 0; i < result.Length; i++) {
			
			float newX = GetRandomX (player, xPosUsed);
			xPosUsed [i] = newX;
			result [i] = new Vector3 (newX, 0, zPos);
		}

		return result;
	}


	float GetRandomX(GameObject player,float[] xPosUsed){
		
		float result = 0;
		bool ready = false;

		while (!ready) {
			
			result = Random.Range (0, player.GetComponent<DeckManager> ().deckBreadth);
			ready = true;
			foreach (float f in xPosUsed) {
				if (result == f) {
					ready = false;
				}
			}
		}

		return result;
	}


	void RemoveParts(){

	}
}

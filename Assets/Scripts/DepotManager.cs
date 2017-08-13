using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepotManager : MonoBehaviour {

	public int ammoDepotNumber;
	public int ammoDepotsCreated;
	public int woodDepotNumber;
	public int woodDepotsCreated;
	public GameObject[] ammoDepots;
	public GameObject[] woodDepots;

	public Transform depotParent;
	public GameObject ammoDepotPrefab;
	public GameObject woodDepotPrefab;

	public GameObject gameManager;

	void Start(){
		ammoDepotsCreated = 0;
		ammoDepots = new GameObject[ammoDepotNumber];
		woodDepotsCreated = 0;
		woodDepots = new GameObject[woodDepotNumber];
		gameManager = GameObject.Find ("GameManager");
	}

	public GameObject CreateAmmoDepot(Transform pos){
		GameObject newDepot;
		newDepot = GameObject.Instantiate (ammoDepotPrefab, pos.position, Quaternion.identity) as GameObject;
		newDepot.transform.parent = depotParent;
		newDepot.GetComponent<Depot> ().SetUp (GetComponent<Player> ().gameObject);
		return newDepot;
	}

	public GameObject CreateWoodDepot(Transform pos){
		GameObject newDepot;
		newDepot = GameObject.Instantiate (woodDepotPrefab, pos.position, Quaternion.identity) as GameObject;
		newDepot.transform.parent = depotParent;
		newDepot.GetComponent<Depot> ().SetUp (GetComponent<Player> ().gameObject);
		return newDepot;
	}

	public bool BuildUpDone(){
		bool result = false;
		if (ammoDepotsCreated >= ammoDepotNumber) {
			if (woodDepotsCreated >= woodDepotNumber) {
				result = true;
			}
		}
		return result;
	}


}

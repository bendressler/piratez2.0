using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {

	public int deckBreadth;
	public int deckHeight;
	public GameObject deckTile;
	public Transform deckParent;
	public GameObject[] tileArray;
	public GameObject owner;

	// Use this for initialization
	void Start () {
		BuildDeck ();
		owner = this.gameObject;
		//GetComponent<PirateManager> ().BuildCrew ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BuildDeck(){
		int totalTiles = deckBreadth * deckHeight;
		int currentTile = 0;
		tileArray = new GameObject[totalTiles];
		for (int i = 0; i < deckBreadth; i++) {
			for (int j = 0; j < deckHeight; j++) {
				GameObject tile = CreateTile (i, j);
				tileArray [currentTile] = tile;
				currentTile += 1;

			}
		}
	}

	GameObject CreateTile(int posX, int posZ){
		GameObject newTile;
		int offsetX = GetComponent<Player> ().posOffsetX;
		int offsetZ = GetComponent<Player> ().posOffsetZ;

		newTile = GameObject.Instantiate (deckTile, new Vector3 (posX + offsetX, 0, posZ + offsetZ), Quaternion.identity);
		newTile.transform.parent = deckParent;
		newTile.GetComponentInChildren<DeckTile> ().SetUp (posX, posZ, GetComponent<Player>().playerNumber);
		return newTile;
	}

	public GameObject RetrieveTile(int xPos, int zPos){
		GameObject targetTile = null;

		foreach (GameObject i in tileArray) {
			if ((i.transform.position.x) == xPos) {
				if ((i.transform.position.z) == zPos) {
					targetTile = i;
				}
			}
		}
		return targetTile;
	}
}

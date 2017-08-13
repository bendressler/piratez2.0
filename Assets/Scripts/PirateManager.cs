using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateManager : MonoBehaviour {

	public int crewSize;
	public GameObject[] crew;
	public GameObject pirate;
	public Transform crewParent;
	public int piratesCreated;
	GameObject selectedPirate;

	public GameObject piratePanel;
	public Button pirateExit;
	public Button repairBtn;
	GameObject gameManager;
	MovementCost movementCost;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		movementCost = gameManager.GetComponent<MovementCost> ();
		pirateExit.GetComponent<Button> ().onClick.AddListener (HidePirateMenu);
		repairBtn.GetComponent<Button> ().onClick.AddListener (Repair);

	}

	// Update is called once per frame
	void Update () {
		
	}

	public GameObject CreatePirate(Transform pos){

		GameObject newPirate;
		newPirate = GameObject.Instantiate (pirate,pos.position,Quaternion.identity) as GameObject;
		newPirate.transform.parent = crewParent;
		newPirate.GetComponent<Pirate> ().SetUp (GetComponent<Player> ().gameObject);
		return newPirate;
	}

	public bool BuildUpDone(){
		if (piratesCreated >= crewSize) {
			return true;
		} else {
			return false;
		}
	}

	public void ShowPirateMenu(){
		piratePanel.SetActive (true);

	}

	public void HidePirateMenu(){
		piratePanel.SetActive (false);
		selectedPirate = null;
	}


	public void SelectPirate(GameObject pirate, GameObject player){
		if (pirate.GetComponent<Pirate> ().BelongsToPlayer (player)) {
			selectedPirate = pirate;
		}
	}

	public GameObject ReturnTile(GameObject pirate){
		int pirX = (int)pirate.transform.position.x;
		int pirZ = (int)pirate.transform.position.z;
		DeckManager deck = GetComponent<DeckManager> ();

		GameObject tile = deck.RetrieveTile (pirX, pirZ);
		return tile;
	}

	public bool CanRepair(GameObject pirate){
		bool result = false;
		GameObject tile = ReturnTile (pirate);
		if (tile.GetComponentInChildren<DeckTile> ().health < 2) {
			result = true;
		}
		return result;
	}

	public void Repair(){


		
		if (GetComponent<Player> ().isActive) {
			
			if (GetComponent<Player> ().movesLeft >= movementCost.GetMovementCost ("Repair")) {
				
				if (selectedPirate.GetComponent<Pirate> ().hasWood) {
					
					selectedPirate.GetComponent<Pirate> ().DropWood ();
					ReturnTile (selectedPirate).GetComponentInChildren<DeckTile> ().Repair ();
					gameManager.GetComponent<TurnManager> ().SpendMoves (movementCost.GetMovementCost ("Repair"));
				}
			}
		}
	}

}

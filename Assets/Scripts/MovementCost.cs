using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCost : MonoBehaviour {

	Dictionary<string,int> movementCostList = new Dictionary<string,int>();

	void Start(){

		movementCostList.Add ("Walk", 1);
		movementCostList.Add ("Take Ammo", 1);
		movementCostList.Add ("Take Wood",1);
		movementCostList.Add ("Load Cannon",1);
		movementCostList.Add ("Repair",2);
		movementCostList.Add ("Turn Cannon",3);
		movementCostList.Add ("Move Ship",5);
		movementCostList.Add ("Fire Cannon",4);

	}

	public int GetMovementCost(string action){
		int result;
		result = movementCostList[action];
		return result;
	}


}

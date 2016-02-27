using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text;

	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom
	};
	
	private States myState;
			
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		switch(myState) {
			case States.cell: state_cell();
				break;
			case States.sheets_0: state_sheets_0();
				break;
			case States.sheets_1: state_sheets_1();
				break;
			case States.lock_0: state_lock_0();
				break;
			case States.lock_1: state_lock_1();
				break;
			case States.mirror: state_mirror();
				break;
			case States.cell_mirror: state_cell_mirror();
				break;
			case States.freedom: state_freedom();
				break;
		}
	}
	
	void state_cell () {
		text.text = "You're in the prison cell, and you want to escape. " + 
				"There are some dirty-ass sheets on the bed, a mirror on the wall, " + 
				"and the door is locked from the outside.\n\n" +
				"Press S to view Sheets, M to view Mirror, L to view Lock.";
								
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		
		if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
		
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	
	void state_sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " + 
				"time somebody changed them. The pleasures of prison life " + 
				"I guess!\n\n" +
				"Press R to Return to roaming your cell.";
				
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_sheets_1 () {
		text.text = "Mirror doesn't make sheets any cleaner.\n\n" + 
				"Press R to Return to roaming your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_0 () {
		text.text = "It's a button lock. You don't know the pin. " + 
			"You wish you could see the dirty fingerprints on them!\n\n" + 
				"Press R to Return to roaming your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_lock_1 () {
		text.text = "You put the mirror through the bars, and turn it around. " + 
			"You can open the lock.\n\n" + 
				"Press O to Open, R to Return to your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
		
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
	}
	
	void state_mirror () {
		text.text = "Mirror is loose. Wanna take?\n\n" + 
				"Press T to Take, R to Return to your cell.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
		
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_cell_mirror () {
		text.text = "You're still in the cell but now you have a mirror. " + 
			"Press S to view Sheets, L to view Lock.";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		}
		
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	void state_freedom () {
		text.text = "You're free, press P to play again.";
		
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}	
}

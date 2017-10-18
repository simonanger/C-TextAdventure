using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    public Text text;

  private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, 
			sheets_1, lock_1, freedom, hallway_0, escape_0, right, sword_hallway, hallway_1,
			attack_0, run};
  private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();
		} else if (myState == States.sheets_1) {
			state_sheets_1 ();
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		} else if (myState == States.lock_1) {
			state_lock_1 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror ();
		} else if (myState == States.hallway_0) {
			state_hallway_0 ();
		} else if (myState == States.escape_0) {
			state_escape_0 ();
		} else if (myState == States.right) {
			state_right (); }
		else if (myState == States.freedom) {
			state_freedom();
		} else if (myState == States.sword_hallway) {
			state_sword_hallway();
		} else if (myState == States.hallway_1) {
			state_hallway_1();
		} else if (myState == States.attack_0) {
			state_attack_0();
		} else if (myState == States.run) {
			state_run();
		}

	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from the outside.\n\n" +
			"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) {myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;}
	}
	void state_mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
			"Press T to Take the mirror, or R to Return to cell" ;
		if (Input.GetKeyDown(KeyCode.T)) {myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
			"time somebody changed them. The pleasures of prison life " +
			"I guess!\n\n" +
			"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
			"any better.\n\n" +
			"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}
	void state_lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
			"combination is. You wish you could somehow see where the dirty " +
			"fingerprints were, maybe that would help.\n\n" +
			"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
			"so you can see the lock. You can just make out fingerprints around " +
			"the buttons. You press the dirty buttons, and hear a click.\n\n" +
			"Press O to Open, or R to Return to your cell" ;
		if (Input.GetKeyDown(KeyCode.O)) {myState = States.hallway_0;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}
	void state_cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
			"some dirty sheets on the bed, a mark where the mirror was, " +
			"and that pesky door is still there, and firmly locked!\n\n" +
			"Press S to view Sheets, or L to view Lock" ;
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_1;}
	}

	void state_hallway_0() {
		text.text = "You make it out safe. After looking left and right it seems no ones " +
					"about. The exit appears to be on the left but you can see " +
					"something glimmering to your right. Should you investigate?\n\n" +
					"Press L to head Left, or R to head right"; 
		if (Input.GetKeyDown(KeyCode.L)) {myState = States.escape_0;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.right;}
	}

	void state_hallway_1() {
		text.text = "You realise you're at a dead end. You're only option is to head back " +
			"and run toward the exit. Filled with hope you run as fast as you can. " +
			"You are running for what feels like forever. Suddenly " +
			"you are knocked down! As you look up, you realise you are at the feet of a demon. " +
			"With nothing to defend yourself you are stuck down.\n\n" +
			"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}

	void state_escape_0() {
		text.text = "You make a run for it and head left. Smelling the fresh air you're " +
					"filled with hope. The corridor is longer than originally appeared " +
					"and you seem to be running for what feels like forever. Suddenly " +
					"you are knocked down! As you look up, you realise you are at the feet of a demon. " +
					"With nothing to defend yourself you are struck down.\n\n" +
					"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}

	void state_right() {
		text.text = "You head right to see what is glimmering in the corner. " +
					"As you get closer, you realise it is a sword. Should you take it?\n\n" +
					"Press T to Take the sword, L to leave it";
			if (Input.GetKeyDown(KeyCode.T)) {myState = States.sword_hallway;}
			else if (Input.GetKeyDown(KeyCode.L)) {myState = States.hallway_1;}
	}

	void state_sword_hallway() {
		text.text = "You've taken the sword and realise you're at a dead end. " +
			"The only option now is to run back towards the exit. " +
			"Filled with hope, you move as fast as you can. You're running for what feels " +
			"like forever. Suddenly you are knocked down! As you look up, you realise that " +
			"you are at the feet of a demon. It looks like it is ready to strike. " +
			"It seems you're only option is to fight!\n\n" +
			"Press A to Attack, or R to try and run";
		if (Input.GetKeyDown(KeyCode.A)) {myState = States.attack_0;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.run;}
	}

	void state_run() {
		text.text = "You try to run going as fast as you can but it seems " +
			"you are no match for the demons speed and you are struck down.\n\n" +
			"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}

	void state_attack_0() {
		text.text = "You strike the demon with everything you have and appear to mortally " +
			"it. Seeing you're chance you run passed the fallen demon and make a dash to the exit. " +
			"Against all odds you have made it out and are free!\n\n" +
			"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}

	void state_freedom() {
		text.text = "You are FREE!\n\n" +
			"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}








}
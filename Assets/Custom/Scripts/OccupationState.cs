using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains the occupation information of a cube in the game area

public class OccupationState {
	public enum Type {
		Unoccupied, Occupied, LayerClear
	};
	Type type;

	// id of 0 indicates no id
	int id;

	public OccupationState (Type t = Type.Unoccupied, int i = 0) {
		type = t;
		id = i;
	}

	public bool Unoccupied () {
		return type == Type.Unoccupied;
	}
	public bool Occupied (int ignoreId = 0) {
		if (type == Type.Occupied && id == ignoreId) {
			return false;
		}
		return !Unoccupied();
	}
	public bool OccupiedByBlock () {
		return type == Type.Occupied;
	}

	public int GetID () {
		return id;
	}
}
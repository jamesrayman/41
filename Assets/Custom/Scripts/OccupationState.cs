using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains the occupation information of a cube in the game area

public class OccupationState {
	public enum Type {
		Unoccupied, Layed, Planted, LayerClear
	};
	Type type;

	// id of 0 indicates no id
	int id;

	public OccupationState (Type t = Type.Unoccupied, int i = 0) {
		type = t;
		id = i;
	}

	// is this spot completely unoccupied?
	public bool Unoccupied () {
		return type == Type.Unoccupied;
	}

	// ignoring the unplanted block ignoreId, is this spot occupied?
	public bool Occupied (int ignoreId = 0) {
		if (type == Type.Layed && id == ignoreId) {
			return false;
		}
		return !Unoccupied();
	}

	public bool OccupiedByBlock () {
		return type == Type.Layed || type == Type.Planted;
	}
	public bool OccupiedByPlantedBlock () {
		return type == Type.Planted;
	}

	public int GetID () {
		return id;
	}
}
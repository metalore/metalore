using UnityEngine;
using System.Collections;

public enum Side {
	NOREAST,
	EAST,
	SOUEST,
	SOUWEST,
	WEST,
	NORWEST
}

public class HexTile {
	//	Fields
	protected int id;
	protected HexTile[] neighbors = new HexTile[6];

	//	Constructor
	public HexTile (int id) {
		this.id = id;
	}

	//	Methods
	public int getId () {
		return id;
	}

	public void setNeighbor (HexTile tile, Side side) {
		neighbors [side] = tile;
	}

	public HexTile[] getNeighbors () {
		return neighbors;
	}

	public HexTile getNeighbor (Side side) {
		return neighbors [side];
	}
}

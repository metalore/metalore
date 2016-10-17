using UnityEngine;
using System.Collections;

public class TileMap
{
	public Tile[] tiles;
	public int radius;
	private int dia;

	public void NewMap (int radius)
	{
		this.radius = radius;
		dia = 2 * radius + 1;

		tiles = new Tile[dia * dia];

		CreateTiles ();
	}

	void CreateTiles ()
	{
		for (var i = 0; i < dia; ++i) {
			for (var j = 0; j < dia; ++j) {
				int x = i - radius;
				int y = j - radius;

				Tile tile;

				if (Mathf.Abs (x + y) > radius) {
					var tmp = new VoidTile ();
					tile = tmp;
				} else if (x == 0 && y == 0) {
					var tmp = new OreTile ();
					tile = tmp;
				} else {
					var tmp = new PlayTile ();
					tile = tmp;
				}

				tile.SetX (x);
				tile.SetY (y);

				tiles [i * dia + j] = tile;
			}
		}
	}

	void SetNeighbors () {
		for (var i = 0; i < dia; ++i) {
			for (var j = 0; j < dia; ++j) {
				var tile = tiles [j * dia + i];
				if (tile.GetType () != typeof (VoidTile)) {
					var left = 0 == i;
					var right = dia - 1 == i;
					var top = 0 == j;
					var bottom = dia - 1 == j;

					if (!top) {
						tile.AddNeighbor (TileSides.NorWest, tiles [(j - 1) * dia + i]);
						if (!right)
							tile.AddNeighbor (TileSides.NorEast, tiles [(j - 1) * dia + i + 1]);
					}
					if (!left)
						tile.AddNeighbor (TileSides.West, tiles [j * dia + i - 1]);
					if (!right)
						tile.AddNeighbor (TileSides.East, tiles [j * dia + i + 1]);
					if (!bottom) {
						tile.AddNeighbor (TileSides.SouEast, tiles[(j + 1) * dia + i]);
						if (!left)
							tile.AddNeighbor (TileSides.SouWest, tiles[(j + 1) * dia + i - 1]);
					}
				}
			}
		}
	}
}

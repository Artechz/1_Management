﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	public Sprite floorSprite;

	World world;

	// Use this for initialization
	void Start () {
		//Creates tiles in 'data' format; not visually (empty tiles).
		world = new World (); 

		//Create a GameObject for each of our tiles, so they show visually.
		for (int x = 0; x < world.Width; x++) {
			for (int y = 0; y < world.Height; y++) {
				Tile tile_data = world.GetTileAt (x, y);

				GameObject tile_go = new GameObject ();
				tile_go.name = "Tile_" + x + "_" + y;
				tile_go.transform.position = new Vector3 (tile_data.X, tile_data.Y, 0);
				tile_go.transform.SetParent (this.transform, true);

				//Add a sprite renderer, but don't bother setting a sprite bc all tiles are empty (now).
				tile_go.AddComponent<SpriteRenderer>();

				tile_data.RegisterTileTypeChangedCallback ( (tile) => { OnTyleTypeChanged (tile, tile_go); } );

			}
		}

		world.RandomizeTiles ();
	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnTyleTypeChanged(Tile tile_data, GameObject tile_go) {
		if (tile_data.Type == Tile.TileType.Floor) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = floorSprite;
		} else if (tile_data.Type == Tile.TileType.Empty) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = null;
		} else {
			Debug.LogError ("OnTileTypeChanged - Unrecognized tile type.");
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TooltipContent : MonoBehaviour
{
    // classes
    [System.Serializable]
    public struct TileDescription
    {
        public string name;
        public string description;
        public TileEvent tileEvent;
        public CollisionType collisionType;
    }
    [System.Serializable] 
    public struct EditorTile
    {
        public string name;
        public Tile tile;
        public string description;
        public TileEvent tileEvent;
        public CollisionType collisionType;
    }

    [Header("Hexagon Neighbors")]

    [SerializeField] private Vector3Int[] evenTileNeighbors;
    [SerializeField] private Vector3Int[] oddTileNeighbors;

    [Header("References")] 

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private FollowMouse selection;
    [SerializeField] private GameObject moveActionIndicator;
    [SerializeField] private Player player;

    [Header("Texts")] 

    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text descriptionLabel;

    [Header("Tile Dictionary")] 

    [SerializeField] private EditorTile[] tilesEditor;
    [SerializeField] private TileDescription missingTile;
    public Dictionary<Tile, TileDescription> Tiles { get; } = new Dictionary<Tile, TileDescription>();

    // tile
    private Tile currentTile;
    private Tile newTile;

    public Vector3Int currentTilePos; 

    // other 
    private TileDescription tooltipTile;
    private Vector3Int relativeGridCoords;

    // click actions 
    public ClickAction leftClickAction;
    public ClickAction rightClickAction;

    public TileDescription MissingTile => missingTile;

    private void Awake()
    {
        /* convert tilesEditor Array to tiles Dict */
        foreach (EditorTile item in tilesEditor)
        {
            Tiles.Add(item.tile, new TileDescription { name = item.name, description = item.description, tileEvent = item.tileEvent, collisionType = item.collisionType });
        }
    }

    private void Update()
    {
        /* if it focuses a new tile type, update the tooltip info */
        newTile = tilemap.GetTile(selection.gridCoords) as Tile; 
        if(newTile != currentTile)
        {
            currentTile = newTile;
            try
            {
                tooltipTile = Tiles[newTile];
            }
            catch (Exception) { 
                tooltipTile = missingTile;
            }
            nameLabel.text = tooltipTile.name;
            descriptionLabel.text = tooltipTile.description;
        }

        // if it focuses a new tile
        if (selection.gridCoords != currentTilePos)
        {
            currentTilePos = selection.gridCoords;

            //Debug.Log(currentTilePos);

            /* if all values of the selection vector are between -1 and 1, set the leftclickaction to move */
            relativeGridCoords = selection.gridCoords - player.gridCoords;
            Debug.Log(player.gridCoords.x % 2);
            Debug.Log(selection.gridCoords);
            Debug.Log(player.gridCoords);
            Debug.Log(relativeGridCoords);
            if ((player.gridCoords.x % 2 == 0 && (relativeGridCoords == new Vector3Int(0, -1, 0) || relativeGridCoords == new Vector3Int(-1, 1, 0) || relativeGridCoords == new Vector3Int(-1, 0, 0) 
                    || relativeGridCoords == new Vector3Int(1, 0, 0) || relativeGridCoords == new Vector3Int(0, 1, 0) || relativeGridCoords == new Vector3Int(-1, -1, 0)))
                || (player.gridCoords.x % 2 == 1 && (relativeGridCoords == new Vector3Int(-1, -1, 0) || relativeGridCoords == new Vector3Int(0, -1, 0) || relativeGridCoords == new Vector3Int(-1, 0, 0) 
                    || relativeGridCoords == new Vector3Int(1, 0, 0) || relativeGridCoords == new Vector3Int(-1, 1, 0) || relativeGridCoords == new Vector3Int(0, 1, 0))))
                leftClickAction = ClickAction.MoveTo;
            else
                leftClickAction = ClickAction.None;
        }
        


    }


    private void OnGUI()
    {
        moveActionIndicator.SetActive(leftClickAction == ClickAction.MoveTo);
    }



}

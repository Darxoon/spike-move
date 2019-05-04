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

    [SerializeField] private Vector2[] evenTileNeighbors;
    [SerializeField] private Vector2[] oddTileNeighbors;

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
    private Dictionary<Tile, TileDescription> tiles = new Dictionary<Tile, TileDescription>();

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

    public Dictionary<Tile, TileDescription> Tiles => tiles;
    public TileDescription MissingTile => missingTile;

    private void Awake()
    {
        /* convert tilesEditor Array to tiles Dict */
        foreach (EditorTile item in tilesEditor)
        {
            tiles.Add(item.tile, new TileDescription { name = item.name, description = item.description, tileEvent = item.tileEvent, collisionType = item.collisionType });
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
                tooltipTile = tiles[newTile];
            }
            catch (System.Exception)
            {
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
            if ((relativeGridCoords.x < 1 && relativeGridCoords.x >= -1 && relativeGridCoords.y <= 1 && relativeGridCoords.y >= -1 && relativeGridCoords != new Vector3Int(0, 0, 0)) 
                || (relativeGridCoords.x == 1 && relativeGridCoords.y == 0)) 
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

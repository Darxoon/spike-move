using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TooltipContent : MonoBehaviour
{
    // classes
    [System.Serializable]
    struct TooltipTile
    {
        public string name;
        public string description;
    }
    [System.Serializable] 
    struct EditorTile
    {
        public Tile tile;
        public string name;
        public string description;
    }

    // other objects
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private FollowMouse selection;

    // texts 
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text descriptionLabel;

    // tile dictionary
    [SerializeField] private EditorTile[] tilesEditor;
    [SerializeField] private TooltipTile missingTile;
    private Dictionary<Tile, TooltipTile> tiles = new Dictionary<Tile, TooltipTile>();

    // tile
    private Tile currentTile;
    private Tile newTile;

    // other 
    private TooltipTile tooltipTile;

    private void Awake()
    {
        foreach (EditorTile item in tilesEditor)
        {
            tiles.Add(item.tile, new TooltipTile { name = item.name, description = item.description });
        }
    }

    private void Update()
    {
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
    }
}

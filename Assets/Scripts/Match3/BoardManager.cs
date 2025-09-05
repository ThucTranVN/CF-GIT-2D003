using UnityEngine;

public class BoardManager : BaseManager<BoardManager>
{
    public int Width;
    public int Height;
    public GameObject TilePrefab; //For background
    public int BorderSize;
    public Tile[,] AllTiles;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AllTiles = new Tile[Width, Height];
        SetupTiles();
        SetupCamera();
    }

    void SetupTiles()
    {
        for (int i = 0; i < Width; i++) //Row
        {
            for (int j = 0; j < Height; j++) //Column
            {
                GameObject tileGo = Instantiate(TilePrefab,
                    new Vector3(i, j, 0), Quaternion.identity);
                tileGo.name = $"Tile ({i},{j})";

                Tile tile = tileGo.GetComponent<Tile>();
                tile.Init(i, j);

                AllTiles[i, j] = tile;

                tileGo.transform.parent = this.transform;
            }
        }
    }

    void SetupCamera()
    {
        Camera.main.transform.position = new Vector3((float)(Width - 1) / 2f, (float)(Height - 1) / 2f, -10f);
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float verticleSize = (float)Height / 2f + (float)BorderSize;
        float horizontalSize = ((float)Width / 2f + (float)BorderSize) / aspectRatio;
        Camera.main.orthographicSize = (verticleSize > horizontalSize) ? verticleSize : horizontalSize;
    }
}

using UnityEngine;

public class BoardManager : BaseManager<BoardManager>
{
    public int Width;
    public int Height;
    public GameObject TilePrefab; //For background
    public int BorderSize;
    public Tile[,] AllTiles;
    public GamePiece[,] AllGamePieces;
    public GameObject[] GamePiecePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AllTiles = new Tile[Width, Height];
        AllGamePieces = new GamePiece[Width, Height];
        SetupTiles();
        SetupCamera();
        FillRandom();
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

    private GameObject GetRandomGamePiece()
    {
        int randomIdx = Random.Range(0, GamePiecePrefab.Length);

        if(GamePiecePrefab[randomIdx] == null)
        {
            Debug.LogWarning($"GamePiecePrefab at index = {randomIdx} is null");
        }

        return GamePiecePrefab[randomIdx];
    }

    private void PlaceGamePiece(GamePiece gamePiece, int x, int y)
    {
        if(gamePiece == null)
        {
            Debug.LogWarning("Invalid gamePiece component");
            return;
        }

        gamePiece.transform.position = new Vector3(x, y, 0);
        gamePiece.transform.rotation = Quaternion.identity;
        gamePiece.SetCoord(x, y);
    }

    private void FillRandom()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                GameObject randomPiece = Instantiate(GetRandomGamePiece(),
                    Vector3.zero, Quaternion.identity);

                if(randomPiece != null)
                {
                    PlaceGamePiece(randomPiece.GetComponent<GamePiece>(), i, j);
                }
            }
        }
    }
}

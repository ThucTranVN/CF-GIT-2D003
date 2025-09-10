using UnityEngine;

public class Tile : MonoBehaviour
{
    public int xIndex;
    public int yIndex;

    public void Init(int x, int y)
    {
        xIndex = x;
        yIndex = y;
    }

    private void OnMouseUp()
    {
        if (BoardManager.HasInstance)
        {
            BoardManager.Instance.ReleaseTile();
        }
    }

    private void OnMouseEnter()
    {
        if (BoardManager.HasInstance)
        {
            BoardManager.Instance.DragToTile(this);
        }
    }

    private void OnMouseDown()
    {
        if (BoardManager.HasInstance)
        {
            BoardManager.Instance.ClickTile(this);
        }
    }
}

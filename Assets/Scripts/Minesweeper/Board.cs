using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }

    public Tile tileUnknownF;
    public Tile tileEmptyF;
    public Tile tileMineF;
    public Tile tileExplodedF;
    public Tile tileFlagF;
    public Tile tileNum1F;
    public Tile tileNum2F;
    public Tile tileNum3F;
    public Tile tileNum4F;
    public Tile tileNum5F;
    public Tile tileNum6F;
    public Tile tileNum7F;
    public Tile tileNum8F;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void Draw(CellGrid grid)
    {
        int width = grid.Width;
        int height = grid.Height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = grid[x, y];
                tilemap.SetTile(cell.position, GetTile(cell));
            }
        }
    }

    private Tile GetTile(Cell cell)
    {
        if (cell.revealed) {
            return GetRevealedTile(cell);
        } else if (cell.flagged) {
            return tileFlagF;
        } else if (cell.chorded) {
            return tileEmptyF;
        } else {
            return tileUnknownF;
        }
    }

    private Tile GetRevealedTile(Cell cell)
    {
        switch (cell.type)
        {
            case Cell.Type.Empty: return tileEmptyF;
            case Cell.Type.Mine: return cell.exploded ? tileExplodedF : tileMineF;
            case Cell.Type.Number: return GetNumberTile(cell);
            default: return null;
        }
    }

    private Tile GetNumberTile(Cell cell)
    {
        switch (cell.number)
        {
            case 1: return tileNum1F;
            case 2: return tileNum2F;
            case 3: return tileNum3F;
            case 4: return tileNum4F;
            case 5: return tileNum5F;
            case 6: return tileNum6F;
            case 7: return tileNum7F;
            case 8: return tileNum8F;
            default: return null;
        }
    }

}

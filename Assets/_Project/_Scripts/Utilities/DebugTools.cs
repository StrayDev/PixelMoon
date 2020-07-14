using UnityEngine;

namespace PixelMoon.Utilities
{
    public class DebugTools : MonoBehaviour
    {
        private Grid grid;
        private Transform player;


        void Start()
        {
            player = GameObject.Find("Player").transform;
            grid = GameObject.Find("GridSystem").GetComponent<Grid>();
        }

        private void Update()
        {
            if (player)
            {
                DrawOccupiedSquares(player.position, .75f, grid);
            }
        }

        private void DrawOccupiedSquares(Vector3 position, float size, Grid grid)
        {
            float x = position.x;
            float z = position.z;
            float offset = grid.cellSize.x / 2;
            float offsetY = grid.transform.position.y - Mathf.RoundToInt(position.y) + 3f;

            Vector3 TL = grid.GetCellCenterWorld(grid.WorldToCell(new Vector3(x + -size, 0, z + size)));
            Vector3 TR = grid.GetCellCenterWorld(grid.WorldToCell(new Vector3(x + size, 0, z + size)));
            Vector3 BL = grid.GetCellCenterWorld(grid.WorldToCell(new Vector3(x + -size, 0, z + -size)));
            Vector3 BR = grid.GetCellCenterWorld(grid.WorldToCell(new Vector3(x + size, 0, z + -size)));

            Debug.DrawLine(TL + new Vector3(-offset, -offsetY, offset), TR + new Vector3(offset, -offsetY, offset));
            Debug.DrawLine(TR + new Vector3(offset, -offsetY, offset), BR + new Vector3(offset, -offsetY, -offset));
            Debug.DrawLine(BR + new Vector3(offset, -offsetY, -offset), BL + new Vector3(-offset, -offsetY, -offset));
            Debug.DrawLine(BL + new Vector3(-offset, -offsetY, -offset), TL + new Vector3(-offset, -offsetY, offset));

        
        }
    }
}

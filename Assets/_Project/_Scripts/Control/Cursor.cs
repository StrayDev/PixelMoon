using UnityEngine;
using UnityEngine.Tilemaps;

namespace PixelMoon.Control
{
    public class Cursor : MonoBehaviour
    {
        private LayerMask layerMask;
        private Renderer renderer;

        [SerializeField] private Tilemap tilemap;

        private bool cursorIsVisible;
        private Vector3Int mouseCellPosition;
        private Vector3Int playerCellPosition;
        private Transform playerTransform;

        // Start is called before the first frame update
        void Start()
        {
            playerTransform = transform.parent;
            layerMask = LayerMask.GetMask("Mouse");
            renderer = transform.gameObject.GetComponent<Renderer>();
            tilemap = GameObject.Find("/Systems/GridSystem/GroundMap").GetComponent<Tilemap>();
        }

        // Update is called once per frame
        void Update()
        {
            //ray to get mouse pos
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask);
            //convert pos to cell pos
            mouseCellPosition = tilemap.WorldToCell(raycastHit.point);
            playerCellPosition = tilemap.WorldToCell(playerTransform.position);
            //conert from cell to world pos
            Vector3 mouseCentered = tilemap.GetCellCenterWorld(mouseCellPosition);
            Vector3 playerCentred = tilemap.GetCellCenterWorld(playerCellPosition);

            if (!tilemap.HasTile(mouseCellPosition) || MouseOnPlayerTiles(mouseCentered))
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
            }

            //add offset and apply position                       
            mouseCentered += new Vector3(0f, 0.01f, 0f);
            transform.position = mouseCentered;
        }

        private bool MouseOnPlayerTiles(Vector3 mouseCentered)
        {
            float x = playerTransform.position.x;
            float z = playerTransform.position.z;
            float offset = .75f;
        
            Vector3 TL = tilemap.GetCellCenterWorld(tilemap.WorldToCell(new Vector3(x + -offset, 0, z + offset)));
            Vector3 TR = tilemap.GetCellCenterWorld(tilemap.WorldToCell(new Vector3(x + offset, 0, z + offset)));
            Vector3 BL = tilemap.GetCellCenterWorld(tilemap.WorldToCell(new Vector3(x + -offset, 0, z + -offset)));
            Vector3 BR = tilemap.GetCellCenterWorld(tilemap.WorldToCell(new Vector3(x + offset, 0, z + -offset)));

            //Debug.DrawLine(TL + new Vector3(-1, 0, 1), TR + new Vector3(1, 0, 1));
            //Debug.DrawLine(TR + new Vector3(1, 0, 1), BR + new Vector3(1, 0, -1));
            //Debug.DrawLine(BR + new Vector3(1, 0, -1), BL + new Vector3(-1, 0, -1));
            //Debug.DrawLine(BL + new Vector3(-1, 0, -1), TL + new Vector3(-1, 0, 1));

            //Vector3 centrePoint = (TL + TR + BL + BR) / 4;
            //Debug.DrawLine(playerTransform.position, centrePoint);

            if (mouseCentered == TL || mouseCentered == TR || mouseCentered == BL || mouseCentered == BR)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }
    }
}

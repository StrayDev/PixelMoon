using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class BattleGrid : MonoBehaviour
    {
        [SerializeField] public Vector3 pPos1;
        [SerializeField] public Vector3 pPos2;
        [SerializeField] public Vector3 pPos3;
        [SerializeField] public Vector3 ePos1;
        [SerializeField] public Vector3 ePos2;
        [SerializeField] public Vector3 ePos3;

        private List<Vector3> positions;
        private Vector3 origin;
        private int maxTeamSize = 3;
        private int side;

        private void Start()
        {
            positions = new List<Vector3>();
        }

        public void GeneratePositions(Vector3 originPosition, bool enemiesOnLeft)
        {
            if (enemiesOnLeft)
                side = 1;
            else
                side = -1;

            origin = originPosition;
            
            pPos1 = origin + new Vector3(4, 0, 0) * side;
            pPos2 = origin + new Vector3(5, 0, -3) * side;
            pPos3 = origin + new Vector3(3, 0, 3) * side;
                
            ePos1 = origin + new Vector3(-3, 0, 0) * side;
            ePos2 = origin + new Vector3(-5, 0, -3) * side;
            ePos3 = origin + new Vector3(-6, 0, 3) * side;
            
            positions.Add(pPos1);
            positions.Add(pPos2);
            positions.Add(pPos3);
            positions.Add(ePos1);
            positions.Add(ePos2);
            positions.Add(ePos3);
        }

        public Vector3 GetPositionFromIndex(int index, bool isPlayer)
        {
            var iMod = 0;
            if (!isPlayer) iMod = maxTeamSize;
            Debug.Log($"{index} : {iMod}");
            return positions[index + iMod];
        }
    }
}

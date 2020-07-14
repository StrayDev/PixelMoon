using System.Collections.Generic;
using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class Party : ScriptableObject
    {
        [SerializeField] private Entity playerEntity;
        [SerializeField] private List<Entity> members;
        public List<Entity> Members => members;
    
        public bool IsPartyMember(Entity entity)
        {
            if(Members.Contains(entity))
            {
                return true;
            }
            return false;
        }
    }
}

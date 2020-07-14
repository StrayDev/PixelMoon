using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Scriptables.Behaviours
{
    public abstract class EntityController : ScriptableObject
    {
        public abstract void Use(Entity entity);   
    }
}

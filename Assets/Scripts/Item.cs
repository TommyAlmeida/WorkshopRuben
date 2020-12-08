using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Item", fileName = "Item")]
    public class Item : ScriptableObject
    {
        public string Name;
    }
}
using UnityEngine;

namespace UIPanels
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Item Data/Plain")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;

        [TextArea(3, 10)]
        public string description;
        public Sprite graphic;

    }
}

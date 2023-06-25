using UnityEngine;

namespace UIPanels.Demo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Item Data/Markable")]
    public class MarkableItemSO : ItemSO
    {
        public enum ItemStatus
        {
            NORMAL,
            MARKED
        }

        public ItemStatus itemStatus = ItemStatus.NORMAL;
    }
}

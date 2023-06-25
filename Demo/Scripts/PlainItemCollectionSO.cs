using System.Collections.Generic;
using UnityEngine;

namespace UIPanels.Demo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Item Collections/Plain")]
    public class PlainItemCollectionSO : ScriptableObject
    {
        public List<ItemSO> items;
    }
}

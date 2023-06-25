using System.Collections.Generic;
using UnityEngine;

namespace UIPanels.Demo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Item Collections/Markable")]
    public class MarkableItemCollectionSO : ScriptableObject
    {
        // DESIGN CHOICE: Don't have a callback for when inventory updated,
        // since it's not something that's going to be changing very often,
        // and there are defined times when the inventory will need to be
        // updated/checked, meaning there won't be any polling anyways
        public List<MarkableItemSO> items;
    }
}

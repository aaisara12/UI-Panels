using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIPanels.Demo
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Item UI Generators/Markable")]
    public class MarkableItemUIGeneratorSO : ItemUIGeneratorSO
    {
        [Header("Inventory Properties")]
        [SerializeField] MarkableItemCollectionSO collection = default;
        [SerializeField] VisualTreeAsset markableItemUI = default;

        // DESIGN CHOICE: Make a separate field for each, instead of using some kind of
        // list containing data structures that pair an item status with a color since
        // it is unlikely that very many more item statuses will be introduced, thus making
        // it not really worth the cost of the added complexity
        [SerializeField] Color normalItemColor = Color.white;
        [SerializeField] Color markedItemColor = Color.blue;


        // UI Tags (Inventory Item)
        const string k_MarkableItemName = "item-name";
        const string k_MarkableItemGraphic = "item-graphic";


        public override List<ItemUIResult> GenerateUI()
        {
            List<ItemUIResult> results = new List<ItemUIResult>();
            foreach (MarkableItemSO inventoryItem in collection.items)
            {
                results.Add(new ItemUIResult { reference = inventoryItem, ui = GenerateListItemUI(inventoryItem) });
            }
            return results;
        }

        private TemplateContainer GenerateListItemUI(MarkableItemSO itemData)
        {
            TemplateContainer instance = markableItemUI.Instantiate();
            InitializeItemElement(instance, itemData);
            return instance;
        }


        private void InitializeItemElement(VisualElement item, MarkableItemSO itemData)
        {
            item.Q<Label>(k_MarkableItemName).text = itemData.itemName;
            item.Q<Label>(k_MarkableItemName).style.color = GetItemStatusColor(itemData);
            item.Q<VisualElement>(k_MarkableItemGraphic).style.backgroundImage = new StyleBackground(itemData.graphic);
        }

        ///<summary>
        /// Get the color corresponding to the status of this item
        ///</summary>
        private Color GetItemStatusColor(MarkableItemSO item)
        {
            // DESIGN CHOICE: Use a method to ensure consistent assignment of colors
            // DESIGN CHOICE: Use switch statement instead of dictionary for simplicity; probably won't have any additional item statuses anyways
            switch (item.itemStatus)
            {
                case MarkableItemSO.ItemStatus.NORMAL:
                    return normalItemColor;
                case MarkableItemSO.ItemStatus.MARKED:
                    return markedItemColor;
                default:
                    return normalItemColor;
            }
        }

    }

}
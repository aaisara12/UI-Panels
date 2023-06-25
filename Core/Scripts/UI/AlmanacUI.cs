using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace UIPanels
{
    public class AlmanacUI : MonoBehaviour
    {
        [SerializeField] UIDocument document = default;
        [SerializeField] float scrollSpeed = 300;
        [SerializeField] float scrollButtonJumpSize = 100;

        // NOTE: This is a component-based alternative to custom styling of collection items
        [SerializeField] ItemUIGeneratorSO almanacItemUIGenerator = default;



        // UI Tags
        const string k_ItemList = "item-list";
        const string k_ItemTitle = "item-title";
        const string k_ItemVisual = "item-visual";
        const string k_ItemDesc = "item-desc";
        const string k_ScrollUpButton = "scroll-up-button";
        const string k_ScrollDownButton = "scroll-down-button";


        // UI References
        ScrollView m_ItemList = default;
        Label m_ItemTitle = default;
        VisualElement m_ItemVisual = default;
        Label m_ItemDesc = default;

        Button m_InventoryScrollUpButton = default;
        Button m_InventoryScrollDownButton = default;


        // Other References
        ItemSelector<ClickEvent> clickableItemList = default;
        Dictionary<VisualElement, ItemSO> visualToData = new Dictionary<VisualElement, ItemSO>();

        VisualElement root
        {
            get
            {
                if (document != null)
                    return document.rootVisualElement;
                return null;
            }
        }

        public void UpdateDisplay()
        {
            UpdateDisplayWithGenerator(almanacItemUIGenerator);
        }

        void Awake()
        {
            m_ItemList = root.Q<ScrollView>(k_ItemList);

            m_ItemTitle = root.Q<Label>(k_ItemTitle);
            m_ItemVisual = root.Q<VisualElement>(k_ItemVisual);
            m_ItemDesc = root.Q<Label>(k_ItemDesc);

            m_InventoryScrollUpButton = root.Q<Button>(k_ScrollUpButton);
            m_InventoryScrollDownButton = root.Q<Button>(k_ScrollDownButton);

            // Register Callbacks
            m_InventoryScrollUpButton.RegisterCallback<ClickEvent>(ev => SelectPrev());
            m_InventoryScrollDownButton.RegisterCallback<ClickEvent>(ev => SelectNext());

            m_ItemList.RegisterCallback<WheelEvent>(SpeedUpScroll);
            m_ItemList.verticalPageSize = scrollButtonJumpSize;

            // Allows us to select items in list by clicking
            clickableItemList = new ItemSelector<ClickEvent>(m_ItemList);

            clickableItemList.OnItemSelected += FocusOnItem;

            UpdateDisplayWithGenerator(almanacItemUIGenerator);
        }

        // This is a function to accelerate the scroll speed, and is a work-around for Unity's currently slightly
        // buggy scrolling system. Here's the post that inspired it: https://forum.unity.com/threads/listview-mousewheel-scrolling-speed.1167404/ -- Specifically in leanon00's reply
        private void SpeedUpScroll(WheelEvent ev)
        {
            m_ItemList.scrollOffset = new Vector2(0, m_ItemList.scrollOffset.y + scrollSpeed * ev.delta.y);
        }


        private void UpdateDisplayWithGenerator(ItemUIGeneratorSO generator)
        {
            // DESIGN CHOICE: Update display by clearing every single item then reinstantiating
            // new list instead of pooling items. Why? Well it's simple, and we probably
            // won't be calling this function A LOT, making it not too bad of a cost.

            clickableItemList.Clear();
            m_ItemList.scrollOffset = Vector2.zero;

            // Generate the item UIs
            List<ItemUIGeneratorSO.ItemUIResult> results = generator.GenerateUI();

            foreach (var result in results)
            {
                TemplateContainer instance = result.ui;

                // Cache item data
                visualToData[instance] = result.reference;

                clickableItemList.AddItem(instance);

            }

            clickableItemList.VisuallySelectFirst();
        }

        private void SelectNext()
        {
            clickableItemList.VisuallySelectNext();
            FocusOnItem(clickableItemList.GetSelectedElement());
        }

        private void SelectPrev()
        {
            clickableItemList.VisuallySelectPrev();
            FocusOnItem(clickableItemList.GetSelectedElement());
        }

        private void FocusOnItem(VisualElement item)
        {
            if (item == null) return;
            m_ItemList.ScrollTo(item);
            DisplayItemInformation(visualToData[item]);
        }



        ///<summary>
        /// Displays the given item in the inventory's main panel.
        ///</summary>
        private void DisplayItemInformation(ItemSO item)
        {
            // DESIGN CHOICE: The reason we don't abstract this out is because the visual components of the main display
            // is pretty much the same across all derivations (title, description, image)
            m_ItemTitle.text = item.itemName;
            m_ItemDesc.text = item.description;
            m_ItemVisual.style.backgroundImage = new StyleBackground(item.graphic);
        }

    }

}
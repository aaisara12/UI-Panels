# UI Panels

## Overview

This is a package containing useful scripts for building UI panels using Unity's `UIElements` package. Below is a breakdown of each of the scripts:

- `AlmanacUI.cs`: A general-purpose script that sets up all necessary callbacks for a `UIDocument` with a tree structured in the "alamanac" format (see `InventoryPanel.uxml` and `JournalPanel.uxml`).
- `AlphaButton.cs`: A custom control that is a button which registers raycasts based on the alpha value of the button's graphic. This is useful for non-rectangular buttons.
- `ItemSelector.cs`: A component that adds the ability to visually navigate (or select) through the children of a provided `VisualElement`.
- `PanelAnimator.cs`: A component that provides high-level animation functionality for any `UIDocument`.

This project was tested for Unity 2021.3.16f1.

## Demo

1. Open the `Demo` scene located in the Demo folder in this directory.
2. Press the play button.
3. Hit the '1' key to open up the inventory panel.
4. Click on the different item boxes in the left-most sub panel and observe how each gets selected and displays its information in the other sub panels.
5. Click on the arrow buttons to navigate through the items.
6. Hit the '1' key to close the inventory panel.
7. Hit the '2' key to open up the journal panel.
8. Explore the panel just like in the inventory panel. Notice how this panel is simply a reskinned version of the previous (it's a different view that has the same underlying "almanac" format).

## Notes

- The "almanac" format refers to a custom UXML structure designed to contain the core controls of an alamanac-style UI like you might see in an RPG beastiary. This includes things like a central graphic, item list, and selected item title.
- The demo is intended to showcase the majority of the package functionality, but to understand how to use the scripts, look at the source code in the scripts used to implement the demo.

## TODO

- ~~Create a repo for this package~~
- ~~Instantiate all demo items and generators~~
- ~~Create a demo script for opening and closing panels with number keys~~
- ~~Place all demo scripts within the namespace `UIPanels.Demo` and others with `UIPanels`~~
- ~~Clear out all unused files~~
- ~~Write this doc~~
- ~~Add version this demo has been tested for~~
- Export the top-level folder to a package and save it with the repo

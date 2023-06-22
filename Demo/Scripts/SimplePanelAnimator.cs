using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePanelAnimator : PanelAnimator
{
    // DESIGN CHOICE: This is just a demo script, so pretty worth to
    // take simplified approach using inheritance. 
    public void SlideInFromLeft() => AnimateOpen(PanelPosition.LEFT, PanelAnimationSpeed.NORMAL);
    public void SlideOutToLeft() => AnimateClose(PanelPosition.LEFT, PanelAnimationSpeed.NORMAL);
    public void SlideInFromBelow() => AnimateOpen(PanelPosition.BOTTOM, PanelAnimationSpeed.NORMAL);
    public void SlideOutToBelow() => AnimateClose(PanelPosition.BOTTOM, PanelAnimationSpeed.NORMAL);
}

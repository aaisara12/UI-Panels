using UnityEngine;
using UnityEngine.Events;

namespace UIPanels.Demo
{
    public class Toggler : MonoBehaviour
    {
        bool isToggled = false;
        [SerializeField] KeyCode toggleKey = KeyCode.Alpha1;
        [SerializeField] UnityEvent OnToggleOn = new UnityEvent();
        [SerializeField] UnityEvent OnToggleOff = new UnityEvent();

        void Update()
        {
            // DESIGN CHOICE: Use old input system so user doesn't have
            // to add in any additional packages or deal with input assets
            // for such a simple demo script
            if (Input.GetKeyDown(toggleKey))
            {
                isToggled = !isToggled;
                if (isToggled)
                    OnToggleOn?.Invoke();
                else
                    OnToggleOff?.Invoke();
            }
        }
    }
}

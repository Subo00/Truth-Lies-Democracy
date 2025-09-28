using UnityEngine;
using UnityEngine.EventSystems;

public class SubMenu : MonoBehaviour
{
    [SerializeField] GameObject subMenuCanvas;
    [SerializeField] GameObject firstSelectedButton;
    [SerializeField] GameObject selectAfterClose;


    public static SubMenu currentOpenMenu = null;
    private SubMenu myPreviousSubMenu;

    private EventSystem eventSystem;
    private GameObject selectedBeforeOpened;

    public void Awake()
    {
        eventSystem = EventSystem.current;
    }

    public void OpenSubMenu()
    {
        subMenuCanvas.SetActive(true);
        myPreviousSubMenu = currentOpenMenu;
        currentOpenMenu = this;
        if (selectAfterClose == null)
        {
            selectedBeforeOpened = eventSystem.currentSelectedGameObject;
        }
        eventSystem.SetSelectedGameObject(firstSelectedButton);
    }

    public void SelectFirstSelected()
    {
        eventSystem.SetSelectedGameObject(firstSelectedButton);
    }

    public void CloseSubMenu()
    {
        currentOpenMenu = myPreviousSubMenu;
        subMenuCanvas.SetActive(false);
        if (selectAfterClose == null)
        {
            eventSystem.SetSelectedGameObject(selectedBeforeOpened);
        }
        else
        {
            eventSystem.SetSelectedGameObject(selectAfterClose);
        }
    }

    public void ToggleMenu()
    {
        if (currentOpenMenu == this)
        {
            CloseSubMenu();
        }
        else if (currentOpenMenu == null)
        {
            OpenSubMenu();
        }

    }

}

using UnityEngine;
using UnityEngine.EventSystems;

public class SubMenu : MonoBehaviour
{
    [SerializeField] GameObject subMenuCanvas;


    public static SubMenu currentOpenMenu = null;
    private SubMenu myPreviousSubMenu;



    public void OpenSubMenu()
    {
        subMenuCanvas.SetActive(true);
        myPreviousSubMenu = currentOpenMenu;
        currentOpenMenu = this;
       
    }


    public void CloseSubMenu()
    {
        currentOpenMenu = myPreviousSubMenu;
        subMenuCanvas.SetActive(false);
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

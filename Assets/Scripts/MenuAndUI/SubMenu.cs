using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SubMenu : MonoBehaviour
{
    [SerializeField] GameObject subMenuCanvas;
    [SerializeField] GameObject firstSelectedButton;
    [SerializeField] GameObject selectAfterClose;

    [SerializeField] private bool is_pause_menu = false;

    public static SubMenu currentOpenMenu = null;
    private SubMenu myPreviousSubMenu;
    private PlayerInput playerInput;
    private PauseController pauseController;

    private EventSystem eventSystem;
    private GameObject selectedBeforeOpened;

    public void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        eventSystem = EventSystem.current;
        if (is_pause_menu)
        {
            pauseController = GetComponent<PauseController>(); 

        }
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
        if (pauseController != null)
        {
            pauseController.startPause.Invoke();
        }
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
        if (pauseController != null)
        {
            pauseController.stopPause.Invoke();
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

    private void Update()
    {

        if (playerInput.actions["Back"].triggered
            || (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape)))
        {

            if (currentOpenMenu == this)
            {
                CloseSubMenu();
            }
        }
    }

}

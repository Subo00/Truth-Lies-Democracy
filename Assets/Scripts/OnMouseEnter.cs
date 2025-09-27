using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Mover mover;
    [SerializeField] private bool isLeft;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (isLeft) { mover.MoveLeft(); }
        else { mover.MoveRight(); }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        mover.MoveClear();
    }
}

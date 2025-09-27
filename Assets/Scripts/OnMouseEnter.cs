using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Mover mover;
    [SerializeField] private Direction direction;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mover.Move(direction);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        mover.MoveClear(direction);
    }

    private void OnDisable()
    {
        mover.MoveClear(direction);
    }
}

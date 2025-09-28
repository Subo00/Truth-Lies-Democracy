using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class UISelectableSounds : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    private Selectable selectable;
    [SerializeField] private AudioSource UIhoverSound;
    [SerializeField] private AudioSource UIconfirmSound;
    [SerializeField] private bool disappears_on_click = false;

    private void Awake()
    {
        selectable = GetComponent<Selectable>();
        if (selectable != null && selectable.GetType()==typeof(Button))
        {
            if (UIconfirmSound != null)
            {
                Button button = (Button)selectable;
                button.onClick.AddListener(delegate { ClickSound(); });
            }
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (selectable != null)
        {
            if (selectable.interactable)
            {

                if (UIhoverSound != null)
                {
                    UIhoverSound.Play();
                }

            }
            else
            {
                //Debug.Log("Play brrr inactive button sound here!");
            }
        }
        else
        {
            if (UIhoverSound != null)
            {
                UIhoverSound.Play();
            }
        }
    }

    //Called when button is pressed
    public void ClickSound()
    {
        if (selectable != null)
        {
            if (selectable.interactable)
            {
                if (UIconfirmSound != null)
                {
                    if (disappears_on_click)
                    { AudioSource.PlayClipAtPoint(UIconfirmSound.clip, new Vector3(0, 0, 0),UIconfirmSound.volume); }
                    else
                    { UIconfirmSound.Play(); }
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selectable != null)
        {
            if (selectable.interactable)
            {
                if (UIhoverSound != null)
                {
                    UIhoverSound.Play();
                }

            }
            else
            {
                //Debug.Log("Play brrr inactive button sound here!");
            }
        }
        else
        {
            if (UIhoverSound != null)
            {
                UIhoverSound.Play();
            }
        }
    }
}

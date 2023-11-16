using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEnterBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("����ui"+transform);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("�뿪ui" + transform);
    }
}

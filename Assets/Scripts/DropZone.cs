using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void OnDropHandler(PointerEventData eventData);
public delegate void OnEnterHandler(PointerEventData eventData);
public delegate void OnExitHandler(PointerEventData eventData);
public class DropZone : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public bool EnableDrop=true;

    public OnDropHandler onDrop;
    public OnEnterHandler onEnter;
    public OnExitHandler onExit;

    public void RegisterOnDropHandler(OnDropHandler onDrop, OnEnterHandler onEnter, OnExitHandler onExit)
    {
        this.onDrop = onDrop;
        this.onEnter = onEnter;
        this.onExit = onExit;
    }

	public void OnDrop (PointerEventData eventData)
	{
	    if (!EnableDrop) return;
		Draggable draggable=eventData.pointerDrag.GetComponent<Draggable>();
		if (!draggable.enableDrag)
			return;
		if (draggable != null)
		{
		    if (onDrop != null) onDrop(eventData);
		}
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EnableDrop && eventData != null && eventData.pointerDrag != null && onEnter != null)
            onEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (EnableDrop && eventData != null && eventData.pointerDrag != null && onExit != null)
            onExit(eventData);
    }
}

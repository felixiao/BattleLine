using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnPointerClick(PointerEventData eventData);
public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler {
	public Transform parent=null;
    public Transform canvas;
	public bool enableDrag=true;
	public int indexOfDeck;

    public OnPointerClick onPointClick;

    public void RegisterOnPointerClickHandler(OnPointerClick onClick)
    {
        onPointClick = onClick;
    }
	public void OnBeginDrag (PointerEventData eventData){
		if (!enableDrag)
			return;
		parent = this.transform.parent;
		indexOfDeck = this.transform.GetSiblingIndex();
        this.transform.SetParent(canvas.transform);
		this.GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData){
		if (!enableDrag)
			return;
		this.transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData){
		if (!enableDrag)
			return;
		
		this.transform.SetParent (parent);
		this.transform.SetSiblingIndex (indexOfDeck);
		this.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
	public void OnPointerClick (PointerEventData eventData){
	    onPointClick(eventData);
	}
}

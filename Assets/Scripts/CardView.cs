using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void ToggleSelect(CardView card);

public delegate void SetOrder(int order);
public class CardView : MonoBehaviour
{   
    public Card card;
    public int id;
    private Image image;
    private Draggable drag;
    private LayoutElement layoutElem;
    public ToggleSelect onToggle;
    void Start()
    {
        image = this.GetComponent<Image>();
        layoutElem = this.GetComponent<LayoutElement>();
    }

    public void Init(int id)
    {
        image = this.GetComponent<Image>();
        drag = this.GetComponent<Draggable>();
        card = GameData.Instance.BaseDeck.GetCardByID(id);
        this.id = id;
        name = card.ToString();
        card.RegisterAddToDeckViewHandler(OnAdd);
        card.RegisterSetOrderHandler(SetOrder);
        SetSprite();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onToggle != null) onToggle(this);
    }
    public void RegisterOnToggleHandler(ToggleSelect toggle)
    {
        onToggle = toggle;
    }
    public void OnSelect()
    {
        if(layoutElem==null) return;
        this.layoutElem.preferredWidth = 100;
        this.layoutElem.preferredHeight = 140;
    }
    public void OnDeselect()
    {
        this.layoutElem.preferredWidth = 80;
        this.layoutElem.preferredHeight = 112;
    }

    public void SetSprite()
    {
        image.sprite = SpriteCollection.GetSprite(name);
    }
    public void SetEnable()
    {
        image.color = Color.white;
    }
    public void SetDisable()
    {
        image.color = Color.gray;
    }

    public void SetOrder(int order)
    {
        this.transform.SetSiblingIndex(order);
    }
    
	public void OnAdd(DeckView view)
    {
        Debug.Log(string.Format("<color=yellow>[{0}.OnAdd] Set Parent {1}</color>",card, view.name));
        drag.parent = view.transform;
        SetParent(view);
    }

    public void SetParent(DeckView view)
    {
        this.transform.SetParent(view.transform);
        OnSelect();
        this.drag.enableDrag = view.EnableDrag;
        this.RegisterOnToggleHandler(view.ToggleSelect);
    }
}
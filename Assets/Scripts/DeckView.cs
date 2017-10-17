using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void AddToDeck(Card card);
public class DeckView : MonoBehaviour
{
    public GameObject CardViewPrefab;
    private AddToDeck onAdd;
    private Image image;
    public CardView SelectedCard;
    public bool EnableDrag=true;

    void Start()
    {
        image = GetComponent<Image>();
    }
    public void RegisterOnAddToDeckHandler(AddToDeck onAddHandler)
    {
        onAdd = onAddHandler;
    }

    public void CreateFromPrefab(int id,Transform trans)
    {
        GameObject card = GameObject.Instantiate(CardViewPrefab);
        CardView cardView = card.GetComponent<CardView>();
        Draggable drag = card.GetComponent<Draggable>();
        drag.canvas = trans;
        drag.RegisterOnPointerClickHandler(cardView.OnPointerClick);
        cardView.Init(id);
        card.transform.SetParent(this.transform);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card=eventData.pointerDrag.GetComponent<CardView>().card;
        AddCard(card);
        OnExit(eventData);
    }
    public void OnEnter(PointerEventData eventData)
    {
        image.color = Color.grey;
    }
    public void OnExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void ToggleSelect(CardView c)
    {
        if (SelectedCard != null) SelectedCard.OnDeselect();
        if (SelectedCard != null && SelectedCard.id != c.id) c.OnSelect();
        if (SelectedCard == null) c.OnSelect();
        SelectedCard = c;
    }
    /// <summary>
    /// 添加卡牌，通过界面操作添加卡牌
    /// </summary>
    /// <param name="card">待添加的卡牌数据</param>
    public void AddCard(Card card)
    {
        Debug.Log(string.Format("<color=blue>[{0}.OnAdd] {1}</color>",name, card));
        if (onAdd != null) onAdd(card);
    }

    public DeckView GetDeckView()
    {
        return this;
    }
}
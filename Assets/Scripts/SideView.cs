using UnityEngine;

public class SideView : MonoBehaviour
{
    public GameObject linePrefab;
    public void Init(bool IsSelf = true)
    {
        for(int i=1;i<=9;i++)
        {
            GameObject line = GameObject.Instantiate(linePrefab);
            DeckView deckview = line.GetComponent<DeckView>();
            deckview.EnableDrag = false;
            deckview.RegisterOnAddToDeckHandler(GameData.Instance.GetSide(i, IsSelf).AddCard);
            GameData.Instance.GetSide(i, IsSelf).RegisterGetTransform(deckview.GetDeckView);
            DropZone drop = line.GetComponent<DropZone>();
            drop.EnableDrop = IsSelf;
            drop.RegisterOnDropHandler(deckview.OnDrop, deckview.OnEnter, deckview.OnExit);
            line.transform.SetParent(this.transform);
            line.name = this.name +"_"+ i;
        }
    }
}
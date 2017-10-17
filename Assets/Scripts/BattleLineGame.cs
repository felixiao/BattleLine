using UnityEngine;
using System.Collections;

public class BattleLineGame : MonoBehaviour
{
    public GameObject deckPrefab;

    public DeckView deck;
    public SideView selfSide, oppoSide;
    public DeckView hand,oppoHand;
    void Awake()
    {
        SpriteCollection.Init("BattleLine");
    }
    void Start()
    {
        Logic.Instance.Init();
        for(int i=1;i<=60;i++) deck.CreateFromPrefab(i,this.transform);
        GameData.Instance.BaseDeck.RegisterGetTransform(deck.GetDeckView);
        deck.RegisterOnAddToDeckHandler(GameData.Instance.BaseDeck.AddCard);
        selfSide.Init();
        oppoSide.Init(false);
        hand.RegisterOnAddToDeckHandler(GameData.Instance.SelfHand.AddCard);
        GameData.Instance.SelfHand.RegisterGetTransform(hand.GetDeckView);

        oppoHand.RegisterOnAddToDeckHandler(GameData.Instance.OppoHand.AddCard);
        GameData.Instance.OppoHand.RegisterGetTransform(oppoHand.GetDeckView);
        Logic.Instance.StartGame();

    }
}

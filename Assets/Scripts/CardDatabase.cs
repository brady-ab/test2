using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {

        cardList.Add(new Card(0, "None", 0, 0, 0, "", null));
        cardList.Add(new Card(1, "Witch", 0, 0, 1, "", null));
        cardList.Add(new Card(2, "Dimwitted Thug", 1, 2, 2, "", null));
        cardList.Add(new Card(3, "Crooked Buccaneer", 3, 4, 3, "", null));
        cardList.Add(new Card(4, "Mercenary Lieutenant", 4, 5, 5, "", null));
        cardList.Add(new Card(5, "Mutt", 0, 2, 2, "", null));
        cardList.Add(new Card(6, "Smuggler", 1, 1, 2, "", null));
        cardList.Add(new Card(7, "War Prisoner", 2, 2, 3, "", null));
        cardList.Add(new Card(8, "Recluse", 2, 2, 2, "", null));
        cardList.Add(new Card(9, "Hulking Madman", 3, 3, 6, "", null));
        cardList.Add(new Card(10, "Raccoon Bear", 4, 6, 5, "", null));
        cardList.Add(new Card(11, "Deep Cover Agent", 4, 3, 3, "", null));
        cardList.Add(new Card(12, "Ladderman", 5, 5, 7, "", null));
        cardList.Add(new Card(13, "Underground Prize Fighter", 5, 4, 5, "", null));
        cardList.Add(new Card(14, "Politician", 1, 0, 2, "", null));
        cardList.Add(new Card(15, "Assassin", 5, 1, 4, "", null));
        cardList.Add(new Card(16, "Scavenger", 2, 1, 3, "", null));
        cardList.Add(new Card(17, "Remorseless Devaint", 2, 4, 3, "", null));


        cardList.Add(new Card(51, "Cursed One", 2, 2, 2, "", null));
        cardList.Add(new Card(52, "Living Totem", 5, 2, 5, "", null));
        cardList.Add(new Card(53, "Rune-Etched Giant", 6, 7, 7, "", null));

    }
}

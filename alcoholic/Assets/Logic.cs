using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayingCard
{
	public string name, format;
	public int power;
    public Sprite image;

	public PlayingCard (string cardname, string cardformat, int cpower, Sprite image) 
	{
		this.name = cardname;
		this.format = cardformat;
		this.power = cpower;
        this.image = image;
    }
}

public class Logic : MonoBehaviour {
    
    int power = 6;
    
    string[] cards = new string[] {"6","7","8","9","10","junior","queen","king","ace"};
    string[] formats = new string[] {"heart", "diamond", "cross", "spade"};
    PlayingCard[] wholeDeck = new PlayingCard[36];

    public bool AutoFight = false;
    public bool Unlimited = false;
    public bool Dispute = false;
    public GameObject engGamePanel;

    public Text player1TableCardName, player2TableCardName, player1CardCount, player2CardCount, WinnerText;
    public Image player1TableCardImage, player2TableCardImage;
    public List<Image> Dispute1 = new List<Image>();
    public List<Image> Dispute2 = new List<Image>();

    //float nextTime;
    //float Timer = 0.01f;

    public List<PlayingCard> p1d = new List<PlayingCard>();
    public List<PlayingCard> p2d = new List<PlayingCard>();
    public List<PlayingCard> p1t = new List<PlayingCard>();
    public List<PlayingCard> p2t = new List<PlayingCard>();

    public void Start()
    {
        // Проверка аттачей в редакторе
        CheckAllShit();

        // формирование колоды, перетасовка, раздача
        FillDeck();
        RandomizeDeck();
        SplitDeck();
        //nextTime = Time.timeSinceLevelLoad + Timer;
        RemoveDisputeDisplay();
        ShowCard();
    }
    void DebugDeck(List<PlayingCard> deck)
    {
        Debug.Log("-------------------------------");
        Debug.Log("Deck size is: " + deck.Count);
        Debug.Log("-------------------------------");
        foreach (PlayingCard pc in deck)
        {
            Debug.Log(pc.name + " " + pc.format);
        }
        Debug.Log("-------------------------------");
    }
    public void Dbgdeck1()
    {
        DebugDeck(p1d);
    }
    public void Dbgdeck2()
    {
        DebugDeck(p2d);
    }
    public void Dbgtbl1()
    {
        DebugDeck(p1t);
    }
    public void Dbgtbl2()
    {
        DebugDeck(p2t);
    }
    public void AddCardToDeck( List<PlayingCard> deck, PlayingCard card)
    {
        deck.Add(card);
    }
    public void PutCardsToTable(bool ignoreTable)
    {
        if (ignoreTable == false)
        {
            // check if table has cards
            if ((p1t.Count > 0) || (p2t.Count > 0))
            {
                if (!Unlimited)
                {
                    Debug.Log("You shall not pass");
                    return;
                }
            }

            // check empty hands
            if ((p1d.Count == 0) || (p2d.Count == 0))
            {
                Debug.LogWarning("No cards Left");
                CheckWinner();
                return;
            }
        }        


        // put cards from hands to table
        p1t.Add(p1d[0]);
        p1d.Remove(p1d[0]);
        p2t.Add(p2d[0]);
        p2d.Remove(p2d[0]);

        // update visual
        ShowCard();
    }
    public void GrabCardsFromTableTo(List<PlayingCard> deck)
    {
        List<PlayingCard> newdeck = DeckCombiner(p1t, p2t);
        foreach (PlayingCard pc in newdeck)
            deck.Add(pc);

        CleanTable();
    }
    void CleanTable()
    {
        p1t = new List<PlayingCard>();
        p2t = new List<PlayingCard>();
        RemoveDisputeDisplay();
    }
    public List<PlayingCard> DeckCombiner( List<PlayingCard> deck,  List<PlayingCard> deck2)
    {
        List<PlayingCard> newdeck = new List<PlayingCard>();
        foreach (PlayingCard pc in deck)
        {
            newdeck.Add(pc);
        }
        foreach (PlayingCard pc in deck2)
        {
            newdeck.Add(pc);
        }       

        return newdeck;
    }    
    public void CardFight()
    {
        if (TableIsEmpty())
            return;

        PlayingCard player1LastTableCard = p1t[p1t.Count - 1];
        PlayingCard player2LastTableCard = p2t[p2t.Count - 1];

        
        if ((player1LastTableCard.name == "6" && player2LastTableCard.name == "ace"))
        {
            Debug.Log("6 vs ace!");
            Player1Win();
        }
        else if (player1LastTableCard.name == "ace" && player2LastTableCard.name == "6")
        {
            Debug.Log("6 vs ace!");
            Player2Win();
        }
        else if (player1LastTableCard.power > player2LastTableCard.power)
        {
            Player1Win();
        }
        else if (player1LastTableCard.power == player2LastTableCard.power)
        {
            HandleDispute();
        }
        else if (player1LastTableCard.power < player2LastTableCard.power)
        {
            Player2Win();
        }
        ShowCard();
    }
    bool TableIsEmpty()
    {
        if (p1t.Count > 0 && p2t.Count > 0)
        {
            return false;
        }
        else return true;

    }
    void ShowCard()
    {
        // set card count text
        player1CardCount.text = p1d.Count.ToString();
        player2CardCount.text = p2d.Count.ToString();

        // check if table is empty and disable table images
        if (TableIsEmpty())
        {
            player1TableCardName.text = " ";
            player1TableCardImage.enabled = false;

            player2TableCardName.text = " ";
            player2TableCardImage.enabled = false;

            // also, leave from update
            return;
        }        

        // show table cards
        player1TableCardImage.enabled = true;
        player2TableCardImage.enabled = true;

        // set top table card vars
        PlayingCard player1LastTableCard = p1t[p1t.Count - 1];
        PlayingCard player2LastTableCard = p2t[p2t.Count - 1];

        // update images and text for table top cards
        player1TableCardName.text = player1LastTableCard.name + " of " + player1LastTableCard.format + "s";
        player1TableCardName.color = PickColor(player1LastTableCard.format);
        player1TableCardImage.sprite = player1LastTableCard.image;
        
        player2TableCardName.text = player2LastTableCard.name + " of " + player2LastTableCard.format + "s";
        player2TableCardName.color = PickColor(player2LastTableCard.format);
        player2TableCardImage.sprite = player2LastTableCard.image;
    }    

    // show dispute if any player has only 1 card 
    void Dispute1Display()
    {
        foreach(Image img in Dispute1)
        {
            img.enabled = true;
        }
    }

    // show normal dispute with 2 cards
    void Dispute2Display()
    {
        Dispute1Display();
        foreach (Image img in Dispute2)
        {
            img.enabled = true;
        }
    }

    // disable visual of cards stack in dispute
    void RemoveDisputeDisplay()
    {
        foreach (Image img in Dispute1)
        {
            img.enabled = false;
        }
        foreach (Image img in Dispute2)
        {
            img.enabled = false;
        }
    }

    void HandleDispute()
    {
        Dispute = true;
        Debug.LogWarning("Dispute!");
        if ((p1d.Count == 0) || (p2d.Count == 0))
        {
            Debug.LogWarning("No cards Left");
            CheckWinner();
        }
        else if ((p1d.Count == 1) || (p2d.Count == 1))
        {
            Dispute1Display();
            Debug.LogWarning("1 cards left");
            PutCardsToTable(true);
        }
        else
        {
            Dispute2Display();
            Debug.LogWarning("2 or more cards left");
            PutCardsToTable(true);
            PutCardsToTable(true);
        }
    }    
    void Player1Win()
    {
        //Debug.Log("Player 1 Won round!");
        GrabCardsFromTableTo(p1d);
    }
    void Player2Win()
    {
        //Debug.Log("Player 2 Won round!");
        GrabCardsFromTableTo(p2d);
    }
    public Color PickColor(string type)
    {
        Color newCol = Color.black;
        if (type == "heart" || type == "diamond")
        {
            newCol = Color.red;
        }

        return newCol;
    }
    void CheckWinner()
    {
        if (p1d.Count == 0)
        {
            Debug.Log("Player 2 win!");
            player1TableCardName.text = "Player 2 win!";
            player2TableCardName.text = "Player 2 win!";
            WinnerText.text = "Player 2 win!";
        }
        else if (p2d.Count == 0)
        {
            Debug.Log("Player 1 win");
            player1TableCardName.text = "Player 1 win!";
            player2TableCardName.text = "Player 1 win!";
            WinnerText.text = "Player 1 win!";
        }
        CleanTable();
        ShowCard();

        engGamePanel.SetActive(true);
    }

  /*
    public void SwitchAutoFight()
    {
        if (AutoFight)
        {
            AutoFight = false;
        }
        else if (!AutoFight)
        {
            AutoFight = true;
        }
        
    }
    // Use this for initialization
	

    // Update is called once per frame
	void Update () {
        if (AutoFight)
        {
            if (nextTime <= Time.timeSinceLevelLoad)
            {
                MakeMove();
                nextTime = Time.timeSinceLevelLoad + Timer;
            }
        }       
	}
    */
    void CheckAllShit()
    {
        if ((player1TableCardName == null) || (player2TableCardName == null) || (player1CardCount == null) || (player2CardCount == null) || (player1TableCardImage == null) || (player2TableCardImage == null))
        {
            Debug.LogError("SOMETHING IS NOT SET IN EDITOR!!!");
        }
    }
    void FillDeck()
    {
        int i = 0;
        foreach (string format in formats)
        {
            foreach (string card in cards)
            {
                string texname = format + "-" + card;
                Sprite mytex = Resources.Load<Sprite>(texname);
                PlayingCard newcard = new PlayingCard(card, format, power, mytex);
                wholeDeck[i] = newcard;
                power++;
                i++;
                //Debug.Log(newcard.name + " " + newcard.format + " " + newcard.power + " " + newcard.image.name);
            }
            power = 6;
        }
    }
    void RandomizeDeck()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < wholeDeck.Length; t++)
        {
            PlayingCard tmp = wholeDeck[t];
            int r = Random.Range(t, wholeDeck.Length);
            wholeDeck[t] = wholeDeck[r];
            wholeDeck[r] = tmp;
        }
    }
    void SplitDeck()
    {
        p1d.Clear();
        p2d.Clear();
        for (int i = 0; i <= 17; i++)
        {
            p1d.Add(wholeDeck[i]);
            p2d.Add(wholeDeck[16 + i]);
        }
    }   
}

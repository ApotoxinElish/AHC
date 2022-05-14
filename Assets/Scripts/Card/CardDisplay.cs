using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{

    public TMP_Text nameText;
    // public TMP_Text attackText;
    // public TMP_Text healthText;
    // public TMP_Text effectText;

    public Image backgroundImage;

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCard()
    {
        // nameText.text = card.title;
        if (card is InvestigatorCard)
        {
            var monster = card as InvestigatorCard;
            // attackText.text = monster.attack.ToString();
            // healthText.text = monster.healthPoint.ToString();

            // effectText.gameObject.SetActive(false);
        }
        else if (card is AssetCard)
        {
            var spell = card as AssetCard;
            // effectText.text = spell.effect;

            // attackText.gameObject.SetActive(false);
            // healthText.gameObject.SetActive(false);
        }
    }
}

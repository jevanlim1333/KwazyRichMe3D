using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using Random=System.Random;

public class TreasureBoxCanvas : MonoBehaviour
{
    public List<Card> listOfCard;
    public TMP_Text title;
    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTreasureBoxCanvas()
    {
        GetComponent<Canvas>().enabled = true;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseTreasureBoxCanvas()
    {
        GetComponent<Canvas>().enabled = false;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public IEnumerator SelectCard()
    {
        OpenTreasureBoxCanvas(); 
        closeButton.gameObject.SetActive(false);
        title.text = "You have received the following card";

        foreach (Card card in listOfCard)
        {
            card.transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }
        int chosenCardNumber = new Random().Next(0,9);
        Card chosenCard = listOfCard[chosenCardNumber];
        chosenCard.GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(2f);
        ResetCanvas();
        CloseTreasureBoxCanvas();
        chosenCard.CardAction();
    }

    public void ResetCanvas()
    {
        title.text = "Possible Treasure Box Cards";
        foreach (Card card in listOfCard)
        {
            card.transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        }
        closeButton.gameObject.SetActive(true);
    }
}

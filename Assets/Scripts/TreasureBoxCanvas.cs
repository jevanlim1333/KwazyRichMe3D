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
    public bool BeginAction;
    public Card chosenCard;

    // Start is called before the first frame update
    void Start()
    {
        BeginAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BeginAction)
        {
            ResetCanvas();
            CloseTreasureBoxCanvas();
            chosenCard.CardAction();
            BeginAction = false;
        }
    }

    public void OpenTreasureBoxCanvas()
    {
        Debug.Log("Opening Treasure Box Canvas");
        GetComponent<Canvas>().enabled = true;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseTreasureBoxCanvas()
    {
        Debug.Log("Closing Treasure Box Canvas");
        GetComponent<Canvas>().enabled = false;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void SelectCard()
    {
        Debug.Log("SelectCard");
        OpenTreasureBoxCanvas(); 
        closeButton.gameObject.SetActive(false);
        title.text = "You have received the following card";

        foreach (Card card in listOfCard)
        {
            card.transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }
        int chosenCardNumber = new Random().Next(0,9);
        chosenCard = listOfCard[chosenCardNumber];
        chosenCard.transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        BeginAction = true;
    }

    public void ResetCanvas()
    {
        Debug.Log("Resetting Canvas");
        title.text = "Possible Treasure Box Cards";
        foreach (Card card in listOfCard)
        {
            card.transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        }
        closeButton.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PropertyCanvas : MonoBehaviour
{
    public Canvas canvas;
    public Property property;
    public Button purchaseButton;
    public Button dontPurchaseButton;
    public Button closeButton;
    public TMP_Text ownedByText;

    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;
        purchaseButton = canvas.transform.Find("Purchase Button").GetComponent<Button>();
        dontPurchaseButton = canvas.transform.Find("Dont Purchase Button").GetComponent<Button>();
        closeButton = canvas.transform.Find("close").GetComponent<Button>();
        ownedByText = canvas.transform.Find("OwndBy Text").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openCanvas() // open when in game
    {
        canvas.GetComponent<Canvas>().enabled = true;
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        purchaseButton.gameObject.SetActive(false); // cannot see purchase button
        dontPurchaseButton.gameObject.SetActive(false); // cannot see dont purchase button
        closeButton.gameObject.SetActive(true); // can see close button

        Debug.Log("Opening " + canvas + " now");

    }
    public void closeCanvas() // close when in game
    {
        canvas.GetComponent<Canvas>().enabled = false;
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void Purchasing() // open when player lands
    {
        canvas.GetComponent<Canvas>().enabled = true;
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        purchaseButton.gameObject.SetActive(true); // cannot see purchase button
        dontPurchaseButton.gameObject.SetActive(true); // cannot see dont purchase button
        closeButton.gameObject.SetActive(false); // can see close button

        if (GameScript.instance.playerToken.bones < property.cost)
        {
            purchaseButton.interactable = false;
        }
    }

    public void PurchaseProperty()
    {
        closeCanvas();
        property.SendPurchaseProperty();
    }

    public void DontPurchaseProperty()
    {
        closeCanvas();
        TileManager.instance.FinishedTileAction();
    }
}

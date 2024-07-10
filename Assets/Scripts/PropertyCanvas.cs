using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyCanvas : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openCanvas()
    {
        canvas.GetComponent<Canvas>().enabled = true;
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("Opening " + canvas + " now");

    }
    public void closeCanvas()
    {
        canvas.GetComponent<Canvas>().enabled = false;
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

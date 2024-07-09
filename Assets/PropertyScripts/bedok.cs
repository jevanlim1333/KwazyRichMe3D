using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedok : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openBedok()
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

    }
    public void closeBedok()
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

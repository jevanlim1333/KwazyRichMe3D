using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;

public class luckywheel : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private Text uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;
    public Canvas wheelCanvas;
    public Canvas backgroundCanvas;
    [SerializeField] public int result;
    public Button closeButton;

    void Start()
    {
        uiSpinButton.onClick.AddListener (() => { 
            uiSpinButton.interactable = false;
            uiSpinButtonText.text = "Spinning";

            pickerWheel.OnSpinStart(() => {
                Debug.Log("Spin started");
            });

            pickerWheel.OnSpinEnd(wheelPiece => {
                Debug.Log("Spin end: Label:" + wheelPiece.Label + " , Amount:" + wheelPiece.Amount);
                result = wheelPiece.Amount;
                uiSpinButton.interactable = true;
                uiSpinButtonText.text = "Spin";
                closeTreats();
                TileManager.instance.SendTreatResult(result);
            });
            pickerWheel.Spin();
        });
 
    }

    public void openTreats()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("lucky wheel");
        
        wheelCanvas.GetComponent<Canvas>().enabled = true;
        backgroundCanvas.GetComponent<Canvas>().enabled = true;

        CanvasGroup wheelCanvasGroup = wheelCanvas.GetComponent<CanvasGroup>();
        CanvasGroup backgroundCanvasGroup = backgroundCanvas.GetComponent<CanvasGroup>();

        wheelCanvasGroup.alpha = 1;
        wheelCanvasGroup.interactable = true;
        wheelCanvasGroup.blocksRaycasts = true;

        backgroundCanvasGroup.alpha = 1;
        backgroundCanvasGroup.interactable = true;
        backgroundCanvasGroup.blocksRaycasts = true;

        uiSpinButton.gameObject.SetActive(false);
        uiSpinButtonText.enabled = false;

        Debug.Log("Opening treats canvas now");
    }
    public void closeTreats()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        
        wheelCanvas.GetComponent<Canvas>().enabled = false;
        backgroundCanvas.GetComponent<Canvas>().enabled = false;

        CanvasGroup wheelCanvasGroup = wheelCanvas.GetComponent<CanvasGroup>();
        CanvasGroup backgroundCanvasGroup = backgroundCanvas.GetComponent<CanvasGroup>();

        wheelCanvasGroup.alpha = 0;
        wheelCanvasGroup.interactable = false;
        wheelCanvasGroup.blocksRaycasts = false;

        backgroundCanvasGroup.alpha = 0;
        backgroundCanvasGroup.interactable = false;
        backgroundCanvasGroup.blocksRaycasts = false;


        Debug.Log("Closing treats canvas now");
    }

    public void openTreatsToSpin()
    {
        wheelCanvas.GetComponent<Canvas>().enabled = true;
        backgroundCanvas.GetComponent<Canvas>().enabled = true;

        CanvasGroup wheelCanvasGroup = wheelCanvas.GetComponent<CanvasGroup>();
        CanvasGroup backgroundCanvasGroup = backgroundCanvas.GetComponent<CanvasGroup>();

        wheelCanvasGroup.alpha = 1;
        wheelCanvasGroup.interactable = true;
        wheelCanvasGroup.blocksRaycasts = true;

        backgroundCanvasGroup.alpha = 1;
        backgroundCanvasGroup.interactable = true;
        backgroundCanvasGroup.blocksRaycasts = true;
        closeButton.gameObject.SetActive(false); // cant close

        Debug.Log("Opening treats canvas now");
    }
}

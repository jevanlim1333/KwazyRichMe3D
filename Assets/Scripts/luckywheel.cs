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
    // Start is called before the first frame update 
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
                uiSpinButton.interactable = true;
                uiSpinButtonText.text = "Spin";
            });
            pickerWheel.Spin();
        });

        wheelCanvas.GetComponent<Canvas>().enabled = false;
        backgroundCanvas.GetComponent<Canvas>().enabled = false;    
    }

    public void openTreats()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("lucky wheel");
        
        wheelCanvas.GetComponent<Canvas>().enabled = true;
        backgroundCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void closeTreats()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

        wheelCanvas.GetComponent<Canvas>().enabled = false;
        backgroundCanvas.GetComponent<Canvas>().enabled = false;    
    }

}

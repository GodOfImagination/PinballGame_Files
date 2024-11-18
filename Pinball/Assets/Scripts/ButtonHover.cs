using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text ButtonText;

    void Start()
    {
        ButtonText = GetComponent<TMP_Text>();
        ButtonText.faceColor = new Color32(255, 255, 255, 155);
    }

    public void OnPointerEnter(PointerEventData EventData)
    {
        ButtonText.faceColor = new Color32(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData EventData)
    {
        ButtonText.faceColor = new Color32(255, 255, 255, 155);
    }
}

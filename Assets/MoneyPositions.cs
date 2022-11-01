using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MoneyPositions : MonoBehaviour
{
    public int count;
  
    public List<Transform> moneyPositionList;
    public Image percentImage;
    public TextMeshProUGUI percentTxt;

    public UnityEvent e = new UnityEvent();

    private void Start()
    {
        e.AddListener(ChangePercentText);
    }
    private void ChangePercentText()
    {
        print("sadsa-----------");
        percentImage.fillAmount = count/100f;
        percentTxt.text = "%"+(count / 100f).ToString();
    }


}

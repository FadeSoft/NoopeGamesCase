using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class Building : MonoBehaviour
{
    public int count;
    public List<Transform> moneyPositionList;
    public Image percentImage;
    public TextMeshProUGUI percentTxt;
    public UnityEvent percentEvent = new UnityEvent();

    private void Start()
    {
        percentEvent.AddListener(ChangePercentText);
    }
    private void ChangePercentText()
    {
        percentImage.fillAmount = count / 100f;
        percentTxt.text = "%" + (count / 100f).ToString();
    }
}

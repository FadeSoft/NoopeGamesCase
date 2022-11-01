using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> moneys;
    public Transform charectersBackParent;
    public Transform charectersBackPos;
    public MoneyPositions moneyPositions;

    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<Money>().isMove = true;
            moneys.Add(other.gameObject);
            charectersBackPos.position += Vector3.up / 3f;
            //other.transform.DOScale(new Vector3(.8f, .4f, .4f), .5f);

        }
        else if (other.CompareTag("SellArea"))
        {
            if (moneys.Count > 0)
            {
                Buy(other.GetComponent<MoneyPositions>().count);

            }
        }
    }

    private void Buy(int count)
    {
        for (int i = 0; i < moneys.Count; i++)
        {

            moneys[moneys.Count - 1].transform.parent = moneyPositions.transform;
            moneys[moneys.Count - 1].transform.DOMove(moneyPositions.moneyPositionList[count].position, 1f);
            moneys[moneys.Count - 1].transform.DORotate(Vector3.zero, 1f);
            moneys[moneys.Count - 1].transform.GetComponent<BoxCollider>().enabled = false;
            moneys.RemoveAt(moneys.Count - 1);
            charectersBackPos.position -= Vector3.up / 3f;
            moneyPositions.e.Invoke();

            count++;
        }
        moneyPositions.count = count;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> moneysOnTheBack;
    public Transform charectersBackParent;
    public Transform charectersBackPos;
    public Building moneyPositions;

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
            moneysOnTheBack.Add(other.gameObject);
            charectersBackPos.localPosition += Vector3.up / 3f;

        }
        else if (other.CompareTag("SellArea"))
        {
            if (moneysOnTheBack.Count > 0)
            {
                print("*****");
                StartCoroutine(Buy(other.GetComponent<Building>().count));

            }
        }
    }

    private IEnumerator Buy(int count)
    {
        int moneysCount = moneysOnTheBack.Count;
        for (int i = 0; i < moneysCount; i++)
        {
            GameObject moneyOnBack = moneysOnTheBack[moneysOnTheBack.Count - 1];
            moneyOnBack.transform.parent = moneyPositions.transform;
            moneyOnBack.transform.DOMove(moneyPositions.moneyPositionList[count].position, 1f);
            moneyOnBack.transform.DORotate(Vector3.zero, 1f);
            moneyOnBack.transform.GetComponent<BoxCollider>().enabled = false;

            moneysOnTheBack.RemoveAt(moneysOnTheBack.Count - 1);
            charectersBackPos.localPosition -= Vector3.up / 3f;
            moneyPositions.percentEvent.Invoke();

            count++;
            yield return new WaitForSeconds(.5f);
        }
        moneyPositions.count = count;

    }
}

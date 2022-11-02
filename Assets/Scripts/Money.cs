using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    public bool isMove;
    void Update()
    {
        if (isMove)
            MoveToCharectersBehind();
    }

    private void MoveToCharectersBehind()
    {
        Vector3 movePos = PlayerController.Instance.charectersBackPos.position;

        transform.position = Vector3.Lerp(transform.position, movePos, 3f);
        transform.DOLocalRotate(Vector3.zero, .3f);

        float distance = Vector3.Distance(transform.position, PlayerController.Instance.charectersBackPos.position);
        if (distance <= .1f)
        {
            isMove = false;
            transform.parent = PlayerController.Instance.charectersBackParent.transform;
        }
    }
}

using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class MovingObj : MonoBehaviour
{

    [SerializeField] private bool closedLoop;
    [SerializeField] private Vector3[] Destination;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private GameObject objPrefab;

    [SerializeField] private bool VisiblePath;
    [SerializeField] private float Delta;

    [SerializeField] private float movingSpeed;

    [SerializeField] private bool spriteToTheFront;

    private GameObject obj;
    private Rigidbody2D objRB;

    void Start()
    {
        /*if (VisiblePath)
        {
            CreatePath();
        }*/
        objRB = obj.GetComponent<Rigidbody2D>();
        MoveObj();
        CreateObj();
    }

    /*private void CreatePath()
    {
        for (int i = 0; i < DestinateList.Length; i++)
        {
            if (DestinateList.Length > i + 1)
            {
                Vector2 startPos = new Vector2(DestinateList[i].x, DestinateList[i].y);
                Vector2 endPos = new Vector2(DestinateList[i + 1].x, DestinateList[i + 1].y);
                Vector2 point = startPos;
                Vector2 direction = (endPos - startPos).normalized;

                while ((endPos - startPos).magnitude > (point - startPos).magnitude)
                {
                    Instantiate(pathPoint, point, Quaternion.identity, this.transform);
                    point += (direction * Delta);
                }
            }
        }
    }*/

    private void CreateObj()
    {
        Vector2 startPos = new Vector2(Destination[0].x, Destination[0].y);
        obj = Instantiate(objPrefab, startPos, Quaternion.identity, this.transform) as GameObject;
        
        if (spriteToTheFront)
        {
            obj.GetComponent<SpriteRenderer>().sortingOrder = 999;
        }
    }

    private void MoveObj()
    {
        Sequence s = DOTween.Sequence();
        if (closedLoop)
        {
            Vector3[] CloseDestination = new Vector3[Destination.Length + 1];
            for (int i = 0; i < Destination.Length; i++)
            {
                CloseDestination[i] = Destination[i];
            }
            Destination[0] = CloseDestination[CloseDestination.Length - 1];
            s.Append(objRB.transform.DOPath(CloseDestination, movingSpeed, PathType.Linear).SetEase(Ease.Linear));
            s.SetLoops(-1, LoopType.Restart);
        }
        else
        {
            s.Append(objRB.transform.DOPath(Destination, movingSpeed, PathType.Linear).SetEase(Ease.Linear));
            s.SetLoops(-1, LoopType.Yoyo);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < Destination.Length; i++)
        {
            Vector2 pos = new Vector2(Destination[i].x, Destination[i].y);
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }
}
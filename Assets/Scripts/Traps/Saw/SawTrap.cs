//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;
//using Unity.VisualScripting;

//public class SawTrap : Traps
//{
//    [SerializeField] private bool closedLoop;
//    [SerializeField] private Vector2[] sawPoints;
//    [SerializeField] private GameObject chainPoint;
//    [SerializeField] private GameObject sawPrefab;

//    [SerializeField] private bool chainVisible;
//    [SerializeField] private float Delta;

//    [SerializeField] private float sawSpeed;

//    [SerializeField] private bool spriteToTheFront;

//    private GameObject sawBlade;
//    private Rigidbody2D sawBladeRB;

//    void Start()
//    {
//        if (chainVisible)
//        {
//            CreateChain();
//        }
//        CreateSawBlade();
//        MoveSawBlade();
//    }

//    private void CreateChain()
//    {
//        for (int i = 0; i < sawPoints.Length; i++)
//        {
//            if (sawPoints.Length > i + 1)
//            {
//                Vector2 startPos = new Vector2(sawPoints[i].x, sawPoints[i].y);
//                Vector2 endPos = new Vector2(sawPoints[i + 1].x, sawPoints[i + 1].y);
//                Vector2 point = startPos;
//                Vector2 direction = (endPos - startPos).normalized;

//                while ((endPos - startPos).magnitude > (point - startPos).magnitude)
//                {
//                    Instantiate(chainPoint, point, Quaternion.identity, this.transform);
//                    point += (direction * Delta);
//                }
//            }
//        }
//    }

//    private void CreateSawBlade()
//    {
//        Vector2 startPos = new Vector2(sawPoints[0].x, sawPoints[0].y);
//        sawBlade = Instantiate(sawPrefab, startPos, Quaternion.identity, this.transform) as GameObject;
//        sawBladeRB = sawBlade.GetComponent<Rigidbody2D>();
//        if (spriteToTheFront)
//        {
//            sawBlade.GetComponent<SpriteRenderer>().sortingOrder = 999;
//        }
//    }

//    private void MoveSawBlade()
//    {

//        DG.Tweening.Sequence s = DOTween.Sequence();
//        if (closedLoop)
//        {
//            Vector2[] newArray = new Vector2[sawPoints.Length + 1];
//            for (int i = 0; i < sawPoints.Length; i++)
//            {
//                newArray[i] = sawPoints[i];
//            }
//            newArray[newArray.Length - 1] = sawPoints[0];
//            s.Append(sawBladeRB.DOPath(newArray, sawSpeed, PathType.Linear).SetEase(Ease.Linear));
//            s.SetLoops(-1, LoopType.Restart);
//        }
//        else
//        {
//            s.Append(sawBladeRB.DOPath(sawPoints, sawSpeed, PathType.Linear).SetEase(Ease.Linear));
//            s.SetLoops(-1, LoopType.Yoyo);
//        }
//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.yellow;
//        for (int i = 0; i < sawPoints.Length; i++)
//        {
//            Vector2 pos = new Vector2(sawPoints[i].x, sawPoints[i].y);
//            Gizmos.DrawSphere(pos, 0.3f);
//        }
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Скрипт отвечает за перемещение игрока по заданной траектории
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private NavMeshAgent playerAgent;
    [SerializeField]
    private Animator playerAnim;
    [SerializeField]
    private LineRenderer playerWay;
    [SerializeField]
    private LayerMask layerWay;
    [SerializeField]
    private LayerMask layerUI;

    private List<Vector3> pointsWay = new List<Vector3>();

    private bool isWay = false;
    private Vector3 currentPoint;
    private int countPointLines = 1;
    private int countPointEnd = 0;

    private const float RAY_LENGTH = 1000;

    private void Awake()
    {
        playerAgent.speed = speed;
    }
    private void Update()
    {
        if(Time.timeScale == 0f)
        {
            return;
        }
        playerAnim.SetBool("isWalk", isWay);
        if(pointsWay.Count > 0 && !isWay)
        {
            GetTargetPoint();
        }

        if(currentPoint.x == transform.position.x && currentPoint.z == transform.position.z)
        {
            isWay = false;
        }

        if (Input.touchCount > 0)
        {
            AddPoint();
        }

       if (pointsWay.Count == 0 && !isWay)
       {
            ClearVariable();
       }

        if (isWay)
        {
            ClearDrawLines();
        }
    }

    private void GetTargetPoint()
    {
        currentPoint = pointsWay[0];
        playerAgent.SetDestination(currentPoint);
        pointsWay.RemoveAt(0);
        isWay = true;
        countPointEnd++;
    }

    private void AddPoint()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return;
        }
        Ray clickRay = Camera.main.ScreenPointToRay(touch.position);

        if (Physics.Raycast(clickRay, out RaycastHit hit, RAY_LENGTH,layerWay | layerUI))
        {
            if(hit.transform.gameObject.tag != "Field")
            {
                return;
            }
            pointsWay.Add(hit.point);

            countPointLines++;
            playerWay.positionCount = countPointLines;

            if (countPointLines == 2)
            {
                playerWay.SetPosition(countPointLines - 2, transform.position);
            }

            playerWay.SetPosition(countPointLines - 1, hit.point + new Vector3(0, 0.5f, 0));
        }
    }

    private void ClearVariable()
    {
        countPointLines = 1;
        playerWay.positionCount = 0;
        countPointEnd = 0;
    }

    private void ClearDrawLines()
    {
        for (int i = 0; i < countPointEnd; i++)
        {
            playerWay.SetPosition(i, transform.position);
        }
    }
}

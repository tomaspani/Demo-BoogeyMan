using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class FollowCandy : MonoBehaviour
{
    public NavMeshAgent Kid;
    [SerializeField] Transform CandyPosition;
    [SerializeField] GameObject TargetedCandy;
    [SerializeField] float Distance;
    public float FollowDistance;

    private void Update()
    {
        TargetedCandy = NearestCandy();
        Distance = Vector3.Distance(this.transform.position, TargetedCandy.transform.position);
        if (Distance < FollowDistance)
        {ChaseCandy();}
       
        
    }

    GameObject NearestCandy ()
    {
        return GameObject.FindGameObjectsWithTag("Candy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1);
    }
    void ChaseCandy ()
    {
        CandyPosition = TargetedCandy.GetComponent<Transform>();
        Kid.SetDestination(CandyPosition.position);
    }
}

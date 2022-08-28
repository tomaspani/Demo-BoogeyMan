using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultController : MonoBehaviour
{

    [SerializeField] float suspcionValue;
    private FieldOfView _fov;


    private void Start()
    {
        if(_fov == null)
        {
            _fov = this.GetComponent<FieldOfView>();
        }
        
    }

    private void Update()
    {
        if (_fov.canSeePlayer)
            addSuspicion(_fov.playerRef);
        else
            looseSuspicion(_fov.playerRef);
      
        
    }

    public void addSuspicion(GameObject player)
    {
        player.GetComponent<PlayerController>().addSuspicion(suspcionValue * Time.deltaTime);
    }

    public void looseSuspicion(GameObject player)
    {
        player.GetComponent<PlayerController>().looseSuspicion(suspcionValue / 8f  * Time.deltaTime);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider sus;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    private void Update()
    {
        sus.value = player.suspicion;
    }
}

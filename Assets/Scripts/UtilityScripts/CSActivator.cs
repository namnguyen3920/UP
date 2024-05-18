using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Playables;

public class CSActivator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayableDirector cutscene;

    float player_pos_x;

    private void Update()
    {
        player_pos_x = player.transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController.d_Instance.isIdle = true;
            cutscene.Play();
        }
    }
}

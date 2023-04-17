using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    float max_look_time = 1f;
    float current_look_time = 0;
    bool looking_right = true;

    float start_rotY;


    void Start()
    {
        start_rotY = transform.parent.eulerAngles.y;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {

        string tag = gameObject.tag;

        if (tag == "Gargoyle")
        {
            float t;
            current_look_time += Time.deltaTime;

            if (current_look_time > max_look_time)
            {
                current_look_time = 0;
                looking_right = !looking_right;
            }
            t = current_look_time / max_look_time;

            if (looking_right)
            {
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, start_rotY + 50, 0), Quaternion.Euler(0, start_rotY - 50, 0), t);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, start_rotY - 50, 0), Quaternion.Euler(0, start_rotY + 50, 0), t);
            }
        }

        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
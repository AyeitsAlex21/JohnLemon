using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform endGoal;
    public Transform Arrow;

    Animator m_Animator;
    Rigidbody m_Rigidbody;

    Vector3 m_Movement;
    public float turnSpeed = 20;
    Quaternion m_Rotation = Quaternion.identity;
    AudioSource m_AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 goal_dir = endGoal.position - transform.position;

        float dotRefZ = Vector3.Dot(Vector3.forward.normalized, goal_dir.normalized);
        float dotRefX = Vector3.Dot(Vector3.right.normalized, goal_dir.normalized);

        float angle = Mathf.Rad2Deg * Mathf.Atan2(dotRefX, dotRefZ);
        Arrow.rotation = Quaternion.Euler(0, angle, 0);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}

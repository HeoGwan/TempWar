using System.Collections;
using System.Collections.Generic;
using TempWar;
using Unity.VisualScripting;
using UnityEngine;

namespace TempWar
{
    public struct MoveMent
    {
        public float horizontal;
        public float vertical;
    }
}

public class PlayerMove : MonoBehaviour
{
    // Variables
    [SerializeField] private float      m_moveSpeed = 100f;
    [SerializeField] private float      m_rotateoveSpeed = 100f;
    [SerializeField] private float      m_jumpPower = 100f;
    // private float                    m_mouseAngleX = 0;
    // private float                    m_mouseAngleY = 0;

    // Structs
    private MoveMent                    m_mouseAngle;
    private MoveMent                    m_moveInput;
    
    // Components
    private Rigidbody                   m_rigid;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        
        m_mouseAngle.horizontal += mouseMoveX * m_rotateoveSpeed * Time.deltaTime;
        m_mouseAngle.vertical += -mouseMoveY * m_rotateoveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(m_mouseAngle.vertical, m_mouseAngle.horizontal, 0);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        m_moveInput.horizontal = h * m_moveSpeed * Time.deltaTime;
        m_moveInput.vertical = v * m_moveSpeed * Time.deltaTime;
        Vector3 moveVec = transform.TransformDirection(new Vector3(m_moveInput.horizontal, 0, m_moveInput.vertical));
        transform.position += moveVec;

        if (Input.GetButtonDown("Jump"))
        {
            m_rigid.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
        }

        Debug.DrawLine(transform.position, transform.forward * 10, Color.red);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TempWar;

public class Floor : MonoBehaviour
{
    private MeshRenderer                    m_mesh;

    [Header("Variable")]
    [SerializeField] private Color          m_floorColor;
    [SerializeField] private float          m_changeColorValue = 0.1f;
    [SerializeField] private ETempType      m_floorType;

    // Getter, Setter
    public ETempType                        FloorType { get => m_floorType; }

    private void Start() {
        m_mesh = GetComponent<MeshRenderer>();
        m_floorColor = m_mesh.material.color;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Bullet"))
        {
            ETempType bulletTempType = other.collider.GetComponent<Bullet>().BulletTempType;
            m_floorColor.r += bulletTempType == ETempType.HOT ? m_changeColorValue : -m_changeColorValue;
            m_floorType = bulletTempType == ETempType.HOT ? ETempType.HOT : ETempType.COLD;

            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        Debug.Log(m_floorColor);
        m_mesh.material.color = m_floorColor;
    }
}

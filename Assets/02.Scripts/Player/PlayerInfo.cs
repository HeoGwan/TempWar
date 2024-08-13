using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TempWar;

public class PlayerInfo : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI    m_showTempText;

    [Space(10)]
    [Header("Variable")]
    [SerializeField] private float              m_temperature = 36.5f;
    [SerializeField] private float              m_changeTempValue = 0.1f;
    [SerializeField] private float              m_changeTempDelay = 1.2f;

    private RaycastHit                          m_hit;
    private ETempType                           m_tempType = ETempType.NORMAL;

    void Start()
    {
        m_showTempText.text = m_temperature.ToString();
    }

    void Update() {
        if(Physics.Raycast(transform.position, Vector3.down * 2, out m_hit))
        {
            Collider hit = m_hit.collider;
            if (hit.CompareTag("Floor") && hit.GetComponent<Floor>().FloorType == ETempType.HOT)
            {
                ChangeColor(true);
                return;
            }
            
            if (m_tempType != ETempType.NORMAL)
            {
                StopAllCoroutines();
                m_tempType = ETempType.NORMAL;
            }
        }
    }

    void ChangeColor(bool isUp)
    {
        m_temperature += isUp ? m_changeTempValue : -m_changeTempValue;
        m_showTempText.text = m_temperature.ToString();
    }

    // public void Hot()
    // {
    //     m_tempType = ETempType.HOT;
    //     StartCoroutine(ChangeColor(true));
    // }

    // IEnumerator ChangeColor(bool isUp)
    // {
    //     yield return new WaitForSeconds(m_changeTempDelay);
    //     m_temperature += isUp ? m_changeTempValue : -m_changeTempValue;
    //     m_showTempText.text = m_temperature.ToString();
    // }
}

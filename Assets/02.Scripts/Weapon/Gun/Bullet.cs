using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TempWar;

public class Bullet : MonoBehaviour
{
    [Space(10)]
    [Header("Variable")]
    [SerializeField] private float      m_shootTime = 1.5f;
    [SerializeField] private float      m_shootSpeed = 3f;
    [SerializeField] private ETempType  m_tempType;

    private Vector3                     m_shootVec;

    // Getter, Setter
    public ETempType                    BulletTempType { get => m_tempType; }

    void Start() {
        StartCoroutine(Shooting());
    }

    void Update() {
        transform.position += m_shootSpeed * m_shootVec * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Floor"))
        {
            // Debug.Log("Collision to floor");
            Destroy(gameObject);
        }
    }

    public void Init(Transform shootLocation)
    {
        transform.position = shootLocation.position;
    }

    public void Init(Transform shootLocation, Vector3 shootVec)
    {
        transform.position = shootLocation.position;
        m_shootVec = shootVec;
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(m_shootTime);
        Destroy(gameObject);
    }
}

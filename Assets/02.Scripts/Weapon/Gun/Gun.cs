using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TempWar;

public class Gun : Weapon
{
    [Header("Prefab")]
    [SerializeField] private GameObject m_bulletPrefab;

    [Space(10)]
    [Header("Transform")]
    [SerializeField] private Transform  m_shootLocation;

    [Space(10)]
    [Header("Variable")]
    [SerializeField] private float      m_shootDelay = 0.2f;

    private bool                        m_canShoot = true;

    public override void Action()
    {
        if (!m_canShoot) return;

        Instantiate(m_bulletPrefab).GetComponent<Bullet>().Init(m_shootLocation);
        m_canShoot = false;
        StartCoroutine(ShootDelay());
    }

    public override void Action(Vector3 forward) 
    {
        if (!m_canShoot) return;

        Instantiate(m_bulletPrefab).GetComponent<Bullet>().Init(m_shootLocation, forward);
        m_canShoot = false;
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(m_shootDelay);
        m_canShoot = true;
    }
}

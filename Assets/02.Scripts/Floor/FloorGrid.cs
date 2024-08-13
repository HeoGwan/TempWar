using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject     m_floorPrefab;

    [Space(10)]
    [Header("Variable")]
    [SerializeField] private int            m_xGrid = 10;
    [SerializeField] private int            m_yGrid = 10;

    private GameObject[,]                   m_floorGrid;

    void Start()
    {
        m_floorGrid = new GameObject[m_yGrid, m_xGrid];
        SetFloorGrid();
    }

    private void SetFloorGrid()
    {
        for (int x = 0; x < m_xGrid; x++)
        {
            for (int y = 0; y < m_yGrid; y++)
            {
                m_floorGrid[y, x] = Instantiate(m_floorPrefab, new Vector3(x * m_xGrid, 0, y * m_yGrid), Quaternion.identity);
                m_floorGrid[y, x].transform.parent = transform;
                m_floorGrid[y, x].gameObject.name = $"Floor {y}, {x}";
            }
        }
    }
}

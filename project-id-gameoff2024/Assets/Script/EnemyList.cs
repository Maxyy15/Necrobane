using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameObject> enemyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!enemyList.Contains(enemy))
            {
                enemyList.Add(enemy);
            }
        }
        for (int i = enemyList.Count - 1; i > 0; i--)
        {
            if (enemyList[i].activeInHierarchy == false)
            {
                enemyList.RemoveAt(i);
            }
        }
        enemyList.Sort();
    }
}

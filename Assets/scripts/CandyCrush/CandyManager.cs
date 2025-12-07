using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyManager : MonoBehaviour
{
    public List<Sprite> candySprites;
    public GameObject candyPrefab;
    private List<List<GameObject>> candysList = new List<List<GameObject>>();
    public List<GameObject> SpawnPoints;
    public int heigth;
    public int DelayTime;
    public int maxInRow = 4;
    public GameObject StopGameObject;
    
    IEnumerator spawnCandy()
    {
        if (candysList.Count != 0)
        {
            StopGameObject.SetActive(false);
            yield return new WaitForSeconds(DelayTime);
        }
        StopGameObject.SetActive(true);
        for (int i = 0; i < heigth; i++)
        {
            List<GameObject> tempList = new List<GameObject>();
            for (int j = 0; j < 8; j++)
            {
                int randomSprite = Random.Range(0, candySprites.Count);
                GameObject Temp = candyPrefab;
                Temp.GetComponent<SpriteRenderer>().sprite = candySprites[randomSprite];
                Temp.GetComponent<CandyType>().icon = GetEnum(randomSprite);
                Instantiate(candyPrefab, SpawnPoints[j].transform.position, Quaternion.identity, SpawnPoints[j].transform);
                yield return new WaitForSeconds(0.1f);
            }
        }

        StartCoroutine(saveList());
        yield return null;
    }

   IEnumerator saveList()
{
    candysList = new List<List<GameObject>>();
    bool iteration = true;

    while (iteration)
    {
        iteration = false; 
        candysList.Clear();
        for (int i = 0; i < heigth; i++)
        {
            List<GameObject> tempList = new List<GameObject>();
            foreach (var spawns in SpawnPoints)
            {
                int spawnsChild = spawns.transform.childCount;
                if (spawnsChild > i)
                {
                    Transform tempChild = spawns.transform.GetChild(i);
                    GameObject TempChildGO = tempChild.gameObject;
                    tempList.Add(TempChildGO);
                }
            }
            candysList.Add(tempList);
        }

        bool destroyedSomething = false;
        for (int row = 0; row < candysList.Count; row++)
        {
            List<GameObject> currentRow = candysList[row];
            int count = 1;

            for (int col = 1; col < currentRow.Count; col++)
            {
                IconType prevIcon = currentRow[col - 1].GetComponent<CandyType>().icon;
                IconType currentIcon = currentRow[col].GetComponent<CandyType>().icon;

                if (prevIcon == currentIcon)
                {
                    count++;
                    if (count >= maxInRow)
                    {
                        for (int k = col - count + 1; k <= col; k++)
                        {
                            GameObject toDestroy = currentRow[k];
                            if (toDestroy != null)
                            {
                                Destroy(toDestroy);
                                destroyedSomething = true;
                            }
                        }
                    }
                }
                else
                {
                    count = 1;
                }
            }
        }
        int maxCols = SpawnPoints.Count;
        for (int col = 0; col < maxCols; col++)
        {
            int count = 1;
            for (int row = 1; row < candysList.Count; row++)
            {
                if (col < candysList[row - 1].Count && col < candysList[row].Count)
                {
                    IconType prevIcon = candysList[row - 1][col].GetComponent<CandyType>().icon;
                    IconType currentIcon = candysList[row][col].GetComponent<CandyType>().icon;

                    if (prevIcon == currentIcon)
                    {
                        count++;
                        if (count >= maxInRow)
                        {
                            for (int k = row - count + 1; k <= row; k++)
                            {
                                GameObject toDestroy = candysList[k][col];
                                if (toDestroy != null)
                                {
                                    Destroy(toDestroy);
                                    destroyedSomething = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }
        }

        // repetir el while solo si se destruyó una secuencia
        if (destroyedSomething)
        {
            iteration = true;
        }

        yield return new WaitForSeconds(0.3f);
    }

    yield return null;
}

    public void Reroll()
    {
        StartCoroutine(spawnCandy());
    }

    public IconType GetEnum(int enumIndex)
    {
        Array enumValues = Enum.GetValues(typeof(IconType));
        return (IconType)enumValues.GetValue(enumIndex);
    }
}

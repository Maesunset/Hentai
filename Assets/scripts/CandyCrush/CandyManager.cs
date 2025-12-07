using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyManager : MonoBehaviour
{
    public List<Sprite> candySprites;
    public GameObject candyPrefab;
    private List<List<GameObject>> candysList;
    public List<GameObject> SpawnPoints;
    public int heigth;

    IEnumerator spawnCandy()
    {
        for (int i = 0; i < heigth; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int randomSprite = Random.Range(0, candySprites.Count);
                GameObject Temp = candyPrefab;
                Temp.GetComponent<SpriteRenderer>().sprite = candySprites[randomSprite];
                Temp.GetComponent<CandyType>().icon = GetEnum(randomSprite);
                Instantiate(candyPrefab, SpawnPoints[j].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
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

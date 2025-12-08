using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotsGameManager : MonoBehaviour
{
    [Header("Slots Materias")]
    public List<Material> SlotsMaterias;
    public int maxOptions;
    public float delayTime;
    public List<int> SlotAnswersList;
    public bool canRool = true;
    public GirlLove girlLove;
    public SoundManager soundManager;
    public AudioSource slotAudioSource;
    public AudioSource checkSource;
    
    public void Roll()
    {
        if (canRool)
        {
            soundManager.BotonPlay();
            foreach (Material mat in SlotsMaterias)
            {
                mat.SetFloat("_Gamble",1);
            }
            StartCoroutine(stop());
        }
        
    }

    IEnumerator  stop()
    {
        slotAudioSource.Play();
        SlotAnswersList.Clear();
        SlotAnswersList = new List<int>();
        canRool = false;
        yield return new WaitForSeconds(3);
        foreach (Material mat in SlotsMaterias)
        {
            yield return new WaitForSeconds(delayTime);
            
            int random = Random.Range(0,maxOptions);
            mat.SetFloat("_Choice",random);
            SlotAnswersList.Add(random);
            mat.SetFloat("_Gamble",0);
            checkSource.Play();
        }
        
        Solution();
        yield return null;
    }

    private void Solution()
    {
        int sameAnswerds = 0;
        if (SlotAnswersList[0] == SlotAnswersList[1] && SlotAnswersList[1] == SlotAnswersList[2])
        {
            sameAnswerds = 3;
        }
        else if(SlotAnswersList[0] != SlotAnswersList[1] && SlotAnswersList[1] != SlotAnswersList[2] && SlotAnswersList[0] != SlotAnswersList[2])
        {
            sameAnswerds = 1;
        }
        else
        {
            sameAnswerds = 2;
        }
        
        switch (sameAnswerds)
        {
            case 1:
                soundManager.BadPlay();
                girlLove.SubtractHappiness();
                break;
            case 2:
                soundManager.GoodPlay();
                girlLove.AddHappiness();
                break;
            case 3:
                soundManager.GoodPlay();
                girlLove.AddHappiness();
                girlLove.AddHappiness();
                girlLove.AddHappiness();
                girlLove.AddHappiness();
                break;
        }
        canRool = true;
        slotAudioSource.Stop();
    }
}
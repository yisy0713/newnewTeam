using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("���翡�� �����ϱ�", new int[] { 1000, 2000 }));

        questList.Add(20, new QuestData("������Ǯ ���ϱ�", new int[] { 5000, 2000 }));

        questList.Add(30, new QuestData("������Ǯ ���̱�", new int[] { 6000, 2000 }));

        questList.Add(40, new QuestData("�ð� �ǵ�����", new int[] { 7000, 2000 }));

        questList.Add(50, new QuestData("����Ʈ �� Ŭ����", new int[] { 0 }));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                }
                break;
            case 30:
                if (questActionIndex == 1)
                {
                    questObject[1].SetActive(false);
                    questObject[2].SetActive(true);
                }
                break;
            case 40:
                if (questActionIndex == 1)
                {
                    questObject[2].SetActive(false);
                }
                break;
        }
    }

}

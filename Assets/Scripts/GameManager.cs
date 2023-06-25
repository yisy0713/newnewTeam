using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public int talkIndex;
    public TalkManager talkManager;
    public Text talkText;
    public Animator talkPanel;
    public Image portraitImg;
    public GameObject scanObject;
    public bool isAction;

    public PlayerAction player;
    //public Boss boss;
    //public int stage;
    public float playtime;
    public bool isBattle;

    public Image Equip1; //장착한 아이템 번호
    public Image Equip2; //장착한 아이템 번호
    public Image Equip3; //장착한 아이템 번호
    public Image Equip4; //장착한 아이템 번호
    public RectTransform DreamGaugeGroup;
    public RectTransform DreamGaugeBar;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }



    // Start is called before the first frame update
    void Start()
    {
        //playtime += Time.deltaTime;
        Debug.Log(questManager.CheckQuest());
    }

    void LateUpdate()
    {
        
        Equip1.color = new Color(1, 1, 1, player.hasEquip[0] ? 1 : 0);
        Equip2.color = new Color(1, 1, 1, player.hasEquip[1] ? 1 : 0);
        Equip3.color = new Color(1, 1, 1, player.hasEquip[2] ? 1 : 0);
        Equip4.color = new Color(1, 1, 1, player.hasEquip[3] ? 1 : 0);

        DreamGaugeBar.localScale = new Vector3(1/5, 1, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ��ϼ��� �ư���:0" });
        talkData.Add(3000, new string[] { ".....:0", "�� ���� ���δ�.:0" });
        talkData.Add(2000, new string[] { "���� ������ å�� �������ִ�.:0" });
        talkData.Add(5000, new string[] { "������Ǯ�̴�.:0" });
        talkData.Add(6000, new string[] { "�丮���̴�.:0" });
        talkData.Add(7000, new string[] { "���峭 �ð��̴�.:0" });


        talkData.Add(10 + 1000, new string[] { "�ȳ��� �ֹ��̳��� �ư���?:0", "���� �������� �����Ͻ� �ð��Դϴ�.:0" });
        talkData.Add(10 + 3000, new string[] { ".....:0", "�� ���� ���δ�.:0" });
        talkData.Add(11 + 2000, new string[] { "���� ������ å�� �������ִ�.:0", "�� �ӿ��� Ż���ϴ� ���:0", "1. ������Ǯ�� �޿� ���Ŵ�:0", "2. �ð��� �ǵ�����:0", "3. ������ ���Ѵ�.:0", "��..�ϴ� ������Ǯ�� ���� �˾ƺ��߰ڳ�..:1" });

        talkData.Add(20 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "1. ������Ǯ�� �޿� ���Ŵ�:0", "2. �ð��� �ǵ�����:0", "3. ������ ���Ѵ�.:0", "��..�ϴ� ������Ǯ�� ���� �˾ƺ��߰ڳ�..:1" });
        talkData.Add(20 + 1000, new string[] { "Ȥ�� ������Ǯ�� ���ؼ� �ƴ°� �־�?:1", "������Ǯ�̿�?:0", "��..�װŶ�� �Ƹ� �������� ã�� ���� �ְڳ׿�..:0" });
        talkData.Add(20 + 3000, new string[] { ".....:0", "�� ���� ���δ�.:0" });
        talkData.Add(20 + 5000, new string[] { "�̰� ������Ǯ�ΰ�..?:0", "������Ǯ�� ã�Ҵ�. ���翡�� å�� �ٽ� �о��:0" });
        talkData.Add(21 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "1. ������Ǯ�� �޿� ���Ŵ�:0", "�޿����ž� �Ѵٰ�..?:1" });

        talkData.Add(30 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "1. ������Ǯ�� �޿� ���Ŵ�:0", "�޿����ž� �Ѵٰ�..?:1" });
        talkData.Add(30 + 1000, new string[] { "�̰� ������Ǯ�� �¾�?:1", "�� ������Ǯ�� ã���̱���, �ư���:0", "�ֹ濡 ������ ������Ǯ�� ���̸� ����� ���� ���� �� �ְھ��.:0" });
        talkData.Add(30 + 3000, new string[] { ".....:0", "�� ���� ���δ�.:0" });
        talkData.Add(30 + 6000, new string[] { "������ ������Ǯ�� �޿���.:0", "���..�ʹ� ��..!:0", "���翡�� å�� �ٽ� �о��:0" });
        talkData.Add(31 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "2. �ð��� �ǵ�����.:0", "�ð��� �ǵ����°�..��� �ϴ°���..:1" });

        talkData.Add(40 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "2. �ð��� �ǵ�����.:0", "�ð��� �ǵ����°�..��� �ϴ°���..:1" });
        talkData.Add(40 + 1000, new string[] { "��...�߾�Ȧ�� �ð谡 ������ ��������..���� ���������� ���ž� ���ٵ�..:0" });
        talkData.Add(40 + 7000, new string[] { "��..�ð��� ��ħ��...:0", "��ħ�� �ڷ� ���ȴ�..�̰� �³�..?:0", "���翡�� å�� �ٽ� �о��:0" });
        talkData.Add(40 + 3000, new string[] { ".....:0", "�� ���� ���δ�.:0" });
        talkData.Add(41 + 2000, new string[] { "�� �ӿ��� Ż���ϴ� ���:0", "3. �׳࿡�� ������ ���� ������ ���Ѵ�:0", "..?���� �̷������̿���..? �׳�..?�� ������?:1", "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������:0", "?!!:1" });

        portraitData.Add(3000, portraitArr[0]);
        portraitData.Add(2000 + 0, portraitArr[1]);
        portraitData.Add(2000 + 1, portraitArr[0]);
        portraitData.Add(1000 + 0, portraitArr[2]);
        portraitData.Add(1000 + 1, portraitArr[0]);
        portraitData.Add(5000, portraitArr[0]);
        portraitData.Add(6000, portraitArr[0]);
        portraitData.Add(7000, portraitArr[0]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];


    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}

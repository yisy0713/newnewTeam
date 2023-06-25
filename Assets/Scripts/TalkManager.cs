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
        talkData.Add(1000, new string[] { "안녕하세요 아가씨:0" });
        talkData.Add(3000, new string[] { ".....:0", "내 얼굴이 보인다.:0" });
        talkData.Add(2000, new string[] { "낡고 오래된 책이 떨어져있다.:0" });
        talkData.Add(5000, new string[] { "달팽이풀이다.:0" });
        talkData.Add(6000, new string[] { "요리솥이다.:0" });
        talkData.Add(7000, new string[] { "고장난 시계이다.:0" });


        talkData.Add(10 + 1000, new string[] { "안녕히 주무셨나요 아가씨?:0", "이제 서제에서 공부하실 시간입니다.:0" });
        talkData.Add(10 + 3000, new string[] { ".....:0", "내 얼굴이 보인다.:0" });
        talkData.Add(11 + 2000, new string[] { "낡고 오래된 책이 떨어져있다.:0", "꿈 속에서 탈출하는 방법:0", "1. 달팽이풀을 달여 마신다:0", "2. 시간을 되돌린다:0", "3. 숙면을 취한다.:0", "음..일단 달팽이풀에 대해 알아봐야겠네..:1" });

        talkData.Add(20 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "1. 달팽이풀을 달여 마신다:0", "2. 시간을 되돌린다:0", "3. 숙면을 취한다.:0", "음..일단 달팽이풀에 대해 알아봐야겠네..:1" });
        talkData.Add(20 + 1000, new string[] { "혹시 달팽이풀에 대해서 아는게 있어?:1", "달팽이풀이요?:0", "음..그거라면 아마 정원에서 찾을 수도 있겠네요..:0" });
        talkData.Add(20 + 3000, new string[] { ".....:0", "내 얼굴이 보인다.:0" });
        talkData.Add(20 + 5000, new string[] { "이게 달팽이풀인가..?:0", "달팽이풀을 찾았다. 서재에서 책을 다시 읽어보자:0" });
        talkData.Add(21 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "1. 달팽이풀을 달여 마신다:0", "달여마셔야 한다고..?:1" });

        talkData.Add(30 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "1. 달팽이풀을 달여 마신다:0", "달여마셔야 한다고..?:1" });
        talkData.Add(30 + 1000, new string[] { "이게 달팽이풀이 맞아?:1", "와 달팽이풀을 찾으셨군요, 아가씨:0", "주방에 솥으로 달팽이풀을 달이면 향긋한 차를 마실 수 있겠어요.:0" });
        talkData.Add(30 + 3000, new string[] { ".....:0", "내 얼굴이 보인다.:0" });
        talkData.Add(30 + 6000, new string[] { "솥으로 달팽이풀을 달였다.:0", "우욱..너무 써..!:0", "서재에서 책을 다시 읽어보자:0" });
        talkData.Add(31 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "2. 시간을 되돌린다.:0", "시간을 되돌리는건..어떻게 하는거지..:1" });

        talkData.Add(40 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "2. 시간을 되돌린다.:0", "시간을 되돌리는건..어떻게 하는거지..:1" });
        talkData.Add(40 + 1000, new string[] { "음...중앙홀의 시계가 고장이 났더군요..빨리 수리기사님이 오셔야 할텐데..:0" });
        talkData.Add(40 + 7000, new string[] { "음..시계의 시침을...:0", "시침을 뒤로 돌렸다..이게 맞나..?:0", "서재에서 책을 다시 읽어보자:0" });
        talkData.Add(40 + 3000, new string[] { ".....:0", "내 얼굴이 보인다.:0" });
        talkData.Add(41 + 2000, new string[] { "꿈 속에서 탈출하는 방법:0", "3. 그녀에게 잡히지 말고 숙면을 취한다:0", "..?원래 이런내용이였나..? 그녀..?가 누구지?:1", "도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가도망가:0", "?!!:1" });

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

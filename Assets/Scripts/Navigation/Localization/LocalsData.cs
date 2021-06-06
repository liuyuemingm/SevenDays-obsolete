using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalsData : MonoBehaviour
{
    public static Hashtable English;
    public static Hashtable Chinese;
    public static bool isEnglish;

    

    private void Awake()
    {
        
        English = new Hashtable()
        {
            //plain text
            {"portraits" , "\nSome portrait paintings and pictures." },
            {"bed" , "\nNot the time to sleep" },
            {"tooHigh" , "\nI can't reach the shelves. \nI should ask the staff for a ladder tomorrow." },
            {"painting" , "\nA beautiful painting." },
            {"door" , "\nI need to dress up for the masquerade party.\nI also need an invitation letter." },
            {"paintingFog" , "\nWanderer above the Sea of Fog -- How romantic!" },
            {"noReading" , "\nI don't feel like reading today." },
            {"coatStand" , "\nCoat stand: \"I feel the room is a bit dark.\"" },
            {"mailBox" , "\nSomething seems to be stuck inside..." },
            {"normal" , "\nI feel great. " },
            {"dizzy" , "\nA little better now, but still dizzy. " },
            {"veryDizzy" , "\nThat's me in the mirror. My head is reeling. " },

            //TMP text
            {"PegRule1" , "1. Jump over a portrait piece to clear it\n\n\n\n\n2. Aim to clear all but\n      piece(s)" },
            {"options" , "Effects Volume\n\nMusic Volume\n\nLanguage\n\nExit?\n\n\t\t    Back" },
            {"exitYes" , "Yes  /" },
            {"exitNo" , "Nah. Never mind" },
            {"exitWarning" , "(progress won't be saved!)" },

            //Hint System text
            {"Peg" , "This little game is called peg solitaire. " +
                "I should aim to eleminate all but one pieces, " +
                "but there is some leeway in the 3rd and 4th sub-levels, " +
                "which allows me to leave off up to 3 or 5 pieces. " },
            {"MaxPlanck" , "   ( This comment is not related to the game" +
                " - but this is a picture of the great physicist Max Planck )\nTake a look at his bow. " },
            {"Churchill" , "        Look at his hand and see what he has to offer. " },
            {"Mirror" , "        That's a mirror, just to clarify :)" },
            {"Gloves" , "        Gloves, obviously. " },
            {"Blancket" , "        Blancket. " },
            {"CoatStand" , "Coat stand. The room has to be bright enough " +
                "for it to cast a shadow on the wall. " +
                "Hang the gloves and the blancket on the coat stand. " +
                "Patterns on the blancket give clues to a shadowgraphy game. " },
            {"Dress" , "        Dress. " },
            {"Scissors" , "A pair of scissors is essentially two knives joined together. " },
            {"Door" , "        Door" },
            {"RoomDivider" , "Room divider. It's thin enough for the light of a lamp to go through. " },
            {"Guitar" , "Darker guitar strings correspond to higher pitches. " +
                "I can adjust the light while playing the guitar. " },
            {"Letter" , "        Mailbox is next to the door. " },
            {"Table" , "        Small coffee table." },
            {"Star" , "Refer to the itch.io download page for a complete walkthrough. " +
             "\nBut hey, it would be super cool if you could figure it out by yourself!" },

        };

        Chinese = new Hashtable() 
        {
            {"portraits" , "\n一些肖像画和照片" },
            {"bed" , "\n现在不是睡觉时间" },
            {"tooHigh" , "\n我够不到上面的书架。\n明天应该向工作人员要一个梯子" },
            {"painting" , "\n一幅画" },
            {"door" , "\n出门参加化妆舞会前我应该打扮好，\n并带上邀请函" },
            {"paintingFog" , "\n《雾海上的旅行者》—— 多浪漫呀！" },
            {"noReading" , "\n今天不想读书......" },
            {"coatStand" , "\n衣架：“这房间有点暗。”" },
            {"mailBox" , "\n有什么东西卡在里面了......" },
            {"normal" , "\n我感觉很棒" },
            {"dizzy" , "\n感觉好一些了，但是还是有点晕" },
            {"veryDizzy" , "\n头晕目眩......" },

            {"PegRule1" , "1.  跳过一个棋子，吃掉它\n\n\n\n\n2.  留下的棋子不超过\n      个" },
            {"options" , "   音效音量\n\n   音乐音量\n\n   语言\n\n   离开?\n\n\t\t返回" },
            {"exitYes" , "是    /" },
            {"exitNo" , "否否否否否" },
            {"exitWarning" , "（进度不会被保存哦！）" },
            //{"" , "" },

            //Hint System text
            {"Peg" , "单身贵族棋。清除尽可能多的棋子来通关。" +
                "理想状态下最后剩下的棋子只能有一颗......但其实没有那么严格啦。" +
                "有时候剩下三五颗也算过关。" },
            {"MaxPlanck" , "（本评论与游戏无关）普朗克年轻的时候好帅！\n观察他的领结。" +
            "" },
            {"Churchill" , "看看他手里攥着什么。" },
            {"Mirror" , "镜子" },
            {"Gloves" , "这显然是手套" },
            {"Blancket" , "毛绒绒非常舒服的毯子" },
            {"CoatStand" , "衣架。房间足够亮的时候，衣架会在墙上投下影子。\n" +
                "将手套和毯子挂在衣架上，根据毯子图案的提示玩手影游戏。" },
            {"Dress" , "晚礼裙" },
            {"Scissors" , "剪刀" },
            {"Door" , "门" },
            {"RoomDivider" , "屏风很薄，灯的光线可以穿透。" },
            {"Guitar" , "弦色越浅，音调越低。在弹吉他的时候调整灯光。" },
            {"Letter" , "信箱在门旁边。" },
            {"Table" , "一张小咖啡桌" },
            {"Star" , "解谜攻略可以在 itch.io 界面上找到哦！（或者直接搜索B站~）\n但是如果能自己解出来就超酷啦！" },

        };
            
    }

    public void SwitchLanguage()
    {
        if (Localizer.LanguageIsEnglish == true)
            Localizer.LanguageIsEnglish = false;
        else
            Localizer.LanguageIsEnglish = true;
    }


}

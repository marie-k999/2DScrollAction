using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.SceneManagement;*/

using Doublsb.Dialog;

public class GoodEnd : MonoBehaviour
{
    public DialogManager dialogManager;

    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("．．．．．．▼"));
        dialogTexts.Add(new DialogData("．．．まさかニンゲンもケモノもいっぴきもコロさずにここまでたどりつくなんてね▼"));
        dialogTexts.Add(new DialogData("てきをふみつけてすすんだほうがラクだろうに▼"));
        dialogTexts.Add(new DialogData("いったいなんどめのプレイ？▼"));
        dialogTexts.Add(new DialogData("それともよっぽどのおひとよしなのかな？▼"));
        dialogTexts.Add(new DialogData("．．．ちぇっ、わかったよ。ボクのまけだ▼"));
        dialogTexts.Add(new DialogData("せいぜいこのクソみたいなせかいをいきていくといいさ▼"));
        dialogTexts.Add(new DialogData("▼"));
        dialogTexts.Add(new DialogData("．．．まあきみほどやるきとアイってやつにみちあふれたやつなら▼"));
        dialogTexts.Add(new DialogData("どんなせかいでもじゆうにいきていけるんだろうな▼"));
        dialogTexts.Add(new DialogData("ほんのちょっとだけ、うらやましいっておもったよ▼"));
        dialogTexts.Add(new DialogData("/speed:down/めでたしめでたし"));

       /* var TextThanks = new DialogData("THANK YOU FOR PLAYING!");
        TextThanks.SelectList.Add("Correct", "タイトルに戻る");
        
        TextThanks.Callback = () => Check_Correct();
        dialogTexts.Add(TextThanks);*/

        dialogManager.Show(dialogTexts);

    }
  
   /* private void Check_Correct()
    {
        if(DialogManager.Result == "Correct")
        {
            SceneManager.LoadScene("Title");
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Doublsb.Dialog;

public class HumanEnd : MonoBehaviour
{
    public DialogManager dialogManager;

    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("やあ、もとのすがたにもどれたみたいだね▼"));
        dialogTexts.Add(new DialogData("しかもニンゲンをあんなにいっぱいコロして▼"));
        dialogTexts.Add(new DialogData("ボクのニンゲンどもへのふくしゅうをてつだってくれてありがとう！▼"));
        dialogTexts.Add(new DialogData("キミだってやつらをにくんでいたんだろう？▼"));
        dialogTexts.Add(new DialogData("だってケモノよりニンゲンのほうをおおくコロしていたじゃあないか▼"));
        dialogTexts.Add(new DialogData("．．．もしかしてアソビかんかくでやってた？▼"));
        dialogTexts.Add(new DialogData("こんかいのジケンでニンゲンたちはもりのどうぶつたちをキケンなものとしてクジョしはじめるだろうけど▼"));
        dialogTexts.Add(new DialogData("そんなのボクのあずかりしらぬコトっていうか▼"));
        dialogTexts.Add(new DialogData("まあともかくこれからもがんばっていきてね！▼"));
        dialogTexts.Add(new DialogData("はじまったばかりのニンゲンとケモノのせいぞんきょうそうのなかで▼"));
        dialogTexts.Add(new DialogData("/speed:down/おしまい"));
        dialogManager.Show(dialogTexts);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

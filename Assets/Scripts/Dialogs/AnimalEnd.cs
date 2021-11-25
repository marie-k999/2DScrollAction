using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Doublsb.Dialog;

public class AnimalEnd : MonoBehaviour
{
    public DialogManager dialogManager;

    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("やあ、もとのすがたにもどれたみたいだね▼"));
        dialogTexts.Add(new DialogData("あれ、もしかしてじぶんがニンゲンだとおもってた？▼"));
        dialogTexts.Add(new DialogData("だからケモノをコロすことにていこうはなかったんだ▼"));
        dialogTexts.Add(new DialogData("それともムイシキでのドウゾクケンオってやつ？▼"));
        dialogTexts.Add(new DialogData("だってニンゲンいじょうにケモノのほうをコロしていたじゃあないか▼"));
        dialogTexts.Add(new DialogData("それともとくにかんがえずにコロしてまわってたのかな？▼"));
        dialogTexts.Add(new DialogData("ボクてきにはキミにはニンゲンをさつりくしてほしかったんだけど▼"));
        dialogTexts.Add(new DialogData("はんぶんニンゲンなきみがなかまをおそっていたから、どうぶつたちはカンカンさ▼"));
        dialogTexts.Add(new DialogData("じきにニンゲンたちをおそいはじめるだろうからOKだよ▼"));
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] lifeIcons;
    public GameObject[] cherryCountNums;

    public GameOverController gameOverController;

    public GameObject playerObj;
    PlayerController player;

    int animalScore;
    int humanScore;
    int faction;

    private void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
        animalScore = 0;
        humanScore = 0;
        faction = 4;
    }

    //  チェリーを取得した時に、PlayerControllerから呼び出されて、チェリーのUIの表示を切り替え
    //  念のため、全部をfalseにしてから目的のObjectをtrueにしているが、
    //  目的のObjectをtrueにして、1個前のObjectをfalseに、
    //  9から0のときだけ、9をfalseに0をtrueにする処理をすれば処理が軽くなりそう
    public void CherryUISwitch(int cherry)
    {
        for (int i = 0; i < cherryCountNums.Length; i++)
        {
            cherryCountNums[i].SetActive(false);
        }
        cherryCountNums[cherry].SetActive(true);
    }

    //  ライフ変動したときに、PlayerControllerから呼び出されて、ライフのUIの表示を切り替え
    public void LifeUISwitch(int life)
    {
        //  Playerから受け取ったlifeの引数に応じてUIを切り替え
        //  いちいち全部のアイコンのT/Fを切り替えているが、削れるコードもあると思う
        //  念のため全部書いてるけど、重かったら削るつもり
        switch (life)
        {
            case 0:
                for (int i = 0; i < lifeIcons.Length; i++)
                {
                    lifeIcons[i].SetActive(false);
                }
                //  0になったときは、GameOver
                gameOverController.GameOver();
                break;
            case 1:
                lifeIcons[0].SetActive(true);
                lifeIcons[1].SetActive(false);
                lifeIcons[2].SetActive(false);
                break;
            case 2:
                lifeIcons[0].SetActive(true);
                lifeIcons[1].SetActive(true);
                lifeIcons[2].SetActive(false);
                break;
            case 3:
                for (int i = 0; i < lifeIcons.Length; i++)
                {
                    lifeIcons[i].SetActive(true);
                }
                break;
        }
    }

    public GameObject[] FactionGauges;

    public void FactionUISwitch()
    {
        animalScore = player.GetAnimalScore();
        humanScore = player.GetHumanScore();

        faction = humanScore - animalScore;

        //  4より大きい値に、-4より小さい値がfactionに入ったら、-4<=x<=4の範囲に収まるよう補正
        if (faction > 4)
        {
            humanScore = animalScore + 4;
            faction = humanScore - animalScore;
        }
        else if (faction < -4)
        {
            animalScore = humanScore + 4;
            faction = humanScore - animalScore;
        }

        //  factionに応じてゲージのスプライトを出しわけ
        for (int i = 0; i < FactionGauges.Length; i++)
        {
            FactionGauges[i].SetActive(false);
        }

        FactionGauges[faction + 4].SetActive(true);
    }
}

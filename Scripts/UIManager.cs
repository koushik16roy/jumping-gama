using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText,_livesText;
   public void CoinDisplay(int coins)
   {
       _coinText.text = "Coins :"+ coins;
   }
   public void LivesDisplay(int lives)
   {
       _livesText.text = "Lives :"+ lives;
   }
}

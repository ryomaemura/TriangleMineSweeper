using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    [SerializeField] Button button8;
    [SerializeField] Button button9;
    [SerializeField] Button button10;
    [SerializeField] Button button11;
    [SerializeField] Button button12;
    [SerializeField] Button button13;
    [SerializeField] Button button14;
    [SerializeField] Button button15;
    Button[] buttons;
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    [SerializeField] TextMeshProUGUI buttonText7;
    [SerializeField] TextMeshProUGUI buttonText8;
    [SerializeField] TextMeshProUGUI buttonText9;
    [SerializeField] TextMeshProUGUI buttonText10;
    [SerializeField] TextMeshProUGUI buttonText11;
    [SerializeField] TextMeshProUGUI buttonText12;
    [SerializeField] TextMeshProUGUI buttonText13;
    [SerializeField] TextMeshProUGUI buttonText14;
    [SerializeField] TextMeshProUGUI buttonText15;
    [SerializeField] TextMeshProUGUI scoreLabel;
    TextMeshProUGUI[] buttonTexts;
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI gameOverText;
    int[] numbers = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    int[, ] relasionshipNumbers = {
    //   1  2  3  4  5  6  7  8  9  10 11 12 13 14 15
        {0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0},

        {0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0},
        {0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0},
        {0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1},
        
        {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
    };
    int bombNumber = 3;
    int randomNumber = 0;
    int relasionshipBombsNumber = 0;

    // Start is called before the first frame update
    void Start() {
        buttons = new Button[] {button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15};
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6, buttonText7, buttonText8, buttonText9, buttonText10, buttonText11, buttonText12, buttonText13, buttonText14, buttonText15};

        resetBomb();
    }

    // Update is called once per frame
    void Update() {
    }

    public void resetBomb() {
        for (int i = 0; i < numbers.Length; i++) {
            numbers[i] = 0;
            buttons[i].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
            buttonTexts[i].text = "";
        }

        for (int i = 0; i < bombNumber; i++) {
            // output 0 ~ numbers.length - 1
            randomNumber = UnityEngine.Random.Range(0, numbers.Length);

            if (numbers[randomNumber] != 1) {
                numbers[randomNumber] = 1;
            } else {
                i--;
            }
        }

        bombText.text = "Bomb:" + bombNumber.ToString();
        gameOverText.text = "";
    }

    public void clickNumberButton(int buttonNumber) {
        relasionshipBombsNumber = 0;

        if (numbers[buttonNumber] == 0) {
            // not bomb
            buttons[buttonNumber].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            for (int i = 0; i < numbers.Length; i++) {
                if (relasionshipNumbers[buttonNumber, i] == 1 && numbers[i] == 1) {
                    relasionshipBombsNumber++;
                }
            }

            buttonTexts[buttonNumber].text = relasionshipBombsNumber.ToString();
        } else {
            // bomb
            buttons[buttonNumber].GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            gameOverText.text = "Game Over";
        }
    }
}

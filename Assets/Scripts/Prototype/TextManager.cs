using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{

    [Space]
    //appears when in area of object
    [Header("Label Related")]
    public GameObject label;
    public TextMeshProUGUI labelText;

    [Space]
    [Header("Textbox Objects")]
    public GameObject textHolder;
    public TextMeshProUGUI _text;
    public TextMeshProUGUI nameTxt;
    public Image img; // shows whos taalking


    public string[] myLines;
    public int currentLine;
    public float textSpeed;

    [Space]
    [Header("Dialogue Runner Bools")]
    bool isTyping = false;
    bool cancelTyping = false;
    public bool isActive;// are things showing?
    public bool already; // did you press space already?

    float timer;
    bool isCountingDown;

    public int whichVoice;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isCountingDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                DisableTextBox();
                isCountingDown = false;
            }
        }
        if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (already)
            {
                if (!isTyping) // if no text is typing go to next line OR disable textbox
                {
                    currentLine += 1;
                    if (currentLine >= myLines.Length)
                    {
                        DisableTextBox();
                    }
                    else
                    {
                        StartCoroutine(Textscroll(myLines[currentLine]));
                    }
                }
                else if (isTyping && !cancelTyping) // cancel typing!
                {
                    cancelTyping = true;
                    already = false;
                }
            }
            else
            {
                already = true; // you pressed space already
            }
        }
    }

    public void DisplayLabel(string n)
    {
        label.SetActive(true);
        labelText.text = n;
    }


    private IEnumerator Textscroll(string lineoftext)
    {
        int letter = 0;
        _text.maxVisibleCharacters = 0;

        _text.text = lineoftext;

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < _text.text.Length - 1))
        {
            letter += 1;
            _text.maxVisibleCharacters = letter;
            yield return new WaitForSeconds(textSpeed);
        }

        _text.maxVisibleCharacters = _text.text.Length;
        isTyping = false;
        cancelTyping = false;
    }

    void BeginWaitingTime(float amt)
    {
        timer = amt;
        isCountingDown = true;
    }

    public void EnableTextBox(string[] newTextLines)
    {
        myLines = newTextLines;
        currentLine = 0;
        if(myLines.Length == 0)
        {
            Debug.LogError("ERROR! There's no lines for this week. Returning...");
            return;
        }

        StartCoroutine(Textscroll(myLines[currentLine]));
        textHolder.SetActive(true);
        isActive = true;
    }

    public void EnableTextBox()
    {
        StartCoroutine(Textscroll(myLines[currentLine]));
        textHolder.SetActive(true);
        isActive = true;
    }

    public void DisableTextBox()
    {
        already = false;
        isActive = false;
        textHolder.SetActive(false);
        _text.text = "";

    }
    public bool DoesContain(string theThing)
    {
        return myLines[currentLine].Contains(theThing);
    }

    public void CheckCharacter() // checks who to show is talking
    {

    }


}

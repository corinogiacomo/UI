using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText
{
    private TextMeshProUGUI dt;

    public DynamicText(TextMeshProUGUI tmpro)  //constructor
    {
        dt = tmpro;
    }

    public IEnumerator ShowWaitingDots(int number_dots, float speed)
    {
        string originaltxt = dt.text;
        while (true)
        {
            string ot_text = originaltxt;
            dt.text = ot_text;
            for (int i = 0; i < number_dots +1; i++)
            {
                yield return new WaitForSeconds(speed);
                ot_text += ".";
                dt.text = ot_text;
            }
        }
    }
    public IEnumerator ShowOverTime(float speed)
    {
        string ot_text = "";
        string originaltxt = dt.text;
        foreach (char c in originaltxt)
        {
            ot_text += c;
            dt.text = ot_text;
            yield return new WaitForSeconds(speed);
        }
    }
    public IEnumerator WaveEffect(float speed,float size_increment,Color color)
    {
        string originaltxt = dt.text;
        for (int x = 0; x <originaltxt.Length + 1; x++)
        {
            int i = 0;
            string ot_text = "";
            foreach (char c in originaltxt)
            {
                if (i == x)
                {
                    ot_text += 
                        CreateTag("size", "+" + size_increment, false) +
                        CreateTag("color", "#" + ColorUtility.ToHtmlStringRGB(color), false) +
                        c +
                        CreateTag("color", "#" + ColorUtility.ToHtmlStringRGB(color), true) +
                        CreateTag("size", "+" + size_increment, true);
                }

                else
                    ot_text += c;

                i++;
            }   
            dt.text = ot_text;
           
            yield return new WaitForSeconds(speed);
        }
    }
    private string CreateTag(string attribute,string sval, bool closure)
    {
        if (!closure)
            return "<" + attribute + "=" + sval + ">";
        else
            return "</" + attribute + "=" + sval + ">";
    }
}

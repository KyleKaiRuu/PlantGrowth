using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustSystem : MonoBehaviour
{
    [Range(0,100)]
    public int trust;

    public enum TRUSTSTAGE
    {
        NOTRUST,
        SOMEWHATTRUST,
        MOSTLYTRUST,
        FULLTRUST
    }

    public TRUSTSTAGE trustStage = TRUSTSTAGE.NOTRUST;

    public string trustGauge;
    public Text trustText;

    private void Update()
    {
        if (trust < 0)
        {
            trust = 0;
        }
        if (trust > 100)
        {
            trust = 100;
        }

        if (trust < 25)
        {
            trustStage = TRUSTSTAGE.NOTRUST;
            trustGauge = trust + " This animal species doesn't trust you.";
        }
        else if (trust >= 25 && trust < 65)
        {
            trustStage = TRUSTSTAGE.SOMEWHATTRUST;
            trustGauge = trust + " This animal species somewhat trusts you.";
        }
        else if (trust >= 65 && trust < 100)
        {
            trustStage = TRUSTSTAGE.MOSTLYTRUST;
            trustGauge = trust + " This animal species mostly trusts you.";
        }
        else
        {
            trustStage = TRUSTSTAGE.FULLTRUST;
            trustGauge = trust + " This animal species fully trusts you.";
        }
        trustText.text = trustGauge;
    }

    public void UpdateTrust(int amountToAdd)
    {
        trust += amountToAdd;
    }
}

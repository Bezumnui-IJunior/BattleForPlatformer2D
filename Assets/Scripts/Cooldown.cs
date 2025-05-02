using System.Collections;
using UnityEngine;

public class Cooldown
{
    private readonly WaitForSeconds _delay;

    public Cooldown(float delaySeconds)
    {
        _delay = new WaitForSeconds(delaySeconds);
        IsFree = true;
    }

    public bool IsFree { get; private set; }

    public IEnumerator Accuse()
    {
        IsFree = false;

        yield return _delay;

        // 0.8299966
        IsFree = true;
    }
}
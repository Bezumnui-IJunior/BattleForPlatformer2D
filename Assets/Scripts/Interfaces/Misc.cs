using System.Collections;
using UnityEngine;

public interface ITimerUser
{
    public Coroutine StartCoroutine(IEnumerator enumerator);
    public void StopCoroutine(Coroutine coroutine);
}
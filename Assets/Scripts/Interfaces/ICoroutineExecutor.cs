using System.Collections;
using UnityEngine;

public interface ICoroutineExecutor
{
    public Coroutine StartCoroutine(IEnumerator enumerator);
    public void StopCoroutine(Coroutine coroutine);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float time = 2;
    public void Destroy()
    {
        StartCoroutine(WaitAndDisappear());
    }
    private IEnumerator WaitAndDisappear()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

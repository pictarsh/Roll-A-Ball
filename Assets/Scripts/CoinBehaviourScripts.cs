using UnityEngine;

public class CoinBehaviourScripts : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
}

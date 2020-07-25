using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem red;
    [SerializeField] private ParticleSystem blue;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            red.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            red.Emit(1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            blue.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            blue.Emit(1);
        }

    }
}
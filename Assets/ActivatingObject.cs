using UnityEngine;

public class ActivatingObject : MonoBehaviour
{
    private float r;
    public bool isActive; 
    public void Activating(int type)
    {
        isActive = true;
    }
    public void UnActivating(int type)
    {
        isActive = false;
    }

    private void Update()
    {
        if (isActive && r > -90)
        {
            transform.Rotate(0, - 100 * Time.deltaTime, 0);
            r -= 100 * Time.deltaTime;
        }

        if (!isActive && r < 0) 
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
            r += 100 * Time.deltaTime;
        }
    }
}

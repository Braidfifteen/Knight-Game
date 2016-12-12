using UnityEngine;
using UnityEngine.UI;

public class TEst : MonoBehaviour
{
    public Camera cam;
    public RectTransform rt;
    public GameObject obj;
    private Vector2 pos;
    public Canvas c;



    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, obj.transform.position, cam, out pos);
        print(obj.transform.position);
        print(pos);
    }


}

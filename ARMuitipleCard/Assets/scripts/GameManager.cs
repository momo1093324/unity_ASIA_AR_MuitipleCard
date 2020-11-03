using UnityEngine;

public class GameManager : MonoBehaviour
{
    //定義兔子與蝙蝠
    //標題兔子 蝙蝠
    [Header("兔子")]
    public Transform rabbit;
    [Header("蝙蝠")]
    public Transform bat;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度"),Range(0.1f,20f)]
    public float turn = 1.5f;
    [Header("縮放"),Range(0f,5f)]
    public float size = 0.15f;
    private void Start()    //start enter
    {
        print("開始事件執行中");
    }
    private void Update()    //update enter
    {
        print("更新事件");
        print(joystick.Vertical);
        bat.Rotate(0, joystick.Horizontal * turn, 0);
        rabbit.Rotate(0, joystick.Horizontal*turn, 0);

        bat.localScale+= new Vector3(1, 1, 1) * joystick.Vertical*size;
    }
}

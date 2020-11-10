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
  
    [Header("兔子動畫元件")]
    public Animator aniRabbit;
    [Header("蝙蝠動畫元件")]
    public Animator aniBat;

    //public float test1 = 1;    public float test2 = 1; //搖桿大小縮放限制範例測試

    private void Start()    //start enter
    {
        print("開始事件執行中");
    }

    private void Update()    //update enter

    {
        print("更新事件");
        print(joystick.Vertical);
        bat.Rotate(0, joystick.Horizontal * turn, 0);  //虛擬搖桿旋轉速度
        rabbit.Rotate(0, joystick.Horizontal*turn, 0);

        bat.localScale+= new Vector3(1, 1, 1) * joystick.Vertical*size;//虛擬搖桿縮放
        rabbit.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;

        // test1 = Mathf.Clamp(test1, 0.5f, 9.9f); 或   test2 = (Mathf.Clamp(test2, 0, 10)); //搖桿大小縮放範例
        bat.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(bat.localScale.x, 0.5f, 3.5f);
        rabbit.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(rabbit.localScale.x, 0.5f, 3.5f);//搖桿大小縮放連結蝙蝠-蝙蝠=蝙蝠3維尺寸*數學(大小)

    }
    public void Playanimation (string aniName)      //Playanimation和aniName為自己定義取名
    {
        print(aniName);
        aniBat.SetTrigger(aniName);
        aniRabbit.SetTrigger(aniName);
    }

   //另一種按鈕控制動畫連結程式語法，缺點是如果多組無法一起修改
  // public void Attack()
  //  {
  //      print("攻擊");
  //    aniBat.SetTrigger("蝙蝠攻擊");
  //      aniRabbit.SetTrigger("兔子攻擊");
  //  }
  
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 角色移动速度，Inspector里可以直接改，不用改代码
    [Header("移动速度")]
    public float moveSpeed = 5f;

    // 存储角色的刚体组件
    private Rigidbody2D rb;

    void Start()
    {
        // 游戏启动时，自动获取角色身上的Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 监听WASD输入（也支持方向键）
        // Horizontal对应A/D（左/右），Vertical对应W/S（上/下）
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 把输入组合成方向向量，normalized保证斜向移动速度和正向一致
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;

        // 用物理方式移动角色，FixedUpdate保证移动平滑稳定
        rb.velocity = moveInput * moveSpeed;
    }
}
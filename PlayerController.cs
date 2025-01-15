using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    StageManagerData saveData = new StageManagerData();
    StageManager stagemanager;

    public bool controlEnabled = true;
    public LayerMask groundLayer;
    Vector2 move;

    public JoyStickController joystick;

    private Rigidbody2D rb;
    private bool facingRight = true;
    public float moveSpeed = 5f;
    public float jumpForce = 3f;

    public AudioClip JumpClip; // 점프 클립
    private AudioSource Jump_ASource; // JumpSource 컴포넌트

    public AudioClip SaveClip; // 저장 클립
    private AudioSource Save_ASource; // SaveSource 컴포넌트

    private float Jump_pitch = 1.25f;
    private float Jump_volume = 0.5f;

    public float airResistance = 0.5f; // 공기 저항


    CharacterManager CM = new CharacterManager();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        stagemanager = StageManager.Instance; // stagemanager 초기화

        CM = FindObjectOfType<CharacterManager>(); // CharacterManager 인스턴스 가져오기

        // AudioSource 컴포넌트를 가져오고 배경음악 클립을 설정합니다.
        Jump_ASource = gameObject.AddComponent<AudioSource>();
        Save_ASource = gameObject.AddComponent<AudioSource>();

        Jump_ASource.clip = JumpClip;
        Save_ASource.clip = SaveClip;

        Jump_ASource.pitch = Jump_pitch;
        Jump_ASource.volume = Jump_volume;

        saveData = stagemanager.stageData; // StageManager에서 데이터 가져오기
    }

    private void FixedUpdate()
    {
        float joystickValueX = joystick.Move.x;
        float joystickValueY = joystick.Move.y;

        move = new Vector2(joystickValueX * moveSpeed, rb.velocity.y);

        if (move.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (move.x < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = move; // move 값을 rb.velocity에 할당하여 캐릭터를 움직임

        if ((joystickValueX != 0 || joystickValueY != 0) && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            if (stagemanager.stageData.SoundController == true) Jump_ASource.Play();
           
        }

        ApplyAirResistance(); // 공기 저항 적용
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float HH = 0.35f;
    private bool IsGrounded()
    {
        float extraHeight = HH; // 약간의 여유 높이를 위한 추가 높이
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, extraHeight, groundLayer);
        return hit.collider != null;
    }

    private void ApplyAirResistance()
    {
        if (!IsGrounded())
        {
            rb.drag = airResistance;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    // 체크포인트 깃발 충돌 관리 스크립트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SaveFlag"))
        {
            if (stagemanager.stageData.SoundController == true) Save_ASource.Play(); // 깃발 충돌 소리
            if (SceneManager.GetActiveScene().name == "Stage 1")
            {
                saveData.StageSaveData_1 = new Vector2(CM.Character[stagemanager.stageData.Character_state].transform.position.x, CM.Character[stagemanager.stageData.Character_state].transform.position.y + 1f);
                Debug.Log("스테이지 1 깃발 충돌! 저장 위치 : " + saveData.StageSaveData_1);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 2")
            {
                saveData.StageSaveData_2 = new Vector2(CM.Character[stagemanager.stageData.Character_state].transform.position.x, CM.Character[stagemanager.stageData.Character_state].transform.position.y + 1f);
                Debug.Log("스테이지 2 깃발 충돌! 저장 위치 : " + saveData.StageSaveData_2);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 3")
            {
                saveData.StageSaveData_3 = new Vector2(CM.Character[stagemanager.stageData.Character_state].transform.position.x, CM.Character[stagemanager.stageData.Character_state].transform.position.y + 1f);
                Debug.Log("스테이지 3 깃발 충돌! 저장 위치 : " + saveData.StageSaveData_3);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 4")
            {
                saveData.StageSaveData_4 = new Vector2(CM.Character[stagemanager.stageData.Character_state].transform.position.x, CM.Character[stagemanager.stageData.Character_state].transform.position.y + 1f);
                Debug.Log("스테이지 4 깃발 충돌! 저장 위치 : " + saveData.StageSaveData_4);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 5")
            {
                saveData.StageSaveData_5 = new Vector2(CM.Character[stagemanager.stageData.Character_state].transform.position.x, CM.Character[stagemanager.stageData.Character_state].transform.position.y + 1f);
                Debug.Log("스테이지 5 깃발 충돌! 저장 위치 : " + saveData.StageSaveData_5);
            }
            collision.gameObject.SetActive(false);
        }
    }
}

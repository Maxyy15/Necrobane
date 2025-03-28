using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using AK.Wwise;

public class Enemy : MonoBehaviour
{
    public EnemyProfileSO enemyProfile;

    [Header("Status")]
    [SerializeField] protected bool enableRoaming = true;

    [Header("Enemy Roaming")]
    public float roamingMoveSpeed = 10f;
    [SerializeField] protected float minRoamWaitTime = 2f;
    [SerializeField] protected float maxRoamWaitTime = 3f;
    [SerializeField] protected float roamDetectionRadius = 12f;
    [SerializeField] protected float minRoamDistance = 3f;
    [SerializeField] protected float maxRoamDistance = 5f;
    [SerializeField] protected float roamDirectionChangeChance = 0.3f;
    [SerializeField] protected Transform groundPos;
    public NavMeshSurface navMeshSurface;
    [SerializeField] protected float roamingRotateSpeed = 1f;

    [Header("Enemy Detection")]
    [SerializeField] protected float detectRadius = 6f;
    [SerializeField] protected LayerMask playerMask;
    [SerializeField] protected float engageCooldownDuration = 0.3f;
    [SerializeField] protected float disengageCooldownDuration = 0.2f;

    [Header("Enemy Combat")]
    [SerializeField] protected float sphereRadius = 0.4f;
    [SerializeField] protected float maxDistance = 0.9f;
    [SerializeField] protected LayerMask combatLayer;
    [SerializeField] protected float rotateSpeed = 0.7f;
    [SerializeField] protected float attackDelay = 0.5f;
    public bool isAttacking { get; set; }
    public bool isDetected { get; set; }
    public bool EnemyHit { get; set; }
 
    [Header("SphereCast")]
    protected Ray sphereRay;
    protected RaycastHit enemyHitInfo;

    [Header("Enemy Stats")]
    public string EnemyName { get; set; }
    public float EnemyHealth { get; set; }
    public float EnemyDamage { get; set; }
    public GameObject[] ItemDropObj { get; set; }

    [Header("UI")]
    [SerializeField] protected Slider healthSlider;

    [Header("Others")]
    public NavMeshAgent navMeshAgent;
    public EnemyList enemyList;
    public Transform player { get; set; }

    [Header("Wwise")]
    // Wwise
    protected bool FootstepIsPlaying = false;
    protected bool LandingIsPlaying = false;
    protected float LastFootstepTime = 0;
    protected int _speed;
    protected RaycastHit hit;
    protected string PhysMat;
    protected string PhysMat_Last;


    public virtual void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public virtual void Start()
    {
        EnemyName = enemyProfile.EnemyName;
        EnemyHealth = enemyProfile.EnemyHealth;
        EnemyDamage = enemyProfile.EnemyDamage;
        ItemDropObj = enemyProfile.itemDrop;

        healthSlider.value = EnemyHealth;
    }

    public virtual void Update()
    {
        EnemyStatus();
    }

    public void DeductHealth(float damage)
    {
        EnemyHealth -= damage;
        healthSlider.value = EnemyHealth;
    }

    public void EnemyStatus()
    {
        if (EnemyHealth <= 0)
        {
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = false;
            }

            gameObject.SetActive(false);
            EnemyManager.Instance.enemyAttackingList.Remove(gameObject.GetComponent<Enemy>());
            AkSoundEngine.PostEvent("Play_SkeletonDeath", gameObject);
            ItemDrop();
        }
    }

    public void ItemDrop()
    {
        if(ItemDropObj.Length >= 0)
        {
            int randomValue = Random.Range(0, ItemDropObj.Length);
            Instantiate(ItemDropObj[randomValue], transform.position, Quaternion.identity);
        }
    }

    public void SetEnemyForce(Vector3 direction, float currentForce)
    {
        Debug.Log(direction + " and " + currentForce);
    }
}

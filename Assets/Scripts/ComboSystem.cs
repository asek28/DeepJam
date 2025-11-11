using UnityEngine;
using UnityEngine.InputSystem;

public class ComboSystem : MonoBehaviour
{
	private Animator anim;

	[Header("Combo Settings")]
	[Tooltip("Time window to chain next hit before combo resets (seconds)")]
	public float comboResetTime = 1.25f; // was 0.5f
	[Tooltip("Minimum time between two attack inputs (seconds)")]
	public float minAttackInterval = 0.2f;

	private int comboCount = 0;
	private float lastComboTime = 0f;
	private float lastAttackTime = 0f;
	private bool isAttacking = false;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	void Update()
	{
		
		bool attackPressed = false;
		
		var keyboard = Keyboard.current;
		var mouse = Mouse.current;
		
		
		if (mouse != null)
		{
			attackPressed = mouse.leftButton.wasPressedThisFrame;
		}
		
		else if (keyboard != null)
		{
			attackPressed = keyboard.enterKey.wasPressedThisFrame;
		}
		
		
		if (anim != null)
		{
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			isAttacking = stateInfo.IsName("Dual Weapon_01") || 
						 stateInfo.IsName("Dual Weapon_02") || 
						 stateInfo.IsName("Dual Weapon Combo 1");
		}
		
		
		if (attackPressed && Time.time - lastAttackTime >= minAttackInterval)
		{
			lastAttackTime = Time.time;
			
			
			if (!isAttacking)
			{
				
				comboCount = 1;
			}
			else
			{
				
				comboCount++;
			}
			
			// Maksimum combo
			if (comboCount > 4)
			{
				comboCount = 3;
			}
			
			Debug.Log($"Attack pressed! Combo Count: {comboCount}, Is Attacking: {isAttacking}");
			
			
			if (anim != null)
			{
				anim.SetInteger("ComboCount", comboCount);
				
				
				Debug.Log($"Setting ComboCount to {comboCount} in Animator");
			}
			
			
			lastComboTime = Time.time;
		}
		
		// combo reset
		if (Time.time - lastComboTime > comboResetTime && comboCount > 0)
		{
			comboCount = 0;
			lastComboTime = Time.time;
			
			if (anim != null)
			{
				anim.SetInteger("ComboCount", 0);
			}
			
			Debug.Log("Combo reset!");
		}
	}
}


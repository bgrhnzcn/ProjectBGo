using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour

{
    [SerializeField] private bool isFirstSkill;
    [SerializeField] private 
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isFirstSkill)
            FirstSkill();
        else if (Input.GetKeyDown(KeyCode.T) && isFirstSkill)
            Debug.Log("Yetenek Beklemede!");
    }
    void FirstSkill()
    {
        StartCoroutine(SkillCooldown());
        isFirstSkill = true;
    }
    IEnumerator SkillCooldown()
    {
        Debug.Log("Skill kullanildi!");
        yield return new WaitForSecondsRealtime(14f);
        Debug.Log("Skill kullanilabilir!");
        isFirstSkill = false;
    }
}

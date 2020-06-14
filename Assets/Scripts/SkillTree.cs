using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Objects/Skill", order = 2)]
public class SkillTree : ScriptableObject
{


    public Skill root; // very first skill unlocked by default

    [System.Serializable]
    public class Skill
    {
        public Skill root, leftSkill, rightTree;
        public bool isLocked = true;

        public void UseSkill(Skill s)
        {

        }

    }

    public void UnlockSkill(Skill s)
    {
        s.isLocked = false;
    }

}

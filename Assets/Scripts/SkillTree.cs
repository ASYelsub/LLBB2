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
        // character specific
        public Character specificCharacter; // if this isn't null, this skil is only for a specific character
        public int expNeeded; // exp needed to be unlocked
        public enum Study { };
        public Study study; // which study does this skill belong too?
        // skilltype

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

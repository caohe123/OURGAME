using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public int hp;
    public int maxHp;
    public int shield;//护盾
    public int drawCount;
    public string entityName;

    public Action<int, int> OnHpChanged;

    public Entity(int maxHp, string entityName) {
        this.hp = maxHp;
        this.maxHp = maxHp;
        this.shield = 0;
        this.drawCount = 5;
        this.entityName = entityName;
    }

    public void ApplyHpChange(int delta) {
        hp = Mathf.Clamp(hp + delta, 0, maxHp);
        OnHpChanged?.Invoke(hp, maxHp);
        if (hp <= 0) {
            //执行死亡程序
        }
    }
    public void TakeDamage(int damage) {
        if (damage < 0) return;
        if (shield > 0) {
            if (shield >= damage)
            {
                shield -= damage;
                damage = 0;
            }
            else {
                damage -= shield;
                shield = 0;
            }
        }
        if (damage > 0) { 
            ApplyHpChange(-damage);
        }
    }

    public int GetFinalDarwCount() {
        return drawCount;
    }
}

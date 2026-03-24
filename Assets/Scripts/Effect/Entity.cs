using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public int hp;
    public int maxHp;
    public string entityName;

    public Action<int,int> OnHpChanged;

    public Entity(int maxHp, string entityName) {
        this.hp = maxHp;
        this.maxHp = maxHp;
        this.entityName = entityName;
    }

    public void TakeDamage(int amount) {
        hp -= amount;
        OnHpChanged?.Invoke(hp, maxHp);
    }
}

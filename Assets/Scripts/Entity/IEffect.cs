using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {
	IEnumerable Execute(Entity sourse,Entity target,int value);
}

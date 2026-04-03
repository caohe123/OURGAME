# OURGAME

###### 状态机一览:

1. SetupState(初始化)
2. PlayerDrawState执行抽牌程序和动画
3. PlayerTurnState执行出牌程序
4. EnemyTurnState敌人抽牌和出牌程序
5. PauseState暂停UI界面
6. StateMgr通过单例模式,调用SwitchState(new  子类(单例))来切换状态

###### 实体Entity：

目前含有hp,maxhp,shield,drawCount,entityName,Action<int,int>属性

其中EntityView接受委托，生命受到伤害执行动画，可视化

###### 卡牌:

分为数据层和可视化层，数据层指向数据之间的计算，可视化和UI挂钩

###### 效果:

目前只拥有扣血和护盾的逻辑




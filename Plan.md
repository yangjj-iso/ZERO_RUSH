# 计划

## 计划+详细分工

* 建立实体核心（基类）+人物核心+怪物1（test）核心 （属性系统（属性系统内数值要封装在一个配置文件内，方便数值策划测试）

  * **生命系统**：主控单位与敌对单位生命值以格数为计，每次受击固定削减1—2格生命
* 定义人物基础行为（移动要与关卡设计对接）

  * **基础操作**：左键射击，空格跳跃，Shift加速
  * **生命回复**：击杀敌人可以回复注射器（用于生命回复）
* 事件如血量为零，被伤害，击中敌方）事件系统参考？：使用EventHandler承接一切事件，各Event在内，各对应一键值（恒定），需要时重写事件，或者不同关卡加载不同事件
* 根据已开发内容继续完善武器系统（武器与人物的对接，子弹实体，射击方向跟随鼠标，~~偏移量基值15°~~，霰弹枪取以人物到鼠标的射线为中心的~~75°~~扇形，短距离内为攻击范围，只要敌人在范围内，则造成伤害）
* 关卡设计（先简单弄一个，等美术对接）

* [ ] 属性核心
* [ ] 人物行为
* [ ] 事件系统
* [ ] 武器系统（sine老师）
* [ ] 关卡设计

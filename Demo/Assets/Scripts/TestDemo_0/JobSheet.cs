/* *********************************
 * Description : This is an auto-generated code and do not modify it
 * Author : SZQ
 * Copyright © 2021 ACT. All rights reserved.
 * *********************************/
//using Oro;
//using Oro.Sheet;
using UnityEngine;
using System.Collections.Generic;
//using Newtonsoft.Json.Linq;

namespace SheetData
{
    public  class JobRow
    {
        /// <summary>
        /// 职业标记
        /// </summary>
        private string m_Tag;
        /// <summary>
        /// 编号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 名字
        /// </summary>
        private string m_Name;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID;
        /// <summary>
        /// 名字
        /// </summary>
        public string Name;
        /// <summary>
        /// 职业标记
        /// </summary>
        public string Tag;
        /// <summary>
        /// 模型名
        /// </summary>
        public string Model;
        /// <summary>
        /// 横向速度
        /// </summary>
        public float HorizontalSpeed;
        /// <summary>
        /// 纵向速度
        /// </summary>
        public float VerticalSpeed;
        /// <summary>
        /// 重量
        /// </summary>
        public int Mass;
        /// <summary>
        /// 力量
        /// </summary>
        public int Strength;
        /// <summary>
        /// 智力
        /// </summary>
        public int Intellect;
        /// <summary>
        /// 体力
        /// </summary>
        public int Stamina;
        /// <summary>
        /// 精神
        /// </summary>
        public int Spirit;
        /// <summary>
        /// 生命值
        /// </summary>
        public int Hp;
        /// <summary>
        /// 魔法值
        /// </summary>
        public int Mp;
        /// <summary>
        /// 生命回复
        /// </summary>
        public int HpRegen;
        /// <summary>
        /// 魔法回复
        /// </summary>
        public int MpRegen;
        /// <summary>
        /// 物理攻击
        /// </summary>
        public int PhyAtk;
        /// <summary>
        /// 魔法攻击
        /// </summary>
        public int MagAtk;
        /// <summary>
        /// 独立攻击
        /// </summary>
        public int IndAtk;
        /// <summary>
        /// 物理防御
        /// </summary>
        public int PhyDef;
        /// <summary>
        /// 魔法防御
        /// </summary>
        public int MagDef;
        /// <summary>
        /// 物理暴击
        /// </summary>
        public int PhyCritHit;
        /// <summary>
        /// 魔法暴击
        /// </summary>
        public int MagCritHit;
        /// <summary>
        /// 暴击伤害
        /// </summary>
        public int CritValue;
        /// <summary>
        /// 攻击速度
        /// </summary>
        public int AtkSpeed;
        /// <summary>
        /// 施放速度
        /// </summary>
        public int CastSpeed;
        /// <summary>
        /// 移动速度
        /// </summary>
        public int MoveSpeed;
        /// <summary>
        /// 命中率
        /// </summary>
        public int Hit;
        /// <summary>
        /// 回避率
        /// </summary>
        public int Dodge;

        public JobRow()
        {
            
        }

        public JobRow(int hit,int dodge)
        {
            Hit = hit;
            Dodge = dodge;
        }

    }

    //public  class JobSheet : SheetSingleton<JobSheet>
    //{
    //    const string RES_PATH = "Json/Job";

    //    Dictionary<int, JobRow> _map;

    //    static readonly JobRow _empty = new JobRow();
    //    public static JobRow Empty { get { return _empty; } }

    //    protected override void InitSingleton()
    //    {
    //        TextAsset textAsset = Resources.Load<TextAsset>(RES_PATH);

    //        JobRow[] rows = JsonHelper.To<JobRow[]>(textAsset.text);
            
    //        _map = new Dictionary<int, JobRow>(rows.Length);

    //        foreach (var row in rows) _map[row.ID] = row;
    //    }

    //    public JobRow GetRow(int id)
    //    {
    //        if (_map.ContainsKey(id)) return _map[id];

    //        return _empty;
    //    }
    //}
}
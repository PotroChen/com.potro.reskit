using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.ResKit
{
    public class ResourceRes : Res
    {
        public ResourceRes(string asset) : base(asset)
        {

        }

        public override void Load()
        {
            base.Load();
            asset = Resources.Load(Name.Substring("resources://".Length));
        }

        protected override void UnLoad()
        {
            base.UnLoad();
            if (asset is GameObject)//Resources不能UnLoad GameObject AssetBundle等类型（一般assetBundle一般也不会放在Resources里面）
            {
            }
            else
                Resources.UnloadAsset(asset);
        }
    }

}
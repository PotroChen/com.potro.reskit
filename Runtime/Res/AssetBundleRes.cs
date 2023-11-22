using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework.ResKit
{
    public class AssetBundleRes : Res
    {
        public AssetBundleRes(string assetName) : base(assetName)
        {
        }

        public override void Load()
        {
            base.Load();
            asset = AssetBundle.LoadFromFile(Path);
            if (asset == null)
                Debug.LogErrorFormat("AssetBundle:{0} do not exists");
        }

        protected override void UnLoad()
        {
            base.UnLoad();
            (asset as AssetBundle).Unload(true);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleRes : Res
{
    public AssetBundleRes(string assetName):base(assetName)
    {
    }

    public override void Load()
    {
        base.Load();
        asset = AssetBundle.LoadFromFile(Name);
        if (asset == null)
            Debug.LogErrorFormat("AssetBundle:{0} do not exists");
    }

    protected override void UnLoad()
    {
        base.UnLoad();
        (asset as AssetBundle).Unload(true);
    }
}

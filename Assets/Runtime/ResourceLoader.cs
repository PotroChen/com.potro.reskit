using UnityEngine;
using System.Collections.Generic;

public class ResLoader {

    /// <summary>
    /// 持有的资源
    /// </summary>
    private List<Res> resList = new List<Res>();

    public T LoadAsset<T>(string assetName,string assetBundleName = null) where T :Object
    {
        Res loadedRes = resList.Find(loadedAsset => loadedAsset.Name == assetName);

        if (loadedRes != null)
        {
            return loadedRes.Asset as T;
        }

        loadedRes = ResMgr.GetRes(assetName, assetBundleName);

        resList.Add(loadedRes);

        return loadedRes.Asset as T;
    }

    public void UnLoadAll()
    {
        for (int i = 0; i < resList.Count; i++)
        {
            resList[i].Release();
        }

        resList.Clear();
        resList = null;
    }
}



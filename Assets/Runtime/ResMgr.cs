using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.ResKit
{
    public class ResMgr
    {

        /// <summary>
        /// 共享的资源
        /// </summary>
        public static List<Res> SharedLoadedReses = new List<Res>();//Resource里的资源和AssetBundle的资源重名的话，还没有做区分

        public static void Init()
        {
            AssetTable.Load();
        }

        public static Res GetRes(string resName, string assetBundleName = null)
        {
            Res res = SharedLoadedReses.Find(loadedAsset => loadedAsset.Name == resName);

            if (res != null)
            {
                res.Retain();
                return res;
            }

            if (resName.StartsWith("resources://"))
            {
                res = new ResourceRes(resName);
            }
            else
            {
                res = new AssetRes(resName, assetBundleName);
            }

            res.Load();
            SharedLoadedReses.Add(res);
            res.Retain();

            return res;
        }

        public static AssetBundleRes GetAssetBundleRes(string assetName)
        {
            Res res = SharedLoadedReses.Find(loadedAsset => loadedAsset.Name == assetName);

            if (res != null)
            {
                res.Retain();
                return res as AssetBundleRes;
            }

            res = new AssetBundleRes(assetName);
            res.Load();
            SharedLoadedReses.Add(res);
            res.Retain();

            return res as AssetBundleRes;

        }
    }

}
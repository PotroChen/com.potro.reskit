using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace GameFrameWork.ResKit
{
    [Serializable]
    public class AssetTable
    {
        public List<AssetBundleInfo> AssetBundleInfos = new List<AssetBundleInfo>();

        private static AssetTable instance;
        public static AssetTable Instance { get { return instance; } }

        public static void Load()
        {
            foreach (var operation in Load(Application.streamingAssetsPath + "/AssetBundles/AssetTable.json")) ;
        }

        public static IEnumerable Load(string path)
        {
            WWW www = new WWW(path);
            yield return www;
            if (www.error != null)
                Debug.LogError(www.error);
            else
            {
                instance = JsonConvert.DeserializeObject<AssetTable>(www.text);
            }

            www.Dispose();

            if (instance == null)
                Debug.LogError("AssetTable 读取失败");
        }

        /// <summary>
        /// 根据AssetName获取AssetBundleName
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public string GetAssetBundleName(string assetName)
        {
            //TODO 搜索算法有待更新
            foreach (AssetBundleInfo assetBundleInfo in AssetBundleInfos)
            {
                AssetInfo searchedAssetInfo = assetBundleInfo.AssetInfos.Find(assetInfo => assetInfo.AssetName == assetName);
                if (searchedAssetInfo != null)
                    return searchedAssetInfo.OwnerAssetBundleName;
            }

            return null;
        }
    }

}
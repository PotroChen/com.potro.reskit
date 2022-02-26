using System;
using System.Collections.Generic;

namespace GameFrameWork.ResKit
{
    [Serializable]
    public class AssetBundleInfo
    {

        public List<AssetInfo> AssetInfos = new List<AssetInfo>();
        public string AssetBundleName;
    }

}
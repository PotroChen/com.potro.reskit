using UnityEngine;

namespace GameFramework.ResKit
{
    /// <summary>
    /// 职责：资源的抽象
    /// </summary>
    public class Res
    {
        public string Path { get; private set; }

        protected Object asset;

        private int refCount;

        public Res(string assetPath)
        {
            Path = assetPath;
        }

        public void Retain()
        {
            refCount++;
        }

        public void Release()
        {
            refCount--;
            if (refCount <= 0)
            {
                UnLoad();

                ResMgr.SharedLoadedReses.Remove(this);
                asset = null;
            }
        }

        public Object Asset { get { return asset; } }

        public virtual void Load() { }

        protected virtual void UnLoad() { }
    }

}
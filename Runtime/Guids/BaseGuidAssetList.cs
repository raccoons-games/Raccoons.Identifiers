using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raccoons.Identifiers.Guids
{
    [Serializable]
    public abstract class BaseGuidAssetList<T> : IGuidAssetList where T: IGuid
    {
        [SerializeField]
        private List<T> guids;

        public List<T> Guids { get => guids; }

        public BaseGuidAssetList()
        {
            guids = new List<T>();
        }

        public HashSet<IGuid> GetGuidsSet()
        {
            HashSet<IGuid> result = new HashSet<IGuid>((IEnumerable<IGuid>)guids);
            return result;
        }
        public bool IsSubsetOf(IGuidAssetList compareTo)
        {
            return GetGuidsSet().IsSubsetOf(compareTo.GetGuidsSet());
        }
        public bool IsContains(IGuidAssetList compareTo)
        {
            bool result = false;
            var tags = GetGuidsSet();
            foreach (var tag1 in compareTo.GetGuidsSet())
            {
                if (tags.Contains(tag1) == true)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public bool IsContainGuid(IGuid guid)
        {
            return GetGuidsSet().Contains(guid);
        }
    }
}

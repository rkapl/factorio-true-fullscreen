using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorio_patcher
{
    public class MatchException : Exception
    {

    }
    public class Matcher
    {
        private byte[] mData;
        private int mOffset;
        public Matcher(byte[] data)
        {
            mData = data;
        }

        public void Reset()
        {
            mOffset = 0;
        }

        public bool Compare(params byte[] b)
        {
            if (mOffset + b.Length > mData.Length)
                return false;

            for (int i = 0; i < b.Length; i++)
            {
                if (mData[mOffset + i] != b[i])
                    return false;
            }

            return true;
        }
        public void Patch(params byte[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                mData[mOffset++] = b[i];
            }
        }
        public bool Advance(int i)
        {
            if (mOffset + i >= mData.Length)
                return false;
            mOffset += i;
            return true;
        }
        public void Find(params byte[] b)
        {
            while (Advance(1))
            {
                if (Compare(b))
                {
                    int offset = mOffset;
                    // check multiple match
                    while (Advance(1))
                    {
                        if (Compare(b))
                            throw new MatchException();
                    }
                    mOffset = offset;
                    return;
                }
            }

            throw new MatchException();
        }
        
        public byte[] Data{
            get{
                return mData;
            }
        }
    }
}

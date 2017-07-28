using System;

namespace Engines.Engines.GetMediaByHashTagEngine
{
    public static class TagsHalper
    {
        public static string AddSharp(string tag)
        {
            return "#" + tag;
        }

        public static string RemoveSharp(string tag)
        {
            var index = tag.IndexOf("#", StringComparison.Ordinal);
            tag = tag.Substring((index + 1), tag.Length - (index + 1));

            return tag;
        }
    }
}

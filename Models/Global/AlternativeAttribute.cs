using System;

namespace EFreelancer.Models.Global
{
    internal class AlternativeAttribute : Attribute
    {
        public string Alternative;

        public AlternativeAttribute(string v)
        {
            this.Alternative = v;
        }
    }
}
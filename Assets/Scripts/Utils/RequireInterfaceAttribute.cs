using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Attribute that require implementation of the provided interface.
    /// </summary>
    public class RequireInterfaceAttribute : PropertyAttribute
    {
        public System.Type RequiredType { get; }
        
        public RequireInterfaceAttribute(System.Type type)
        {
            RequiredType = type;
        }
    }
}

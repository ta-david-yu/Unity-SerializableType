﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYSerializer
{
    public abstract class ClassConstraintAttribute : PropertyAttribute
    {
        private bool m_AllowAbstract = false;
        public bool AllowAbstract { get { return m_AllowAbstract; } set { m_AllowAbstract = value; } }

        public abstract IEnumerable<Type> GetEnumerableOfSatisfiedTypes();
    }

    public class InterfaceImplmentationAttribute : ClassConstraintAttribute
    {
        public Type InterfaceType { get; set; }

        public InterfaceImplmentationAttribute()
        {

        }

        public InterfaceImplmentationAttribute(Type interfaceType)
        {
            InterfaceType = interfaceType;
        }

        public override IEnumerable<Type> GetEnumerableOfSatisfiedTypes()
        {
            return ReflectiveEnumerator.GetEnumerableOfInterfaceImplmentation(InterfaceType, AllowAbstract);
        }
    }

    public class ClassExtensionAttribute : ClassConstraintAttribute
    {
        public Type BaseType { get; set; }

        public ClassExtensionAttribute()
        {

        }

        public ClassExtensionAttribute(Type baseType)
        {
            BaseType = baseType;
        }

        public override IEnumerable<Type> GetEnumerableOfSatisfiedTypes()
        {
            return ReflectiveEnumerator.GetEnumerableOfClassExtension(BaseType, AllowAbstract);
        }
    }
}
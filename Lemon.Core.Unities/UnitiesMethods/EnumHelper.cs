﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Lemon.Core.Unities.UnitiesMethods
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 扩展方法,获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            var field = type.GetField(name);
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? name : attribute.Description;
        }

        /// <summary>
        /// 扩展方法,获得枚举的Description
        /// </summary>
        /// <returns>枚举的Description</returns>
        public static Dictionary<int, string> GetDescriptionDict(Type enumType)
        {
            return EnumToDictionary(enumType, GetDescription);
        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">获得值得文本</param>
        /// <returns>以枚举值为key,枚举文本为value的键值对集合</returns>
        public static Dictionary<int, string> EnumToDictionary(Type enumType, Func<Enum, string> getText)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", nameof(enumType));
            }
            var enumDic = new Dictionary<int, string>();
            var enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                var key = Convert.ToInt32(enumValue);
                var value = getText(enumValue);
                enumDic.Add(key, value);
            }
            return enumDic;
        }

        /// <summary>
        /// 将整型值转换成相应的枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">整形值</param>
        /// <returns>枚举</returns>
        public static T IntToEnum<T>(int value) where T : struct, IConvertible
        {
            var enumType = typeof(T);
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException("整形值在相应的枚举里面未定义！");
            }

            return (T)Enum.ToObject(enumType, value);
        }

        /// <summary>
        /// 将枚举转换成相应的整型值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns>整形</returns>
        public static int EnumToInt<T>(T value) where T : struct, IConvertible
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 将枚举转换成相应的整型值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>整形</returns>
        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 将枚举转换成相应的整型值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>string</returns>
        public static string ToIntString(this Enum value)
        {
            return Convert.ToInt32(value).ToString();
        }


        /// <summary>
        /// 将整型值转换成相应的枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">整形值</param>
        /// <returns>枚举</returns>
        public static T StringToEnum<T>(string value) where T : struct, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}

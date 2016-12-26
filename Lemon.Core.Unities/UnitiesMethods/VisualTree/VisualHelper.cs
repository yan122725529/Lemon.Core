using System.Windows;
using System.Windows.Media;

namespace ZilLion.Core.Infrastructure.Unities.VisualTree
{
    public static class VisualHelper
    {
        #region UIHelper

        public static T FindAncestor<T>(this DependencyObject dependencyObject) where T : DependencyObject
        {
            while (dependencyObject != null && !(dependencyObject is T))
            {
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            return dependencyObject as T;
        }

        #endregion

        /// <summary>
        ///     递归查找视觉树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="visual"></param>
        /// <returns></returns>
        public static T FindVisualChild<T>(this Visual visual) where T : Visual
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                var child = (Visual) VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    var correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    var descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }

        public static T FindAncestorByLogicalTree<T>(this DependencyObject dependencyObject) where T : DependencyObject
        {
            while (dependencyObject != null && !(dependencyObject is T))
            {
                dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);
            }
            return (T) dependencyObject;
        }

        #region 方法

        /// <summary>
        ///     遍历视觉树向上查找目标propertyToFind=propertyValue的DependencyObject
        /// </summary>
        /// <param name="root">查找的元素</param>
        /// <param name="propertyToFind">查找的属性</param>
        /// <param name="propertyValue">对应属性的值</param>
        /// <returns></returns>
        public static DependencyObject GetVisualParentByProperty(DependencyObject root,
            DependencyProperty propertyToFind, object propertyValue)
        {
            var dpParent = VisualTreeHelper.GetParent(root);
            if (dpParent == null)
            {
                return null;
            }
            if (dpParent.GetValue(propertyToFind).Equals(propertyValue))
            {
                return dpParent;
            }
            return GetVisualParentByProperty(dpParent, propertyToFind, propertyValue);
        }

        /// <summary>
        ///     遍历视觉树向下查找目标propertyToFind=propertyValue的DependencyObject
        /// </summary>
        /// <param name="root">查找的元素</param>
        /// <param name="propertyToFind">查找的属性</param>
        /// <param name="propertyValue">对应属性的值</param>
        /// <returns></returns>
        public static DependencyObject GetVisualChildByProperty(DependencyObject root, DependencyProperty propertyToFind,
            object propertyValue)
        {
            var iNum = VisualTreeHelper.GetChildrenCount(root);
            for (var i = 0; i < iNum; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child.GetValue(propertyToFind).Equals(propertyValue))
                {
                    return child;
                }
                var nowChild = GetVisualChildByProperty(child, propertyToFind, propertyValue);
                if (nowChild != null)
                {
                    return nowChild;
                }
            }
            return null;
        }

        /// <summary>
        ///     遍历视觉树向上查找目标Name的DependencyObject
        /// </summary>
        /// <param name="root">查找的元素</param>
        /// <param name="strNameToFind">需要查找的Name</param>
        /// <returns></returns>
        public static DependencyObject GetVisualParentByName(DependencyObject root, string strNameToFind)
        {
            var dpParent = VisualTreeHelper.GetParent(root);
            if (dpParent == null)
            {
                return null;
            }
            if (dpParent.GetValue(FrameworkElement.NameProperty).ToString().Equals(strNameToFind))
            {
                return dpParent;
            }
            return GetVisualParentByName(dpParent, strNameToFind);
        }

        /// <summary>
        ///     遍历视觉树查找目标Name的DependencyObject
        /// </summary>
        /// <param name="root">查找的元素</param>
        /// <param name="strNameToFind">需要查找的Name</param>
        /// <returns></returns>
        public static DependencyObject GetVisualChildByName(DependencyObject root, string strNameToFind)
        {
            var iNum = VisualTreeHelper.GetChildrenCount(root);
            for (var i = 0; i < iNum; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child.GetValue(FrameworkElement.NameProperty).ToString().Equals(strNameToFind))
                {
                    return child;
                }
                var nowChild = GetVisualChildByName(child, strNameToFind);
                if (nowChild != null)
                {
                    return nowChild;
                }
            }
            return null;
        }

        /// <summary>
        ///     遍历逻辑树查找目标Name的DependencyObject
        /// </summary>
        /// <param name="root">查找的元素</param>
        /// <param name="strNameToFind">需要查找的Name</param>
        /// <returns></returns>
        public static DependencyObject GetChildByName(DependencyObject root, string strNameToFind)
        {
            var dp = LogicalTreeHelper.GetChildren(root);
            foreach (var child in dp)
            {
                var dpChild = child as DependencyObject;
                if (dpChild != null)
                {
                    if (dpChild.DependencyObjectType.Name == strNameToFind)
                    {
                        return dpChild;
                    }
                    return GetChildByName(dpChild, strNameToFind);
                }
            }
            return null;
        }

        #endregion
    }
}
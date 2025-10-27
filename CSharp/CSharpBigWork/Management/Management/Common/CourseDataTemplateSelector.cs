using System.Windows;
using System.Windows.Controls;
using Management.Model;

namespace Management.Common
{
    public class CourseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTempalte { get; set; }
        public DataTemplate SkeletonTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if((item as CourseModel).IsShowSkeleton)
            {
                return SkeletonTemplate;
            }

            return DefaultTempalte;
        }
    }
}

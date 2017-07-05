﻿using Xamarin.Forms;

namespace EretailApp.Behaviors
{
    public class MaxLengthValidatorBehavior : Behavior<BoxBorderEntry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidatorBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(BoxBorderEntry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= MaxLength)
                ((BoxBorderEntry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
        }

        protected override void OnDetachingFrom(BoxBorderEntry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
}


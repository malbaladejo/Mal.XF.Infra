using Xamarin.Forms;

namespace Mal.XF.Infra.Behaviors
{
    public class DisableSelectionListViewBehavior : BehaviorBase<ListView>
    {
        protected override void OnAttachedTo(ListView list)
        {
            base.OnAttachedTo(list);
            this.AssociatedObject.ItemSelected += this.OnItemSelected;
        }

        protected override void OnDetachingFrom(ListView list)
        {
            base.OnDetachingFrom(list);
            this.AssociatedObject.ItemSelected -= this.OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.AssociatedObject.SelectedItem = null;
        }
    }
}
using Xamarin.Forms;

namespace Mal.XF.Infra.Behaviors
{
    public abstract class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        protected T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T associatedObject)
        {
            base.OnAttachedTo(associatedObject);
            this.AssociatedObject = associatedObject;
        }

        protected override void OnDetachingFrom(T associatedObject)
        {
            base.OnDetachingFrom(associatedObject);
            this.AssociatedObject = null;
        }
    }
}
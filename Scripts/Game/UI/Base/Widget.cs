namespace Game.UI.Base
{
    public abstract class Widget<TModel,TListener> : BaseUIPanel
    {
        protected TModel Model { get; private set; }
        protected TListener Listener { get; private set; }
        
        public virtual void SetListener(TListener listener)
        {
            Listener = listener;
        }
        public virtual void SetModel(TModel model)
        {
            Model = model;
            Refresh();
        }

        public abstract void Refresh();
    }
}
namespace Game.UI.Base
{
    public abstract class MenuController
    {
        public abstract void Initialize();
        public abstract void Dispose();
        public abstract void Refresh();
    }
    
    public abstract class MenuController<TMenuView> : MenuController where TMenuView : BaseUIPanel
    {
        protected TMenuView MenuView {get;}

        protected MenuController(TMenuView menuView)
        {
            MenuView = menuView;
        }
    }
    
    public abstract class MenuController<TMenuView, TUIDataService> : MenuController<TMenuView> where TMenuView : BaseUIPanel
    {

        protected TUIDataService DataService { get; private set; }
        
        protected MenuController(TMenuView menuView, TUIDataService dataService) : base(menuView)
        {
            DataService = dataService;
        }
    }
}
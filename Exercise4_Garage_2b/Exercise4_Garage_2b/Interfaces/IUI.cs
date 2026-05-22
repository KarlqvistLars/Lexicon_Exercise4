[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Exercise4_Garage_2b.Tests")]
namespace Exercise4_Garage_2b.Interfaces {
    public interface IUI {
        internal static abstract void LoadMenuText();
        public static abstract void MenuMain(Garage<IVehicle> garage);
    }
}

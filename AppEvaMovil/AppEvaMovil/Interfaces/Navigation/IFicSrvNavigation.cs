using System;
using System.Collections.Generic;
using System.Text;


namespace AppEvaMovil.Interfaces.Navigation
{
    public interface IFicSrvNavigation
    {
        void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null, bool show = true);

        void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null);

        void FicMetNavigateTo(Type destinationType, object navigationContext = null);

        void FicMetNavigateBack();
    }
}

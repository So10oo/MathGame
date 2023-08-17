using System.Windows.Controls;

namespace MathGame.Pages
{
    public class PageBase 
    {
        Page MainPage { get; set; }
        public PageBase(Page mainPage)
        {
            MainPage = mainPage;
        }
    }


}

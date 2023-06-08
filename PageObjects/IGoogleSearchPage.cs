namespace ConstellationQAAutomation.PageObjects
{
    // TODO: Convert into an abstract class?
    internal interface IGoogleSearchPage<out TP> where TP : IGoogleSearchPage<TP>
    {
        public Uri GetUri();
        public TP Go();
    }
}

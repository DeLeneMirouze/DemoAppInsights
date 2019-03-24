namespace DemoAppInsights
{
    public class AppSettings
    {
        /// <summary>
        /// Url vers l'appli AVEC Application insights
        /// </summary>
        public string apiInsightsUrl { get; set; }
        /// <summary>
        /// Url vers l'appli sans Application Insights
        /// </summary>
        public string apiNoInsightsUrl { get; set; }
        /// <summary>
        /// Chaîne de connexion à la queue
        /// </summary>
        /// <remarks>
        /// La clef secrète devra être récupérée dans le Vault sous le nom: queueKey
        /// </remarks>
        public string Queue { get; set; }
        /// <summary>
        /// Url du Key Vault
        /// </summary>
        public string UrlAkv { get; set; }
    }
}
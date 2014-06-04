namespace Sitecore.SharedSource.IndexThis
{
    using System.Linq;
    using Data.Items;
    using Diagnostics;
    using Shell.Framework.Commands;

    internal class IndexThisAndDescendants : Command
    {
        /// <summary>
        /// Executes the command in the specified context.
        /// </summary>
        /// <param name="commandContext">The command context.</param>
        public override void Execute(CommandContext commandContext)
        {
            Assert.ArgumentNotNull(commandContext, "commandContext");

            if (commandContext.Items.Length >= 1)
            {
                Item item = commandContext.Items[0];

                if (item != null)
                {
                    Item[] descendants = item.Axes.GetDescendants();

                    Log.Info(string.Format("About to run Index This And Descendants of item: '{0}'.", item.Paths.FullPath), this);

                    item.Database.Engines.HistoryEngine.RegisterItemSaved(item, null);

                    if (descendants != null && descendants.Any())
                    {
                        foreach (Item descendant in descendants)
                        {
                            descendant.Database.Engines.HistoryEngine.RegisterItemSaved(descendant, null);
                        }
                    }
                }
            }
        }
    }
}

namespace Sitecore.SharedSource.IndexThis
{
    using Data.Items;
    using Diagnostics;
    using Shell.Framework.Commands;

    internal class IndexOnlyThis : Command
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

                Log.Info(string.Format("About to run Index This item: '{0}'.", item.Paths.FullPath), this);

                if (item != null)
                    item.Database.Engines.HistoryEngine.RegisterItemSaved(item, null);
            }
        }

    }
}

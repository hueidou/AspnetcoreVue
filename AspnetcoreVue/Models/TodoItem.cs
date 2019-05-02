namespace AspnetcoreVue.Models
{
    /// <summary>
    /// TodoItem
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// TodoItem.Id
        /// </summary>
        /// <value></value>
        public long Id { get; set; }

        /// <summary>
        /// TodoItem.Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// TodoItem.IsComplete
        /// </summary>
        /// <value></value>
        public bool IsComplete { get; set; }
    }
}